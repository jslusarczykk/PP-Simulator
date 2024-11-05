using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    internal class Elf : Creature
    {
        private int agility;
        private const int MIN_AGILITY = 0;
        private const int MAX_AGILITY = 10;

        private int singCounter = 0;
        private const int SINGS_FOR_UPGRADE = 3;

        public int Agility
        {
            get
            {
                return agility;
            }

            init
            {
                agility = Validator.Limiter(value, MIN_AGILITY, MAX_AGILITY);
            }
        }

        public Elf() : base() { }

        public Elf(string name = "Unknown", int level = 1, int agility = 0) : base(name, level)
        {
            Agility = agility;
        }

        public void Sing()
        {
            Console.WriteLine($"{Name} is singing.");
            singCounter++;
            if (singCounter == SINGS_FOR_UPGRADE)
            {
                singCounter = 0;
                if (agility < MAX_AGILITY)
                {
                    agility++;
                }
            }
        }

        public override void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name} the Elf, my level is {Level} and my agility is {Agility}");
        }

        public override int Power => Level * 8 + Agility * 2;

        public override string Info => $"{Name} [{Level}][{Agility}]";

    }
}
