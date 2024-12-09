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
            BigBounceMap map = new(8, 6); // Mapa o rozmiarze 8x6

            // Stwory: Ork, Elf, Królik, Orzeł, Struś
            List<Creature> creatures = new()
            {
                new Orc("Gorbag", 3),          // Ork
                new Elf("Elandor", 4),         // Elf
                new Rabbit("Bunny", 2),        // Królik
                new Eagle("Eagle", 5),         // Orzeł
                new Ostrich("Ostrich", 3)      // Struś
            };

            // Początkowe pozycje stworów
            List<Point> points = new()
            {
                new Point(2, 2),  // Ork
                new Point(3, 1),  // Elf
                new Point(4, 4),  // Królik
                new Point(1, 0),  // Orzeł
                new Point(7, 2)   // Struś
            };

            // Ruchy: Down, Left, Right, Left, Up, Down, Left
            string moves = "dddddddddddddddlllllllllllllllllldddddddd";

            // Utworzenie symulacji
            Simulation simulation = new(map, creatures, points, moves);

            // Utworzenie wizualizacji mapy
            MapVisualizer mapVisualizer = new(map, creatures, points);

            // Główna pętla symulacji
            while (!simulation.Finished)
            {
                mapVisualizer.Draw();
                simulation.Turn();
                System.Threading.Thread.Sleep(500); // Opóźnienie dla efektu animacji
            }

            Console.WriteLine("Symulacja zakończona!");
        }
    }
}
