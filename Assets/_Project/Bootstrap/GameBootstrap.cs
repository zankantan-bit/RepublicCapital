using UnityEngine;
using RepublicCapital.Core.Logging;
using RepublicCapital.Core.Services;
using RepublicCapital.Core.Configuration;
using RepublicCapital.Gameplay.Core;

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

            var loadedConfig = ServiceLocator.Get<GameConfig>();

            RCLogger.Log($"Starting Money : {loadedConfig.StartingMoney:N0}");
            RCLogger.Log($"Population : {loadedConfig.StartingPopulation:N0}");
            RCLogger.Log($"Date : {loadedConfig.StartingMonth}/{loadedConfig.StartingYear}");

            // Game State
            var state = new GameState
            {
                Money = loadedConfig.StartingMoney,
                Population = loadedConfig.StartingPopulation,
                Year = loadedConfig.StartingYear,
                Month = loadedConfig.StartingMonth
            };

            ServiceLocator.Register(state);

            RCLogger.Log("GameState Registered");

            var gameState = ServiceLocator.Get<GameState>();

            RCLogger.Log($"Money : {gameState.Money:N0}");
            RCLogger.Log($"Population : {gameState.Population:N0}");
            RCLogger.Log($"Date : {gameState.Month}/{gameState.Year}");
        }
    }
}