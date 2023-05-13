using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CitizenMovement : MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Awake()
    {
		_agent = GetComponent<NavMeshAgent>();
		_agent.updateRotation = false;
		_agent.updateUpAxis = false;      
    }

    public void SetTarget(Vector3 targetPos)
    {
        _agent.SetDestination(targetPos);
    }
}
