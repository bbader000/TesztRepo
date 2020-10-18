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
using System.Xml;

namespace hazi6
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();

        public Form1()
        {
            InitializeComponent();

            string result = MainRequest();
            dgv.DataSource = Rates;

            ProcessXML(result);
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

        private string MainRequest()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
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
