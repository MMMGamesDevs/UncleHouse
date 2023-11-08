using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 50;
    private void Start()
    {
        Destroy(gameObject, 100);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            transform.parent = other.transform;
            Destroy(transform.GetComponent<Rigidbody>());
        }
        if (other.tag == "Enemy")
        {
            transform.parent = other.transform;
            Debug.Log("Me diste");
            other.GetComponent<Zombie>().TakeDamage(damageAmount);
        }

    }
}
