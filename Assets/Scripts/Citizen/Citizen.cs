using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    [SerializeField] private CityDirectory _directory;

    [SerializeField] private CitizenMovement _movement;
    [SerializeField] private CitizenPsyche _psyche;
    [SerializeField] private CitizenView _view;

    private void Start()
    {
        _movement.SetTarget(_directory.GetRandomInterest());
    }
}
