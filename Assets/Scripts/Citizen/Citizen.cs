using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Citizen : MonoBehaviour
{
    public bool IsInIsolation = false;

    [SerializeField] private CityDirectory _directory;

    [SerializeField] private CitizenMovement _movement;
    [SerializeField] private CitizenPsyche _psyche;
    [SerializeField] private CitizenView _view;

    [SerializeField] private float _maxWaitTime;

    private Citizen _companion;

    private void Awake()
    {
        _directory = GameObject.FindAnyObjectByType<CityDirectory>();
    }

    private void Start()
    {
        _movement.StartMovingEvent.AddListener(OnStartMoving);
        _movement.FinishMovingEvent.AddListener(OnFinishMoving);

        _psyche.PsycheStatusUpdateEvent.AddListener(OnPsycheStatusUpdate);
        OnPsycheStatusUpdate(_psyche.Status);

        _movement.SetTarget(_directory.GetInterest());
    }
    private void OnStartMoving()
    {
        
    }

    private void OnFinishMoving()
    {
        StartCoroutine(WaitingCoroutine(Random.Range(0, _maxWaitTime), () => _movement.SetTarget(_directory.GetInterest()) ));
    }

    private void OnPsycheStatusUpdate(CitizenPsyche.PsycheStatus status)
    {
        if (status == CitizenPsyche.PsycheStatus.Sad)
        {
            _movement.ChangeSpeed(1.5f);
        }
        else
        {
            _movement.ChangeSpeed(1.0f);
        }

        _view.UpdateView(status);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var newCompanion = collider.GetComponent<Citizen>();
        if (!newCompanion)
        {
            return;
        }

        if (_companion)
        {
            if (newCompanion == _companion)
            {
                newCompanion._companion = null;
                _companion = null;
            }

            return;
        }

        if (newCompanion._companion)
        {
            return;
        }

        _companion = newCompanion;
        newCompanion._companion = this;

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

        if (citizen && (_companion == citizen))
        {
            citizen._companion = null;
            _companion = null;
        }
    }

    private IEnumerator WaitingCoroutine(float time, UnityAction callback)
    {
        yield return new WaitForSeconds(time);

        callback?.Invoke();
    }

    public void HandleOn()
    {
        _movement.enabled = false;
    }

    public void HandleOff()
    {
        if (!IsInIsolation)
            _movement.enabled = true;
    }
}
