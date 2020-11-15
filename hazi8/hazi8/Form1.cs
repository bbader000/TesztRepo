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
        private BallFactory _factory;
        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        Timer createTimet, conveyorTimer;
        List<Toy> _balls = new List<Toy>();

        public Form1()
        {
            InitializeComponent();

           
            mainPanel.Width = this.Width;

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
            foreach (var ball in _balls)
            {
                ball.MoveBall();



                if (ball.Left > max)
                {

                    max = ball.Left;
                }
            }



            if (max >= 1000)
            {
                var rightBall = _balls[0];
                mainPanel.Controls.Remove(rightBall);
                _balls.Remove(rightBall);
            }
        }

        private void CreateTimet_Tick(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            _balls.Add(ball);
            ball.Left = -ball.Width;
            mainPanel.Controls.Add(ball);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
