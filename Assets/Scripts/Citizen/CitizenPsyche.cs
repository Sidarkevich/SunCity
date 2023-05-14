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

    [SerializeField] private int _happinessPoints = -1;
    private PsycheStatus _psycheStatus;

    public PsycheStatus Status
    {
        get => _psycheStatus;
        set
        {
            _psycheStatus = value;
            PsycheStatusUpdateEvent?.Invoke(_psycheStatus);
        }
    }

    public int HappinessPoints
    {
        get => _happinessPoints;
        set
        {
            if (value > 10)
                value = 10;
            if (value < 1)
                value = 1;

            _happinessPoints = value;

            if (_happinessPoints > 7)
            {
                Status = PsycheStatus.Happy;
            }
            else if (_happinessPoints > 5)
            {
                Status = PsycheStatus.Undecided;
            }
            else
            {
                Status = PsycheStatus.Sad;
            }
        }
    }

    public bool IsSad()
    {
        return (Status == PsycheStatus.Sad);
    }

    private void Awake()
    {
        if (_happinessPoints == -1)
            HappinessPoints = Random.Range(1, 7);
    }
}
