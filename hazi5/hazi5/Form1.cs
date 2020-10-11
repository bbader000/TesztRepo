﻿using hazi5.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hazi5
{
    public partial class Form1 : Form
    {
         PortfolioEntities context = new PortfolioEntities();
         List<Tick> Ticks;
         List<PortfolioItem> items = new List<PortfolioItem>();
        
        public Form1()
        {
            InitializeComponent();


            Ticks = context.Ticks.ToList();
            dgv.DataSource = Ticks;


            createport();


            List<decimal> Nyereségek = new List<decimal>();
            int intervalum = 30;
            DateTime kezdőDátum = (from x in Ticks select x.TradingDay).Min();
            DateTime záróDátum = new DateTime(2016, 12, 30);
            TimeSpan z = záróDátum - kezdőDátum;
            for (int i = 0; i < z.Days - intervalum; i++)
            {
                decimal ny = GetPortfolioValue(kezdőDátum.AddDays(i + intervalum))
                           - GetPortfolioValue(kezdőDátum.AddDays(i));
                Nyereségek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            var nyereségekRendezve = (from x in Nyereségek
                                      orderby x
                                      select x)
                                        .ToList();
            MessageBox.Show(nyereségekRendezve[nyereségekRendezve.Count() / 5].ToString());
        }

         void createport()
        {
            items.Add(new PortfolioItem() { index = "OTP", vol = 10 });
            items.Add(new PortfolioItem() { index = "ZWACK", vol = 10 });
            items.Add(new PortfolioItem() { index = "ELMU", vol = 10 });



            dgv2.DataSource = items;
        }

        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in items)
            {
                var last = (from x in Ticks
                            where item.index == x.Index.Trim()
                               && date <= x.TradingDay
                            select x)
                            .First();
                value += (decimal)last.Price * item.vol;
            }
            return value;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SaveFileDialog ofd = new SaveFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;

            StreamWriter sw = new StreamWriter(ofd.FileName);

            sw.WriteLine("Időszak - Nyereség");

            for (int i = 0; i < Ticks.Count; i++)
            {
                sw.WriteLine("{0} - {1}", Ticks[i].Volume, Ticks[i].Price);
            }

        }
    }
}
