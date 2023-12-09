using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/*
 * Copia la posición de AimLookAtMainCamera, hijo de MainCamera, en AimLookAt del prefab del player.
 * Para que el arma siempre apunte hacia la mira.
 */
public class AimLookAt : MonoBehaviour
{
    GameObject _mainCamera;
    Transform _aimLookAtMainCamera;
    public float smoothingSpeed = 5f;

    private void Awake()
    {
        if (_mainCamera == null) _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        _aimLookAtMainCamera = _mainCamera.transform.Find("AimLookAtMainCamera");
    }

    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, _aimLookAtMainCamera.position, smoothingSpeed  * Time.deltaTime);
        transform.position = _aimLookAtMainCamera.position;
        //transform.rotation = _aimLookAtMainCamera.rotation;
    }
}
