using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Insulator : MonoBehaviour
{
    [SerializeField] private IsolationZone[] _zones;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Image _energyBar;
 
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
}
