using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CitizenTracker : MonoBehaviour
{
    private List<Citizen> _citizens = new List<Citizen>();
    private int _sadCount;

    [SerializeField] private TMP_Text _happyText;
    [SerializeField] private TMP_Text _sadText;

    public void Registry(Citizen citizen)
    {
        _citizens.Add(citizen);
        citizen.Psyche.PsycheStatusUpdateEvent.AddListener((OnPsycheStatusUpdate));
        Track();
        UpdateTrackers();
    }

    private void OnPsycheStatusUpdate(CitizenPsyche.PsycheStatus status)
    {
        Track();
        UpdateTrackers();
    }

    private void Track()
    {
        _sadCount = 0;

        foreach (var citizen in _citizens)
        {
            if (citizen.Psyche.IsSad())
            {
                _sadCount++;
            }
        }
    }

    private void UpdateTrackers()
    {
        _happyText.text = (_citizens.Count - _sadCount).ToString();
        _sadText.text = _sadCount.ToString();
    }
}
