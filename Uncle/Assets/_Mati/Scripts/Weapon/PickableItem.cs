using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Esfera que contiene el item o arma para recoletar.
 * Genera un efecto de rotación.
 * Cuando el player colisiona con la esfera le ofrece al controller un item para recolectar y lo quita cuando sale de la zona.
 * Ofrece los métodos para obtener el item dentro y para destroir la esfera una vez que es recogido.
 */
public class PickableItem : MonoBehaviour
{

    [SerializeField] float itemVelocity = 150f;
    GameObject _item;

    void Awake()
    {
        _item = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * itemVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<ThirdPersonController>().SetPickableItem(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<ThirdPersonController>().SetPickableItem(null);
        }
    }

    public GameObject GetItem()
    {
        return _item;
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }

}
