using hazi07.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace hazi07
{
    public partial class Form1 : Form
    {
        Random rnd = new Random(1234);
        public List<Person> Population = new List<Person>();
        public List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        public List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        public Form1()
        {
            InitializeComponent();

            readAllcsv();
            //dataGridView1.DataSource = Population;
            //dataGridView2.DataSource = BirthProbabilities;
            //dataGridView3.DataSource = DeathProbabilities;



            for (int year = 2005; year < 2024; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }

                int NumOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int NumOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();

                Console.WriteLine(
        string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, NumOfMales, NumOfFemales));
            }

        }

        private void SimStep(int year, Person person)
        {
            if (person.IsAlive != true)
            {
                return;
            }

            int age = year - person.BirthYear;

            double Pdeath = (from x in DeathProbabilities
                             where x.Gender == person.Gender && x.Age == age
                             select x.Pdeath).FirstOrDefault();

            
            if (Pdeath >= rnd.NextDouble() )
            {
                person.IsAlive = false;
            }

            if (person.Gender == Gender.Female && person.IsAlive)
            {
                double Pbirth = (from x in BirthProbabilities
                                 where x.Age == age
                                 select x.Pbirth).FirstOrDefault();

                if (Pbirth >= rnd.NextDouble())
                {
                    Person newborn = new Person();
                    newborn.BirthYear = year;
                    newborn.Gender = (Gender)rnd.Next(1, 3);
                    newborn.NbrOfChildren = 0;
                    Population.Add(newborn);
                }

            }

            
        }

        void readAllcsv()
        {
            Population = readPerson("C:\\Temp\\nép-teszt.csv");
            BirthProbabilities = readBirth("C:\\Temp\\születés.csv");
            DeathProbabilities = readDeath("C:\\Temp\\halál.csv");
        }

        private List<DeathProbability> readDeath(string path)
        {
            List<DeathProbability> deathProbabilities = new List<DeathProbability>();

            StreamReader sr = new StreamReader(path, Encoding.Default);

            while (!sr.EndOfStream)
            {
                DeathProbability temp = new DeathProbability();
                string[] block = sr.ReadLine().Split(';');
                temp.Gender = (Gender)Enum.Parse(typeof(Gender), block[0]);
                temp.Age = int.Parse(block[1]);
                temp.Pdeath = double.Parse(block[2]);

                deathProbabilities.Add(temp);
            }


            sr.Close();

            return deathProbabilities;
        }

        private List<BirthProbability> readBirth(string path)
        {
            List<BirthProbability> birthProbabilities = new List<BirthProbability>();

            StreamReader sr = new StreamReader(path, Encoding.Default);

            while (!sr.EndOfStream)
            {
                BirthProbability temp = new BirthProbability();
                string[] block = sr.ReadLine().Split(';');
                temp.Age = int.Parse(block[0]);
                temp.NumOfChildren = int.Parse(block[1]);
                temp.Pbirth = double.Parse(block[2]);

                birthProbabilities.Add(temp);
            }


            sr.Close();

            return birthProbabilities;
        }

        private List<Person> readPerson(string path)
        {
            List<Person> people = new List<Person>();

            StreamReader sr = new StreamReader(path, Encoding.Default);

            while (!sr.EndOfStream)
            {
                Person temp = new Person();
                string [] block = sr.ReadLine().Split(';');
                temp.BirthYear = int.Parse(block[0]);
                temp.Gender = (Gender)Enum.Parse(typeof(Gender), block[1]);
                temp.NbrOfChildren = int.Parse(block[2]);

                people.Add(temp);
            }


            sr.Close();

            return people;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
