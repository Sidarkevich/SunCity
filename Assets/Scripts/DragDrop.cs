using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [SerializeField] private Citizen _citizen;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        _citizen.HandleOn();
    }

    private void OnMouseDrag()
    {
        transform.position = _mainCamera.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);
    }

    private void OnMouseUp()
    {
        _citizen.HandleOff();
    }
}
