using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField] private AudioClip _moneyClip;
    [SerializeField] private AudioClip _lossClip;
    [SerializeField] private AudioClip _clickClip;
    [SerializeField] private AudioClip _escapeClip;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlayMoney()
    {
        _source.clip = _moneyClip;
        _source.Play();
    }

    public void PlayLoss()
    {
        _source.clip = _lossClip;
        _source.Play();
    }

    public void PlayClick()
    {
        _source.clip = _clickClip;
        _source.Play();
    }

    public void PlayEscape()
    {
        _source.clip = _escapeClip;
        _source.Play();
    }
}
