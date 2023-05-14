using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuyButton : MonoBehaviour
{
    public UnityEvent WasBoughtEvent;

    private Wallet _wallet;
    [SerializeField] private int _price;

    private void Start()
    {
        _wallet = GameObject.FindObjectOfType<Wallet>();
    }

    public void OnClick()
    {
        if (_wallet.SpendMoney(_price))
        {
            WasBoughtEvent?.Invoke();
        }
    }
}
