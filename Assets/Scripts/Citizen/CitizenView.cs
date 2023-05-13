using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenView : MonoBehaviour
{
    [SerializeField] private Sprite[] _masks;
    [SerializeField] private SpriteRenderer _sprite;

    public void UpdateView(CitizenPsyche.PsycheStatus status)
    {
        _sprite.sprite = _masks[(int)status];
    }
}
