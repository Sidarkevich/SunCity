using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyMaker : MonoBehaviour
{
    [SerializeField] private int _placeCost;
    [SerializeField] private int _effectCount;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var _citizens = collider.GetComponent<Citizen>();

        if (_citizens)
        {
            _citizens.Psyche.HappinessPoints += _effectCount;
        }
    }
}
