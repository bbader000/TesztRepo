using hazi6.Entities;
using hazi6.MnbService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace hazi6
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<String> Currencies = new BindingList<string>();

        public Form1()
        {
            InitializeComponent();
            //CurrencyAdd();
           
            //comboBox1.DataSource = Currencies;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePicker2_ValueChanged;
            RefreshData();

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            Rates.Clear();
            string result = MainRequest();
            dgv.DataSource = Rates;
            ProcessXML(result);
            ChartCreate();
        }

        private void ChartCreate()
        {



            chartRateData.DataSource = Rates;

            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;
            chartRateData.Legends[0].Enabled = false;
            ChartArea area = chartRateData.ChartAreas[0];
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisY.IsStartedFromZero = false;

        }

        private void ProcessXML(string result)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement item in xml.DocumentElement)
            {
                var rate = new RateData();
                Rates.Add(rate);


                rate.Date = DateTime.Parse(item.GetAttribute("date"));

                var temp = (XmlElement)item.ChildNodes[0];
                rate.Currency = temp.GetAttribute("curr");
             

                var unit = decimal.Parse(temp.GetAttribute("unit"));
                var value = decimal.Parse(temp.InnerText);

                if (unit != 0)
                {
                    rate.Value = value / unit;
                    }
            }

        }

        //private void CurrencyAdd()
        //{

        //    string result = CurrReq();
        //    XmlDocument xml = new XmlDocument();
        //    xml.LoadXml(result);

        //    foreach (XmlElement item in xml.DocumentElement)
        //    {

        //        var temp = (XmlElement)item.ChildNodes[0];               
        //        ChechkCurr(temp.GetAttribute("curr"));

        //    }

           
        //}

        private void ChechkCurr(string v)
        {
            for (int i = 0; i < Currencies.Count; i++)
            {
                if (Currencies[i] == v)
                {
                    return;
                }
            }

            Currencies.Add(v);
        }

        private string MainRequest()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = comboBox1.Text,
                startDate = dateTimePicker1.Value.ToString(),
                endDate = dateTimePicker2.Value.ToString()
            };

            GetExchangeRatesResponseBody response = mnbService.GetExchangeRates(request);

             string result = response.GetExchangeRatesResult;
            return result;
        }

        private string CurrReq()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                startDate = "2020 - 01 - 01",
                endDate = "2020 - 10 - 01",
            };

            GetExchangeRatesResponseBody response = mnbService.GetExchangeRates(request);

            string result = response.GetExchangeRatesResult;
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
