using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AimLookAt : MonoBehaviour
{
    GameObject _mainCamera;
    Transform _aimLookAtMainCamera;


    private void Awake()
    {
        if (_mainCamera == null) _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        _aimLookAtMainCamera = _mainCamera.transform.Find("AimLookAtMainCamera");
    }

    void Update()
    {
        transform.position = _aimLookAtMainCamera.position;
        transform.rotation = _aimLookAtMainCamera.rotation;
    }
}
