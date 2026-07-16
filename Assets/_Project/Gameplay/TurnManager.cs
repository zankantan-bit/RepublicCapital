using RepublicCapital.Common;
using RepublicCapital.Gameplay.Economy;
using RepublicCapital.Gameplay.Population;

namespace RepublicCapital.Gameplay.Time
{
    public class TurnManager
    {
        private readonly TimeManager _timeManager;
        private readonly EconomyManager _economyManager;
        private readonly PopulationManager _populationManager;

        public TurnManager(
            TimeManager timeManager,
            EconomyManager economyManager,
            PopulationManager populationManager)
        {
            _timeManager = timeManager;
            _economyManager = economyManager;
            _populationManager = populationManager;
        }

        public void NextTurn()
        {
            _timeManager.NextTurn();

            _economyManager.ProcessTurn();

            _populationManager.ProcessTurn();

            GameEvents.RaiseDateChanged();
        }
    }
}