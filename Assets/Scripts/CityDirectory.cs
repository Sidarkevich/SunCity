using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityDirectory : MonoBehaviour
{
    [SerializeField] private InterestZone[] _interests;

    public Vector3 GetRandomInterest()
    {
        return _interests[UnityEngine.Random.Range(0, _interests.Length)].GetZonePosition();
    }
}
