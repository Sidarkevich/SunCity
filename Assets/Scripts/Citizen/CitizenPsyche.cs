using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CitizenPsyche : MonoBehaviour
{
    public enum PsycheStatus
    {
        Happy,
        Undecided,
        Sad
    }

    [HideInInspector] public UnityEvent<PsycheStatus> PsycheStatusUpdateEvent;

    private int _happinessPoints;
    private PsycheStatus _psycheStatus;

    public int HappinessPoints
    {
        get => _happinessPoints;
        set
        {
            if (value > 7)
            {
                _psycheStatus = PsycheStatus.Happy;
                PsycheStatusUpdateEvent?.Invoke(_psycheStatus);
            }
            else if ( value > 5)
            {
                _psycheStatus = PsycheStatus.Undecided;
                PsycheStatusUpdateEvent?.Invoke(_psycheStatus);
            }
            else
            {
                _psycheStatus = PsycheStatus.Sad;
                PsycheStatusUpdateEvent?.Invoke(_psycheStatus);
            }

            _happinessPoints = value;
        }
    }
}
