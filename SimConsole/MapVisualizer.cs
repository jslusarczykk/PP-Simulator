using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Simulator
{
    public class MapVisualizer
    {
        private readonly Map _map;
        private readonly List<Point> _positions;
        private readonly List<Creature> _creatures;

        public MapVisualizer(Map map, List<Creature> creatures, List<Point> positions)
        {
            _map = map;
            _positions = positions;
            _creatures = creatures;
        }

        public void Draw()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;

            for (int y = 0; y < _map.SizeY; y++)
            {
                for (int x = 0; x < _map.SizeX; x++)
                {
                    Point currentPoint = new Point(x, y);

                    // Sprawdź, czy na danym polu znajdują się stworzenia
                    var creaturesAtPoint = GetCreaturesAtPoint(currentPoint);

                    if (creaturesAtPoint.Count > 1)
                    {
                        Console.Write("X"); // Więcej niż jeden stwór
                    }
                    else if (creaturesAtPoint.Count == 1)
                    {
                        // Reprezentacja stworków
                        if (creaturesAtPoint[0] is Orc)
                        {
                            Console.Write("O"); // Orc → O
                        }
                        else if (creaturesAtPoint[0] is Elf)
                        {
                            Console.Write("E"); // Elf → E
                        }
                        else if (creaturesAtPoint[0] is Eagle)
                        {
                            Console.Write("A"); // Eagle → A
                        }
                        else if (creaturesAtPoint[0] is Rabbit)
                        {
                            Console.Write("R"); // Rabbit → R
                        }
                        else if (creaturesAtPoint[0] is Ostrich)
                        {
                            Console.Write("S"); // Ostrich → S
                        }
                    }
                    else
                    {
                        Console.Write(Box.Horizontal); // Puste pole
                    }
                }
                Console.WriteLine();
            }
        }


        private List<Creature> GetCreaturesAtPoint(Point point)
        {
            var creaturesAtPoint = new List<Creature>();

            for (int i = 0; i < _positions.Count; i++)
            {
                if (_positions[i] == point)
                {
                    creaturesAtPoint.Add(_creatures[i]);
                }
            }

            return creaturesAtPoint;
        }
    }
}
