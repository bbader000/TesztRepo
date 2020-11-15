﻿using hazi8.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hazi8.Entities
{
   public  class Ball : Toy
    {

        public Ball()
        {
            AutoSize = false;
            Height = 50;
            Width = 50;

            this.Paint += Ball_Paint;
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

       

        public void MoveBall()
        {
            Left = Left + 1;
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }
    }
}
