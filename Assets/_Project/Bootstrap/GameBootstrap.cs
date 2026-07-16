using UnityEngine;
using RepublicCapital.Core.Logging;
using RepublicCapital.Core.Services;
using RepublicCapital.Core.Configuration;
using RepublicCapital.Gameplay.Core;
using RepublicCapital.Gameplay.Time;

namespace RepublicCapital.Bootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            RCLogger.Log("Bootstrap Started");

            // Game Configuration
            var config = new GameConfig();
            ServiceLocator.Register(config);
            RCLogger.Log("GameConfig Registered");

            // Game State
            var state = new GameState
            {
                Money = config.StartingMoney,
                Population = config.StartingPopulation,
                Year = config.StartingYear,
                Month = config.StartingMonth
            };

            ServiceLocator.Register(state);
            RCLogger.Log("GameState Registered");

            // Time Manager
            var timeManager = new TimeManager(state);
            ServiceLocator.Register(timeManager);
            RCLogger.Log("TimeManager Registered");

            // Debug Information
            RCLogger.Log($"Money : {state.Money:N0}");
            RCLogger.Log($"Population : {state.Population:N0}");
            RCLogger.Log($"Date : {timeManager.CurrentDateString}");
        }
    }
}