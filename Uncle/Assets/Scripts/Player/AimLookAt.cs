using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLookAt : MonoBehaviour
{
    GameObject _mainCamera;


    private void Awake()
    {
        if (_mainCamera == null) _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Start()
    {
        transform.parent = _mainCamera.transform;
        transform.position = new Vector3(0, 0, 20);
    }
}
