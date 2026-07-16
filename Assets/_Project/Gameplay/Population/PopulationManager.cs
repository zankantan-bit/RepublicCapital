using RepublicCapital.Gameplay.Core;

namespace RepublicCapital.Gameplay.Population
{
    public class PopulationManager
    {
        private readonly GameState _gameState;

        public PopulationManager(GameState gameState)
        {
            _gameState = gameState;
        }

        public void ProcessTurn()
        {
            float growthRate = 0.005f; // %0.5

            int growth = (int)(_gameState.Population * growthRate);

            _gameState.Population += growth;
        }
    }
}