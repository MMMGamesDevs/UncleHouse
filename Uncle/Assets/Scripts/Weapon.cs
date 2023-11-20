using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssetss;
using UnityEngine.Windows;

public class Weapon : MonoBehaviour
{
    private StarterAssetsInputs controls;
    private Camera cam;
    private RaycastHit rayHit;

    [Header("Par�metros modificables del arma")]
    [Tooltip("Alcance del arma en metros")]
    [SerializeField] float bulletRange;

    [Tooltip("Demora en volver a disparar en segundos")]
    [SerializeField] float fireRate;

    [Tooltip("Demora en recargar en segundos")]
    [SerializeField] float reloadTime;

    [Tooltip("�El arma es autom�tica o manual?")]
    [SerializeField] bool isAutomatic;

    [Tooltip("Cantidad de municiones del cargador/tambor")]
    [SerializeField] int magazineSize;

    [Tooltip("Tag del enemigo")]
    [SerializeField] string EnemyTag;

    [Tooltip("Fluctuaci�n en el eje horizontal")]
    [SerializeField] float horizontalSpread;

    [Tooltip("Fluctuaci�n en el eje vertical")]
    [SerializeField] float verticalSpread;

    [Tooltip("Valor de da�o al enemigo")]
    [SerializeField] int damageAmount;

    [Header("Prefabs y agregados")]
    [Tooltip("Prefab del hoyo que provocara en paredes")]
    [SerializeField] GameObject bulletHolePrefab;

    [Tooltip("Duraci�n del hoyo")]
    [SerializeField] float bulletHoleLifeSpan;

    [Tooltip("Sistema de particulas de disparo")]
    [SerializeField] ParticleSystem muzzleFlash;

    [Header("Averiguar que es")]
    [SerializeField] float burstDelay;
    [SerializeField] int bulletsPerBurst;
    int bulletsShot;


    [Header("Informaci�n del arma")]
    [Tooltip("Municiones que quedan en el arma")]
    [SerializeField] int ammoLeft;

    //[Tooltip("En proceso de disparo")]
    //[SerializeField] bool isShooting;

    [Tooltip("Lista para disparar")]
    [SerializeField] bool readyToShoot;

    [Tooltip("En proceso de recarga")]
    [SerializeField] bool reloading;


    void Awake()
    {
        ammoLeft = magazineSize;
        readyToShoot = true;
        controls = GetComponent<StarterAssetsInputs>();
        cam = Camera.main;
        //controls.Player.Shooting.started += ctx => StartShot();
        //controls.Player.Shooting.canceled += ctx => EndShot();

        //controls.Player.Reload.performed += ctx => Reload();
    }

    void Update()
    {
        if (controls.isShooting /*&& isShooting*/ && readyToShoot && !reloading && ammoLeft > 0)
        {
            bulletsShot = bulletsPerBurst;
            PerformShot();
        }

        if(controls.reload && /*!controls.isShooting*/ readyToShoot)
        {
            controls.reload = false;
            Reload();
        }
    }

    void StartShot()
    {
        //isShooting = true;
    }

    void EndShot()
    {
        //isShooting = false;
        controls.isShooting = false;
    }

    void PerformShot()
    {
        readyToShoot = false;

        float x = Random.Range(-horizontalSpread, horizontalSpread);
        float y = Random.Range(-verticalSpread, verticalSpread);

        Vector3 direction = cam.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(cam.transform.position, direction, out rayHit, bulletRange))
        {
            Debug.Log($"{rayHit.collider.gameObject.name}: {rayHit.distance}m");
            if (rayHit.collider.gameObject.tag == EnemyTag)
            {
                rayHit.collider.gameObject.GetComponent<Zombie>().TakeDamage(damageAmount);
            }
            else
            {
                GameObject bulletHole = Instantiate(bulletHolePrefab, rayHit.point + rayHit.normal * 0.001f, Quaternion.identity) as GameObject;
                bulletHole.transform.LookAt(rayHit.point + rayHit.normal);
                Destroy(bulletHole, bulletHoleLifeSpan);
            }
        }
        if(muzzleFlash != null) muzzleFlash.Play();

        ammoLeft--;
        bulletsShot--;

        if (bulletsShot > 0 && ammoLeft > 0)
        {
            Invoke("ResumeBurst", burstDelay);
        }
        else
        {
            Invoke("ResetShot", fireRate);
            if (!isAutomatic)
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
        //controls.Enable();
    }

    void OnDisable()
    {
        //controls.Disable();
    }
}
