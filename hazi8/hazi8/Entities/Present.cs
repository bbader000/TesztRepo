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
    public class Present : Toy
    {

        public Present(Color _ribbon, Color _box)
        {

            BackColor = _box;

            Button ribbonV = new Button {
                BackColor = _ribbon,
                Width = this.Width / 5
            };

            Button ribbonH = new Button
            {
                BackColor = _ribbon,
                Height = this.Height / 5
            };

            ribbonH.Top = this.Top + this.Height / 2;
            ribbonH.Left = this.Left;
            ribbonV.Left = this.Left + this.Width / 2;
            ribbonV.Top = this.Top;

            this.Controls.Add(ribbonV);
            this.Controls.Add(ribbonH);


        }

        protected override void DrawImage(Graphics g)
        {
            
        }
    }
}
