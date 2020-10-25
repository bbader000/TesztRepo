using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hazi07.Entities
{
    public class BirthProbability
    {
        public int Age { get; set; }
        public int NumOfChildren { get; set; }
        public double Pbirth { get; set; }
    }

    public class DeathProbability
    {
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public double Pdeath { get; set; }
    }
}
