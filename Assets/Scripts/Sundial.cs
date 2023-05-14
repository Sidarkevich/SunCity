using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sundial : MonoBehaviour
{
    public UnityEvent<int> SecondPassedEvent;
    public UnityEvent<int> FiveSecondsPassedEvent;
    public UnityEvent<int> TenSecondsPassedEvent;

    private int _timeFromStart;

    private void Start()
    {
        StarClock();
    }

    public void StarClock()
    {
        _timeFromStart = 0;

        StartCoroutine(SecondCoroutine());
    }

    public void StopClock()
    {
        StopAllCoroutines();
    }

    private IEnumerator SecondCoroutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);

            _timeFromStart++;
            SecondPassedEvent?.Invoke(_timeFromStart);

            if (_timeFromStart % 5 == 0)
            {
                FiveSecondsPassedEvent?.Invoke(_timeFromStart);
            }

            if (_timeFromStart % 10 == 0)
            {
                TenSecondsPassedEvent?.Invoke(_timeFromStart);
            }
        }
    } 
}
