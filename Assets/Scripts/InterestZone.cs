using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestZone : MonoBehaviour
{
    [SerializeField] private int _interest;
    
    public Vector3 GetZonePosition()
    {
        return transform.position;
    }
}
