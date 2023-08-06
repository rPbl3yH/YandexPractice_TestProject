using System;
using App;
using TMPro;
using UnityEngine;

namespace Game.Money
{
    public class MoneyView : MonoBehaviour, IGameInitListener
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private MoneyStorage _moneyStorage;

        public void OnGameInit()
        {
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }

        private void OnMoneyChanged(int money)
        {
            _text.text = money.ToString();
        }

        private void OnDestroy()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }
    }
}