using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRshooting : MonoBehaviour
{
    [Header("Prefaps")]
    public GameObject BulletPrefap;
    public GameObject CasingPrefap;
    public GameObject MuzzleFlastPrefap;

    [SerializeField] private List<Part> Parts;

    [Header("Locations")]
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingEjectionLocation;

    [Header("Bullet Values")]
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float bulletPower = 200;
    [SerializeField] private float ejectPower = 30;
    [SerializeField] private int maxAmmo = 30;

    [Header("Other")]
    [SerializeField] private float destroyCaseTimer = 5;
    [SerializeField] private float destroyMuzzleTimer = 1;

    public int currentAmmo;
    private float fireRateTimer;
    public bool shoot = false;

    public void StartShooting() => shoot = true;
    public void StopShooting() => shoot = false;


    private void Start()
    {
        fireRateTimer = fireRate;
    }

    private void FixedUpdate()
    {
        if (fireRateTimer <= 0 && shoot && currentAmmo > 0 && IsBuild())
        {
            fireRateTimer = fireRate;
            Debug.LogWarning("Shooting");
            Shoot();
            Eject();
        }
        else
        {
            fireRateTimer -= Time.deltaTime;
        }

    }

    public void Reload()
    {
        currentAmmo = maxAmmo;
    }

    private void Shoot()
    {
        if (MuzzleFlastPrefap)
        {
            GameObject tempFlash = Instantiate(MuzzleFlastPrefap, barrelLocation.position, barrelLocation.rotation);
            Destroy(tempFlash, destroyMuzzleTimer);
        }

        if (!BulletPrefap)
        {
            Debug.LogError("404: Bullet prefap not found!");
            return;
        }

        currentAmmo--;
        GameObject bullet = Instantiate(BulletPrefap, barrelLocation.position, new Quaternion(0, 0, 0, 0));
        bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * bulletPower);
        bullet.tag = "bullet";
    }

    private void Eject()
    {
        GameObject tempCase = Instantiate(CasingPrefap, casingEjectionLocation.position, casingEjectionLocation.rotation);

        tempCase.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower),
            (casingEjectionLocation.position - casingEjectionLocation.right * 0.3f - casingEjectionLocation.up * 0.6f), 1f);

        tempCase.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        Destroy(tempCase, destroyCaseTimer);
    }

    private bool IsBuild()
    {
        foreach (var part in Parts)
        {
            if (!part.Connected())
                return false;
        }

        return true;
    }
}
