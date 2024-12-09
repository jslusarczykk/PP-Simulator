namespace Simulator
{
    public class Ostrich : Creature
    {
        public Ostrich(string name = "Unknown", int level = 1) : base(name, level) { }

        public override string Greeting()
        {
            return $"Hi, I'm {Name} the Ostrich, my level is {Level}.";
        }

        public override int Power => Level * 4;

        public override string Info => $"{Name} [{Level}]";

        public override string ToString() => "O"; // Struś reprezentowany jako "O"
    }
}
