using hazi8.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hazi8.Entities
{
   public  class Ball : Abstractions.Toy
    {
    
        public SolidBrush bBallColor { get; private  set; }

        public Ball(Color _color)
        {
            bBallColor = new SolidBrush(_color);
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
            g.FillEllipse(bBallColor, 0, 0, Width, Height);
        }
    }
}
