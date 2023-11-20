using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private StarterAssets controls;
    private Camera cam;
    private RaycastHit rayHit;

    [Header("Parámetros modificables del arma")]
    [Tooltip("Alcance del arma en metros")]
    [SerializeField] float bulletRange;

    [Tooltip("Demora en volver a disparar en segundos")]
    [SerializeField] float fireRate;

    [Tooltip("Demora en recargar en segundos")]
    [SerializeField] float reloadTime;

    [Tooltip("¿El arma es automática o manual?")]
    [SerializeField] bool isAutomatic;

    [Tooltip("Cantidad de municiones del cargador/tambor")]
    [SerializeField] int magazineSize;

    [SerializeField] GameObject bulletHolePrefab;
    [SerializeField] float bulletHoleLifeSpan;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] string EnemyTag;
    [SerializeField] float horizontalSpread;
    [SerializeField] float verticalSpread;
    [SerializeField] float burstDelay;
    [SerializeField] int bulletsPerBurst;
    int bulletsShot;


    [Header("Información del arma")]
    [Tooltip("Municiones que quedan en el arma")]
    [SerializeField] int ammoLeft;

    [Tooltip("En proceso de disparo")]
    [SerializeField] bool isShooting;

    [Tooltip("Lista para disparar")]
    [SerializeField] bool readyToShoot;

    [Tooltip("En proceso de recarga")]
    [SerializeField] bool reloading;

    void Awake()
    {
        ammoLeft = magazineSize;
        readyToShoot = true;
        controls = new StarterAssets();
        cam = Camera.main;
        controls.Player.Shooting.started += ctx => StartShot();
        controls.Player.Shooting.canceled += ctx => EndShot();

        controls.Player.Reload.performed += ctx => Reload();
    }

    void Update()
    {
        if(isShooting && readyToShoot && !reloading && ammoLeft > 0)
        {
            bulletsShot = bulletsPerBurst;
            PerformShot();
        }
    }

    void StartShot()
    {
        isShooting = true;
    }

    void EndShot()
    {
        isShooting = false;
    }

    void PerformShot()
    {
        readyToShoot = false;
        
        float x = Random.Range(-horizontalSpread, horizontalSpread);
        float y = Random.Range(-verticalSpread, verticalSpread);

        Vector3 direction = cam.transform.forward + new Vector3(x, y, 0);

        if(Physics.Raycast(cam.transform.position, direction, out rayHit, bulletRange))
        {
            Debug.Log($"{rayHit.collider.gameObject.name}: {rayHit.distance}m");
            if(rayHit.collider.gameObject.tag == EnemyTag)
            {

            }
            else
            {
                GameObject bulletHole = Instantiate(bulletHolePrefab, rayHit.point + rayHit.normal * 0.001f, Quaternion.identity) as GameObject;
                bulletHole.transform.LookAt(rayHit.point + rayHit.normal);
                Destroy(bulletHole, bulletHoleLifeSpan);
            }
        }
        muzzleFlash.Play();

        ammoLeft--;
        bulletsShot--;

        if(bulletsShot > 0 && ammoLeft > 0)
        {
            Invoke("ResumeBurst", burstDelay);
        }
        else
        {
            Invoke("ResetShot", fireRate);
            if(!isAutomatic)
            {
                EndShot();
            }
        }
    }

    void ResumeBurst()
    {
        readyToShoot = true;
        PerformShot();
    }
    void ResetShot()
    {
        readyToShoot = true;
    }

    void Reload()
    {
        reloading = true;
        Invoke("ReloadFinish", reloadTime);
    }

    void ReloadFinish()
    {
        ammoLeft = magazineSize;
        reloading = false;
        readyToShoot = true;
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }
 

}
