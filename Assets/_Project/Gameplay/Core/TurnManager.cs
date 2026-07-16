using RepublicCapital.Gameplay.Time;

namespace RepublicCapital.Gameplay.Core
{
    public class TurnManager
    {
        private readonly TimeManager _timeManager;

        public TurnManager(TimeManager timeManager)
        {
            _timeManager = timeManager;
        }

        public void NextTurn()
        {
            _timeManager.NextTurn();
        }
    }
}