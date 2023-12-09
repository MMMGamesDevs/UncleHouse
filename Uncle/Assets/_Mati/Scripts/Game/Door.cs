using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] string keyName;
    [SerializeField] float openingSpeed = 40f;
    [SerializeField] List<Transform> doors = new List<Transform>();
    [SerializeField] List<bool> anglePositive;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.gameObject.GetComponent<ThirdPersonController>().itemsManager.GetNumberItem(keyName) > 0)
            {
                AudioManager.instance.Play("Door-Wood-Opening");
                StartCoroutine(OpenDoor());
            }
            else
            {
                AudioManager.instance.Play("Door-Wood-Closed");
            }
        }
    }

    private IEnumerator OpenDoor()
    {
        float deltaRotation = 0;
        float totalDeltaRotation = 0;
        while (totalDeltaRotation < 90)
        {
            deltaRotation = openingSpeed * Time.deltaTime;
            totalDeltaRotation += deltaRotation;
            for(int i=0; i<doors.Count; i++)
            {
                UpdateRotation(doors[i], deltaRotation, anglePositive[i]);
            }
            yield return new WaitForSeconds(0.05f);
        }
        AudioManager.instance.Stop("Door-Wood-Opening");
        Destroy(gameObject);
    }

    private void UpdateRotation(Transform door, float deltaRotation, bool anglePositive)
    {
        if(door)
        {
            door.rotation = Quaternion.Euler(
                door.rotation.eulerAngles.x,
                door.rotation.eulerAngles.y + (anglePositive ? deltaRotation : -deltaRotation),
                door.rotation.eulerAngles.z);
        }
    }


}
