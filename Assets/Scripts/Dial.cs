using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dial : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private const int _secondsMinCount = 60;

    public void OnSecondPassed(int secondsValue)
    {
        int minutes = secondsValue / _secondsMinCount;
        int sec = secondsValue % _secondsMinCount;

        _text.text = ($"{minutes.ToString("D2")} : {sec.ToString("D2")}");
    }
}
