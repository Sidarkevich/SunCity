using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenView : MonoBehaviour
{
    [SerializeField] private Sprite[] _masks;
    [SerializeField] private SpriteRenderer _maskSprite;
    [SerializeField] private SpriteRenderer _clothSprite;

    private void Start()
    {
        _clothSprite.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
    }

    public void UpdateView(CitizenPsyche.PsycheStatus status)
    {
        _maskSprite.sprite = _masks[(int)status];
    }
}
