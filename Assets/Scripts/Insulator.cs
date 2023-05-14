using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Insulator : MonoBehaviour
{
    [SerializeField] private AudioManager _manager;
    [SerializeField] private IsolationZone[] _zones;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Image _energyBar;
    [SerializeField] private CitizenSpawner _spawner;

    [SerializeField] private Animation _animation;

    private int _energyValue = 24;
    private int _maxEnergy = 24;
 
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
            var escaped = 0;

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

                    escaped ++;
                }
            }

            if (escaped > 0)
            {
                _manager.PlayEscape();
                _animation["EscapeAnim"].wrapMode = WrapMode.Once;
                _animation.Play();
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
