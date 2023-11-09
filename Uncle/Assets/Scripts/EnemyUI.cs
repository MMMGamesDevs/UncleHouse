using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    public Transform mainCamera;

    void LateUpdate()
    {
        transform.LookAt(mainCamera);
    }
}
