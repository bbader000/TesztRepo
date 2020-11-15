using hazi8.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hazi8.Entities
{
    class PresentFactory : IToyFactory
    {
        public Color ribbon { get; set; }
        public Color box { get; set; }

        public PresentFactory()
        {
            
        }

        public Toy CreateNew()
        {
            return new Present(ribbon, box);
        }
    }
}
