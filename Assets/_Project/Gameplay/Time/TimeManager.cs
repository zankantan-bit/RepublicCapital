using System;
using RepublicCapital.Common;
using RepublicCapital.Gameplay.Core;

namespace RepublicCapital.Gameplay.Time
{
    public class TimeManager
    {
        private readonly GameState _gameState;

        public TimeManager(GameState gameState)
        {
            _gameState = gameState;
        }

        public string CurrentDateString =>
            $"{_gameState.Month:00}/{_gameState.Year}";

        public void NextTurn()
        {
            _gameState.Month++;

            if (_gameState.Month > 12)
            {
                _gameState.Month = 1;
                _gameState.Year++;
            }

            GameEvents.RaiseDateChanged();
        }
    }
}