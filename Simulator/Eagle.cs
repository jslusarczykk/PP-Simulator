namespace Simulator
{
    public class Eagle : Creature
    {
        public Eagle(string name = "Unknown", int level = 1) : base(name, level) { }

        public override string Greeting()
        {
            return $"Hi, I'm {Name} the Eagle, my level is {Level}.";
        }

        public override int Power => Level * 6;

        public override string Info => $"{Name} [{Level}]";

        public override string ToString() => "A"; // Orzeł reprezentowany jako "A"
    }
}
