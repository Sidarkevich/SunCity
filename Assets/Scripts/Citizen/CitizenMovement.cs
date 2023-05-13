using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CitizenMovement : MonoBehaviour
{
    [HideInInspector] public UnityEvent StartMovingEvent;
    [HideInInspector] public UnityEvent FinishMovingEvent; 

    private NavMeshAgent _agent;
    private bool _needCheck;

    public void SetTarget(Vector3 targetPos)
    {
        _agent.SetDestination(targetPos);
        _needCheck = true;
        StartMovingEvent?.Invoke();
    }

    private void Awake()
    {
		_agent = GetComponent<NavMeshAgent>();
		_agent.updateRotation = false;
		_agent.updateUpAxis = false;      
    }

    private void Update()
    {
        if (!_needCheck)
        {
            return;
        }

        if (_agent.remainingDistance <= 0.2f)
        {
            _needCheck = false;
            FinishMovingEvent?.Invoke();
        }
    }
}
