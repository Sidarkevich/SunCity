using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityDirectory : MonoBehaviour
{
    [SerializeField] private InterestZone[] _interests;

    public Vector3 GetRandomInterest()
    {
        return _interests[Random.Range(0, _interests.Length)].GetZonePosition();
    }

    public Vector3 GetInterest()
    {
        var totalInterest = 0;
        foreach (var zone in _interests)
        {
            totalInterest += zone.Interest;
        }

        var randomNumber = Random.Range(1, totalInterest + 1);
        var position = 0;

        for (int i = 0; i < _interests.Length; i++)
        {
            var zone = _interests[i];
            if (randomNumber <= zone.Interest + position)
            {
                return zone.GetZonePosition();
            }

            position += zone.Interest;
        }

        return Vector3.zero;
    }
}
