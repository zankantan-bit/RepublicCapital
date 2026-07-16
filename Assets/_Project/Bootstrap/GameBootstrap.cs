using UnityEngine;
using RepublicCapital.Core.Logging;
using RepublicCapital.Core.Services;
using RepublicCapital.Core.Configuration;
using RepublicCapital.Gameplay.Core;
using RepublicCapital.Gameplay.Time;
using RepublicCapital.Gameplay.Economy;
using RepublicCapital.Gameplay.Population;

namespace RepublicCapital.Bootstrap
{
    [DefaultExecutionOrder(-1000)]
    public class GameBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            RCLogger.Log("Bootstrap Started");

            var config = new GameConfig();
            ServiceLocator.Register(config);

            var state = new GameState
            {
                Money = config.StartingMoney,
                Population = config.StartingPopulation,
                Year = config.StartingYear,
                Month = config.StartingMonth,

                TaxRate = 20f,
                Happiness = 80f,
                Employment = 95f,
                Inflation = 2f
            };

            ServiceLocator.Register(state);

            var timeManager = new TimeManager(state);
            ServiceLocator.Register(timeManager);

            var economyManager = new EconomyManager(state);
            ServiceLocator.Register(economyManager);

            var populationManager = new PopulationManager(state);
            ServiceLocator.Register(populationManager);

            var turnManager = new TurnManager(
                timeManager,
                economyManager,
                populationManager);

            ServiceLocator.Register(turnManager);

            RCLogger.Log("Bootstrap Completed");
        }
    }
}