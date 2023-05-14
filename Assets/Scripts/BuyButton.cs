using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuyButton : MonoBehaviour
{
    public UnityEvent WasBoughtEvent;

    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _price;

    private void OnMouseUpAsButton()
    {
        if (_wallet.SpendMoney(_price))
        {
            WasBoughtEvent?.Invoke();
        }
    }
}
