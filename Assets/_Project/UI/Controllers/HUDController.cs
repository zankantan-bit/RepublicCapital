using RepublicCapital.Common;
using RepublicCapital.Core.Logging;
using RepublicCapital.Core.Services;
using RepublicCapital.Gameplay.Core;
using RepublicCapital.Gameplay.Time;
using UnityEngine;
using UnityEngine.UIElements;

namespace RepublicCapital.UI.Controllers
{
    public class HUDController : MonoBehaviour
    {
        private Label _dateLabel;
        private Label _moneyLabel;
        private Label _populationLabel;
        private Button _nextTurnButton;

        private GameState _gameState;
        private TimeManager _timeManager;
        private TurnManager _turnManager;

        private void OnEnable()
        {
            var document = GetComponent<UIDocument>();

            Debug.Log(document == null ? "UIDocument = NULL" : "UIDocument = OK");

            if (document == null)
                return;

            var root = document.rootVisualElement;

            Debug.Log(root == null ? "Root = NULL" : "Root = OK");

            if (root == null)
                return;

            _dateLabel = root.Q<Label>("DateLabel");
            _moneyLabel = root.Q<Label>("MoneyLabel");
            _populationLabel = root.Q<Label>("PopulationLabel");
            _nextTurnButton = root.Q<Button>("NextTurnButton");

            Debug.Log(_dateLabel == null ? "DateLabel = NULL" : "DateLabel = OK");
            Debug.Log(_moneyLabel == null ? "MoneyLabel = NULL" : "MoneyLabel = OK");
            Debug.Log(_populationLabel == null ? "PopulationLabel = NULL" : "PopulationLabel = OK");
            Debug.Log(_nextTurnButton == null ? "NextTurnButton = NULL" : "NextTurnButton = OK");

            _gameState = ServiceLocator.Get<GameState>();
            _timeManager = ServiceLocator.Get<TimeManager>();
            _turnManager = ServiceLocator.Get<TurnManager>();

            Refresh();

            _nextTurnButton.clicked += OnNextTurnClicked;

            GameEvents.OnDateChanged += Refresh;
        }

        private void OnDisable()
        {
            if (_nextTurnButton != null)
                _nextTurnButton.clicked -= OnNextTurnClicked;

            GameEvents.OnDateChanged -= Refresh;
        }

        private void OnNextTurnClicked()
        {
            _turnManager.NextTurn();
            RCLogger.Log("NEXT TURN");
        }

        private void Refresh()
        {
            _dateLabel.text = _timeManager.CurrentDateString;
            _moneyLabel.text = $"{_gameState.Money:N0}";
            _populationLabel.text = $"{_gameState.Population:N0}";
        }
    }
}