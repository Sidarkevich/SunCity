using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _citizen;
    [SerializeField] private Transform _citizensParent;

    public void OnTenSecondsPassed(int secondsValue)
    {
        SpawnCitizen();
    }

    private void SpawnCitizen()
    {
        var randomPos = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)].position;
        var newCitizen = Instantiate(_citizen, randomPos, Quaternion.identity);
        newCitizen.transform.SetParent(_citizensParent);
    }
}
