using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public abstract class Creature
    {
        private string name = "Unknown";
        public string Name
        {
            get => name;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    name = "Unknown";
                }
                else
                {
                    value = Validator.Shortener(value, 3, 25, '#');
                    name = char.ToUpper(value[0]) + value.Substring(1);
                }
            }
        }

        private int level = 1;
        public int Level
        {
            get => level;
            init => level = Validator.Limiter(value, 1, 10);
        }

        public Creature(string name = "Unknown", int level = 1)
        {
            Name = name;
            Level = level;
        }

        public Creature() { }


        public abstract string Greeting();

        public abstract int Power { get; }

        public abstract string Info { get; }

        public void Upgrade()
        {
            if (level < 10)
            {
                level++;
            }

        }
        public string Go(Direction direction) => direction.ToString().ToLower();

        public string[] Go(Direction[] directions) 
        {
            var result = new string[directions.Length];
            for(int i = 0; i < directions.Length; i++)
            {
                result[i] = Go(directions[i]);
            }
            return result;
        }

        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}
