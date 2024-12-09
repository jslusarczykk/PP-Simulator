namespace Simulator
{
    public class Rabbit : Creature
    {
        public Rabbit(string name = "Unknown", int level = 1) : base(name, level) { }

        public override string Greeting()
        {
            return $"Hi, I'm {Name} the Rabbit, my level is {Level}.";
        }

        public override int Power => Level * 5;

        public override string Info => $"{Name} [{Level}]";

        public override string ToString() => "R"; // Królik reprezentowany jako "R"
    }
}
