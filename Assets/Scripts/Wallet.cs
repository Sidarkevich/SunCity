using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private AudioManager _manager;

    private int _value;

    public void AddMoney(int value)
    {
        _value += value;
        _text.text = _value.ToString();
        _manager.PlayMoney();
    }

    public bool SpendMoney(int value)
    {
        if (_value - value >= 0)
        {
            _value -= value;
            _text.text = _value.ToString();
            _manager.PlayMoney();
            return true;
        }
        else
            return false;
    }

    private void Start()
    {
        _text.text = _value.ToString();
    }
}
