using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsolationZone : MonoBehaviour
{
    private Citizen _currentUser;
    public Citizen User
    {
        get => _currentUser;
        set 
        {
            _currentUser = value;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var visitor = collider.GetComponent<Citizen>();

        if (!visitor)
        {
            return;
        }

        if (_currentUser)
        {
            return;
        }

        _currentUser = visitor;
        visitor.IsInIsolation = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        var visitor = collider.GetComponent<Citizen>();
        
        if (!visitor)
        {
            return;
        }

        if (visitor == _currentUser)
        {
            _currentUser = null;
            visitor.IsInIsolation = false;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        
    }
}
