using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    internal class Creature
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
                 
                    value = value.Trim();
                    if (value.Length > 25)
                    {
                        value = value.Substring(0, 25).TrimEnd();
                    }

                    
                    if (value.Length < 3)
                    {
                        value = value.PadRight(3, '#');
                    }

                    name = char.ToUpper(value[0]) + value.Substring(1);
                }
            }
        }

        private int level = 1;
        public int Level
        {
            get => level;
            init => level = Math.Clamp(value, 1, 10); 
        }

        public string Info => $"{Name} [{Level}]";

        
        public Creature(string name = "Unknown", int level = 1)
        {
            Name = name;
            Level = level;
        }

        public Creature() { }

       
        public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");


        public void Upgrade()
        {
            if (level < 10)
            {
                level++;
            }

        }
        public void Go(Direction dir)
        {
            Console.WriteLine($"{name} goes {dir.ToString().ToLower()}");
        }
        public void Go(Direction[] dirs)
        {
            foreach (Direction dir in dirs)
            {
                Go(dir);
            }
        }
        public void Go(string input)
        {
            Direction[] dirs = DirectionParser.Parse(input);
            Go(dirs);
        }
    }



}
