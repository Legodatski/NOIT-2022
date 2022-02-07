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

    [Header("Locations")]
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingEjectionLocation;

    [Header("Bullet Values")]
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float bulletPower = 200;
    [SerializeField] private float ejectPower = 30;

    [Header("Recoil")]
    [SerializeField] private float recoilRate = 0.1f;
    [SerializeField] private float recoilMax = 10;

    [Header("Ammo and Reload")]
    [SerializeField] private int maxAmmo = 30;
    [SerializeField] private float reloadDuration = 5;

    [Header("Other")]
    [SerializeField] private float destroyCaseTimer = 5;
    [SerializeField] private float destroyMuzzleTimer = 1;

    public int currentAmmo;
    private float recoil;
    private float fireRateTimer;
    public InputDevice targetDevice;
    private List<InputDevice> devices;
    public bool shoot = false;

    public void StartShooting() => shoot = true;
    public void StopShooting() => shoot = false;


    private void Start()
    {
        devices = new List<InputDevice>();



        fireRateTimer = fireRate;
    }

    private void FixedUpdate()
    {
        if (fireRateTimer <= 0 && shoot && currentAmmo > 0)
        {
            if (recoil < recoilMax)
                recoil += recoilRate;

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

    private void Recoil()
    {
        /*if (recoil > 0)
        {
            var maxRecoil = Quaternion.Euler(recoilMax, 0, 0);
            // Dampen towards the target rotation
            barrelLocation.rotation = Quaternion.Slerp(barrelLocation.rotation, maxRecoil, Time.deltaTime * recoilSpeed);
            recoil -= Time.deltaTime;
        }
        else
        {
            recoil = 0;
            var minRecoil = Quaternion.Euler(0, -90, 0);
            // Dampen towards the target rotation
            barrelLocation.rotation = Quaternion.Slerp(barrelLocation.rotation, minRecoil, Time.deltaTime * recoilSpeed);

        }*/

        //maika mu da eba
    }

    private void Eject()
    {
        GameObject tempCase = Instantiate(CasingPrefap, casingEjectionLocation.position, casingEjectionLocation.rotation);

        tempCase.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower),
            (casingEjectionLocation.position - casingEjectionLocation.right * 0.3f - casingEjectionLocation.up * 0.6f), 1f);

        tempCase.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        Destroy(tempCase, destroyCaseTimer);
    }
}
