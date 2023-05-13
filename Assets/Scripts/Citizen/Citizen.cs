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
    public Citizen Companion;

    public enum Status
    {
        Free,
        Walking,
        Waiting
    }

    private void Awake()
    {
        _directory = GameObject.FindAnyObjectByType<CityDirectory>();
    }

    private void Start()
    {
        _movement.StartMovingEvent.AddListener(OnStartMoving);
        _movement.FinishMovingEvent.AddListener(OnFinishMoving);

        _psyche.PsycheStatusUpdateEvent.AddListener(OnPsycheStatusUpdate);

        _view.UpdateView(_psyche.Status);

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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var newCompanion = collider.GetComponent<Citizen>();
        if (!newCompanion)
        {
            return;
        }

        if (Companion)
        {
            if (newCompanion == Companion)
            {
                newCompanion.Companion = null;
                Companion = null;
            }

            return;
        }

        if (newCompanion.Companion)
        {
            return;
        }

        Companion = newCompanion;
        newCompanion.Companion = this;

        if (newCompanion._psyche.IsSad() || _psyche.IsSad())
        {
            var newValue = Mathf.Min(newCompanion._psyche.HappinessPoints, _psyche.HappinessPoints);

            newCompanion._psyche.HappinessPoints = newValue;
            _psyche.HappinessPoints = newValue;
        }
        else
        {
            var newValue = (newCompanion._psyche.HappinessPoints + _psyche.HappinessPoints) / 2;

            newCompanion._psyche.HappinessPoints = Mathf.Max(newValue, newCompanion._psyche.HappinessPoints);
            _psyche.HappinessPoints = Mathf.Max(newValue, _psyche.HappinessPoints);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var citizen = collider.GetComponent<Citizen>();

        if (citizen && (Companion == citizen))
        {
            citizen.Companion = null;
            Companion = null;
        }
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
