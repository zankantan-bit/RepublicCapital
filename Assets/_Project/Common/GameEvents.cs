using System;

namespace RepublicCapital.Common
{
    public static class GameEvents
    {
        public static event Action OnDateChanged;

        public static void RaiseDateChanged()
        {
            OnDateChanged?.Invoke();
        }
    }
}