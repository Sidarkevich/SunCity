using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Insulator : MonoBehaviour
{
    [SerializeField] private IsolationZone[] _zones;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Image _energyBar;
    [SerializeField] private CitizenSpawner _spawner;

    private int _energyValue = 18;
    private int _maxEnergy = 18;
 
    public void AddEnergy()
    {
        _energyValue = Mathf.Min(_maxEnergy, _energyValue + 3);
        SetupBar();
    }

    public void UseEnergy(int secondsPassed)
    {
        var userCount = 0;
        foreach (var zone in _zones)
        {
            if (zone.User)
            {
                userCount++;
            }
        }

        if (_energyValue - userCount > 0)
        {
            _energyValue -= userCount;

        }
        else
        {
            // THE ESCAPE
            foreach (var zone in _zones)
            {
                if (zone.User)
                {
                    zone.User.IsInIsolation = false;
                    zone.User.transform.position = _spawner.SpawnPoints[Random.Range(0, _spawner.SpawnPoints.Length)].position;
                    zone.User.NeedSavePos = false;
                    zone.User.HandleOff();

                    zone.User = null;
                }
            }

            _energyValue = 0;
        }

        SetupBar();      
    }

    public void GetCash()
    {
        foreach (var zone in _zones)
        {
            if (zone.User)
            {
                if (zone.User.Psyche.IsSad())
                {
                    _wallet.AddMoney(3);
                }
            }
        }
    }

    public void MakeHappy()
    {
        foreach (var zone in _zones)
        {
            if (zone.User)
            {
                zone.User.Psyche.HappinessPoints += 1;
            }
        }
    }

    private void SetupBar()
    {
        float amount = _energyValue / (float)_maxEnergy;
        _energyBar.fillAmount = amount;
    }
}
