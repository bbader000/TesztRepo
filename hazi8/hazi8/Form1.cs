using hazi8.Abstractions;
using hazi8.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hazi8
{
    public partial class Form1 : Form
    {

        private Toy _nextToy;
        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value;
                DisplayNext();
            }
        }

        

        List<Toy> _toys = new List<Toy>();

        private void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);
        }

        public Form1()
        {
            InitializeComponent();

           
            mainPanel.Width = this.Width;
            Timer createTimet = new Timer();
            Timer conveyorTimer = new Timer();
            createTimet.Interval = 3000;
            createTimet.Start();
            createTimet.Tick += CreateTimet_Tick;
            conveyorTimer.Interval = 10;
            conveyorTimer.Start();
            conveyorTimer.Tick += ConveyorTimer_Tick;
        }


        private void ConveyorTimer_Tick(object sender, EventArgs e)
        {
            int max = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();



                if (toy.Left > max)
                {

                    max = toy.Left;
                }
            }



            if (max >= 1000)
            {
                var rightToy = _toys[0];
                mainPanel.Controls.Remove(rightToy);
                _toys.Remove(rightToy);
            }
        }

        private void CreateTimet_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add(toy);
            toy.Left = -toy.Width;
            mainPanel.Controls.Add(toy);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory
            {
                BallColor = btn_color.BackColor
        };
        }

        private void btn_car_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorPicker = new ColorDialog();
            colorPicker.Color = button.BackColor;
            if (colorPicker.ShowDialog() != DialogResult.OK)
                return;
            button.BackColor = colorPicker.Color;
        }

        private void color_ribbon_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorPicker = new ColorDialog();
            colorPicker.Color = button.BackColor;
            if (colorPicker.ShowDialog() != DialogResult.OK)
                return;
            button.BackColor = colorPicker.Color;
        }

        private void color_box_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorPicker = new ColorDialog();
            colorPicker.Color = button.BackColor;
            if (colorPicker.ShowDialog() != DialogResult.OK)
                return;
            button.BackColor = colorPicker.Color;
        }

        private void btn_present_Click(object sender, EventArgs e)
        {
            Factory = new PresentFactory
            {
                ribbon = color_ribbon.BackColor,
                box = color_box.BackColor
                
                
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
