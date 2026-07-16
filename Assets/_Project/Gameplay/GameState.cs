namespace RepublicCapital.Gameplay.Core
{
    public class GameState
    {
        // Economy
        public int Money { get; set; }
        public int Population { get; set; }

        // Time
        public int Year { get; set; }
        public int Month { get; set; }

        // Government
        public float TaxRate { get; set; }

        // Society
        public float Happiness { get; set; }
        public float Employment { get; set; }

        // Economy Indicators
        public float Inflation { get; set; }
    }
}