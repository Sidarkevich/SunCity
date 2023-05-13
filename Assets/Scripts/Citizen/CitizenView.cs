using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenView : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private SpriteRenderer _sprite;

    public void UpdateView(CitizenPsyche.PsycheStatus status)
    {
        _sprite.color = _colors[(int)status];
    }
}
