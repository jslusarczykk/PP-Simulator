using System;
using System.Collections.Generic;
using System.Drawing;
using Simulator.Maps;

namespace Simulator
{
    public class Simulation
    {
        /// <summary>
        /// Simulation's map.
        /// </summary>
        public Map Map { get; }

        /// <summary>
        /// Creatures moving on the map.
        /// </summary>
        public List<Creature> Creatures { get; }

        /// <summary>
        /// Starting positions of creatures.
        /// </summary>
        public List<Point> Positions { get; }

        /// <summary>
        /// Cyclic list of creatures' moves. 
        /// Bad moves are ignored - use DirectionParser.
        /// First move is for first creature, second for second, and so on.
        /// When all creatures make moves, the next move is again for the first creature and so on.
        /// </summary>
        public string Moves { get; }

        /// <summary>
        /// Has all moves been completed?
        /// </summary>
        public bool Finished { get; private set; } = false;

        private int currentTurn = 0;

        /// <summary>
        /// Creature which will be moving during the current turn.
        /// </summary>
        public Creature CurrentCreature
        {
            get
            {
                if (Creatures.Count == 0)
                    throw new InvalidOperationException("No creatures in the simulation.");
                return Creatures[currentTurn % Creatures.Count];
            }
        }

        /// <summary>
        /// Lowercase name of the direction which will be used in the current turn.
        /// </summary>
        public string CurrentMoveName
        {
            get
            {
                if (string.IsNullOrEmpty(Moves))
                    throw new InvalidOperationException("No moves available in the simulation.");
                return Moves[currentTurn % Moves.Length].ToString().ToLower();
            }
        }

        /// <summary>
        /// Simulation constructor.
        /// Throws errors:
        /// - If the creatures' list is empty.
        /// - If the number of creatures differs from the number of starting positions.
        /// </summary>
        public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
        {
            if (creatures == null || creatures.Count == 0)
                throw new ArgumentException("Creatures list cannot be empty.", nameof(creatures));
            if (positions == null || positions.Count != creatures.Count)
                throw new ArgumentException("Number of starting positions must match the number of creatures.", nameof(positions));
            if (string.IsNullOrWhiteSpace(moves))
                throw new ArgumentException("Moves cannot be null or empty.", nameof(moves));

            Map = map ?? throw new ArgumentNullException(nameof(map));
            Creatures = creatures;
            Positions = positions;
            Moves = moves;

            // Validate starting positions
            foreach (var position in positions)
            {
                if (!map.Exist(position))
                    throw new ArgumentException($"Invalid starting position: {position} is out of map bounds.");
            }
        }

        /// <summary>
        /// Makes one move for the current creature in the current direction.
        /// Throws an error if the simulation is finished.
        /// </summary>
        public void Turn()
        {
            if (Finished)
                throw new InvalidOperationException("Simulation is already finished.");

            // Pobierz aktualnego stworzenia i ruch
            var creature = CurrentCreature;
            var move = CurrentMoveName;

            // Parsowanie kierunku przy użyciu DirectionParser
            Direction direction;
            try
            {
                direction = DirectionParser.Parse(move); // Użycie klasy DirectionParser
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message); // Wypisz informację o błędnym ruchu
                currentTurn++;
                return; // Pominięcie tej tury
            }

            // Pobierz aktualną pozycję stworzenia
            var creatureIndex = currentTurn % Creatures.Count;
            var currentPosition = Positions[creatureIndex];

            // Oblicz następną pozycję na mapie
            var nextPosition = Map.Next(currentPosition, direction);

            // Zaktualizuj pozycję, jeśli jest poprawna
            if (Map.Exist(nextPosition))
            {
                Positions[creatureIndex] = nextPosition;
                Console.WriteLine($"Creature {creature.Name} moved from {currentPosition} to {nextPosition}.");
            }
            else
            {
                Console.WriteLine($"Creature {creature.Name} attempted to move out of bounds from {currentPosition}.");
            }

            // Zaktualizuj turę
            currentTurn++;

            // Sprawdź, czy wszystkie ruchy zostały wykonane
            if (currentTurn >= Moves.Length)
            {
                Finished = true;
                Console.WriteLine("Simulation completed.");
            }
        }

    }
}
