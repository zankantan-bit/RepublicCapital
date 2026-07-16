using RepublicCapital.Gameplay.Core;

namespace RepublicCapital.Gameplay.Economy
{
    public class EconomyManager
    {
        private readonly GameState _gameState;

        public EconomyManager(GameState gameState)
        {
            _gameState = gameState;
        }

        public void ProcessTurn()
        {
            int income = (int)(_gameState.Population * _gameState.TaxRate);

            int expenses = _gameState.Population * 8;

            _gameState.Money += income - expenses;
        }
    }
}