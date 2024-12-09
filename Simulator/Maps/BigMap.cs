using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
    public class BigMap : Map
    {
        private Dictionary<Point, List<IMappable>> _mapData;

        public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            _mapData = new Dictionary<Point, List<IMappable>>();
        }

        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
        }

        public void Add(Point p, IMappable item)
        {
            if (Exist(p))
            {
                if (!_mapData.ContainsKey(p))
                {
                    _mapData[p] = new List<IMappable>();
                }
                _mapData[p].Add(item);
            }
            else
            {
                throw new ArgumentException("Punkt nie znajduje się na mapie.");
            }
        }

        public void Remove(Point p, IMappable item)
        {
            if (_mapData.ContainsKey(p))
            {
                var list = _mapData[p];
                if (list.Contains(item))
                {
                    list.Remove(item);
                    if (list.Count == 0)
                    {
                        _mapData.Remove(p);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Punkt nie zawiera obiektu do usunięcia.");
            }
        }

        public List<IMappable> At(Point p)
        {
            if (_mapData.ContainsKey(p))
            {
                return _mapData[p];
            }
            return new List<IMappable>();
        }

        public override Point Next(Point p, Direction d)
        {
            Point nextPoint = p;

            switch (d)
            {
                case Direction.Up:
                    nextPoint = new Point(p.X, p.Y - 1);
                    break;
                case Direction.Down:
                    nextPoint = new Point(p.X, p.Y + 1);
                    break;
                case Direction.Left:
                    nextPoint = new Point(p.X - 1, p.Y);
                    break;
                case Direction.Right:
                    nextPoint = new Point(p.X + 1, p.Y);
                    break;
            }

            return Exist(nextPoint) ? nextPoint : p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            throw new NotImplementedException("Diagonals are not implemented for this map.");
        }
    }
}
