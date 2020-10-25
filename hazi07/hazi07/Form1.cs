﻿using hazi07.Entities;
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
        public Random rnd = new Random(1234);
        public List<Person> Population = new List<Person>();
        public List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        public List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        public Form1()
        {
            InitializeComponent();

        }
        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            List<Results> results = Simulation();
            DisplayResults(results);

        }

        private void DisplayResults(List<Results> results)
        {
            string final = "";
            
            for (int i = 0; i < results.Count; i++)
            {
                string temp = "Szimulációs év: "+results[i].Year+"\n\tFérfiak: "+results[i].NumOfMales+"\n\tNők: "+results[i].NumOfFemales+"\n\n";
                final = final + temp;


                richTextbox.Text = final;
            }
        }

        public List<Results> Simulation()
        {
            readAllcsv();
            int endYear = (int)numYears.Value;

            List<Results> results = new List<Results>();


            for (int year = 2005; year < endYear; year++)
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


                Results temp = new Results();
                temp.Year = year;
                temp.NumOfFemales = NumOfFemales;
                temp.NumOfMales = NumOfMales;
                results.Add(temp);

            }
            return results;
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
            string path = textBox1.Text;
            Population = readPerson(path);
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        
    }
}
