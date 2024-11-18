using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public class Orc : Creature
    {
        private int rage;
        private const int MIN_RAGE = 0;
        private const int MAX_RAGE = 10;

        private int huntCounter = 0;
        private const int HUNTS_FOR_UPGRADE = 2;

        public int Rage
        {
            get
            {
                return rage;
            }

            init
            {
                rage = Validator.Limiter(value, MIN_RAGE, MAX_RAGE);
            }
        }

        public Orc() : base() { }

        public Orc(string name = "Unknown", int level = 1, int rage = 0) : base(name, level)
        {
            Rage = rage;
        }

        public void Hunt()
        {
            Console.WriteLine($"{Name} is hunting.");
            huntCounter++;
            if (huntCounter == HUNTS_FOR_UPGRADE)
            {
                huntCounter = 0;
                if (rage < MAX_RAGE)
                {
                    rage++;
                }
            }
        }

        public override string Greeting()
        {
            return($"Hi, I'm {Name} the Orc, my level is {Level} and my rage is {Rage}");
        }

        public override int Power => Level * 7 + Rage * 3;

        public override string Info => $"{Name} [{Level}][{Rage}]";

    }
}
