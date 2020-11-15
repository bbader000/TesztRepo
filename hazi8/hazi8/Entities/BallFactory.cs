using hazi8.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hazi8.Entities
{
   public  class BallFactory : IToyFactory
    {



        public Ball CreateNew()
        {
            return new Ball();
        }

        Abstractions.Toy IToyFactory.CreateNew()
        {
            return new Ball();
        }
    }
}
