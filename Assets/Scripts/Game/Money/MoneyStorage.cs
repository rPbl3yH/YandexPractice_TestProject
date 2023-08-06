using System;
using App;
using UnityEngine;

public class MoneyStorage : MonoBehaviour, IGameInitListener, IGameFinishListener
{
    public event Action<int> OnMoneyChanged;
    
    private int _money;

    public void AddMoney()
    {
        _money++;
        OnMoneyChanged?.Invoke(_money);
    }

    public void OnGameInit()
    {
        OnMoneyChanged?.Invoke(0);
    }

    public void OnGameFinished()
    {
        OnMoneyChanged?.Invoke(0);
    }
}
