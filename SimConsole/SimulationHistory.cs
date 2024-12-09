using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator
{
    public class SimulationHistory
    {
        private readonly Simulation _simulation; // Oryginalna symulacja
        private readonly List<SimulationStep> _history = new(); // Historia kroków symulacji

        public SimulationHistory(Simulation simulation)
        {
            _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
            RecordInitialStep(); // Zapisz stan początkowy
        }

        // Rejestruje początkowy stan symulacji
        private void RecordInitialStep()
        {
            _history.Add(new SimulationStep
            {
                TurnNumber = 0,
                Positions = new List<Point>(_simulation.Positions),
                CurrentCreature = _simulation.CurrentCreature.Name,
                CurrentMove = "None"
            });
        }

        // Uruchamia symulację i zapisuje historię
        public void RunAndRecord()
        {
            while (!_simulation.Finished)
            {
                var currentCreature = _simulation.CurrentCreature.Name;
                var currentMove = _simulation.CurrentMoveName;

                _simulation.Turn();

                // Po wykonaniu tury, zapisz jej wynik
                _history.Add(new SimulationStep
                {
                    TurnNumber = _history.Count,
                    Positions = new List<Point>(_simulation.Positions),
                    CurrentCreature = currentCreature,
                    CurrentMove = currentMove
                });
            }
        }

        // Pobiera stan symulacji dla określonej tury
        public SimulationStep GetStep(int turnNumber)
        {
            if (turnNumber < 0 || turnNumber >= _history.Count)
                throw new ArgumentOutOfRangeException($"Tura {turnNumber} nie istnieje.");
            return _history[turnNumber];
        }
    }

    // Klasa reprezentująca pojedynczy krok symulacji
    public class SimulationStep
    {
        public int TurnNumber { get; set; } // Numer tury
        public List<Point> Positions { get; set; } // Pozycje stworzeń na mapie
        public string CurrentCreature { get; set; } // Nazwa stworzenia, które wykonało ruch
        public string CurrentMove { get; set; } // Ruch wykonany przez stworzenie
    }
}
