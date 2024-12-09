using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SimConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicjalizacja mapy odbijającej o rozmiarze 8x6
            BigBounceMap map = new(8, 6);

            // Stwory: Ork, Elf, Królik, Orzeł, Struś
            List<Creature> creatures = new()
            {
                new Orc("Gorbag", 3),
                new Elf("Elandor", 4),
                new Rabbit("Bunny", 2),
                new Eagle("Aquila", 5),
                new Ostrich("Struthio", 3)
            };

            // Początkowe pozycje stworów
            List<Point> points = new()
            {
                new Point(2, 2),
                new Point(3, 1),
                new Point(4, 4),
                new Point(1, 0),
                new Point(7, 2)
            };
            string moves = "dddddddddddddddlllllllllllllllllldddddddd";

            Simulation simulation = new(map, creatures, points, moves);

            // Utworzenie historii symulacji
            SimulationHistory history = new(simulation);

            // Uruchom symulację i zapisz historię
            history.RunAndRecord();

            // Wyświetlenie wybranych tur
            foreach (int turn in new[] { 5, 10, 15, 20 })
            {
                Console.WriteLine($"=== Tura {turn} ===");
                var step = history.GetStep(turn);

                Console.WriteLine($"Ruch wykonał: {step.CurrentCreature} -> {step.CurrentMove}");
                for (int i = 0; i < creatures.Count; i++)
                {
                    Console.WriteLine($"{creatures[i].Name}: Pozycja {step.Positions[i]}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Symulacja zakończona!");
        }
    }
}
