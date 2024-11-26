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
            // Inicjalizacja danych symulacji
            SmallSquareMap map = new(5); // Mapa o rozmiarze 5x5
            List<Creature> creatures = new() { new Orc("Gorbag"), new Elf("Elandor") }; // Stwory: Orc i Elf
            List<Point> points = new() { new Point(2, 2), new Point(3, 1) }; // Początkowe pozycje stworów
            string moves = "dlrludl"; // Ruchy: Down, Left, Right, Left, Up, Down, Left

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
