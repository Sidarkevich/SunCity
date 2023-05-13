using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    [SerializeField] private CityDirectory _directory;

    [SerializeField] private CitizenMovement _movement;
    [SerializeField] private CitizenPsyche _psyche;
    [SerializeField] private CitizenView _view;

    private Status _status;

    public enum Status
    {
        Free,
        Walking,
        Waiting
    }

    private void Start()
    {
        _movement.StartMovingEvent.AddListener(OnStartMoving);
        _movement.FinishMovingEvent.AddListener(OnFinishMoving);

        _psyche.PsycheStatusUpdateEvent.AddListener(OnPsycheStatusUpdate);
        _psyche.HappinessPoints = UnityEngine.Random.Range(1, 11);

        _movement.SetTarget(_directory.GetRandomInterest());
    }
    private void OnStartMoving()
    {
        _status = Status.Walking;
    }

    private void OnFinishMoving()
    {
        _status = Status.Free;

        _movement.SetTarget(_directory.GetRandomInterest());
    }

    private void OnPsycheStatusUpdate(CitizenPsyche.PsycheStatus status)
    {
        _view.UpdateView(status);
    }
}
