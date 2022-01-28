using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalShooting : MonoBehaviour
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
    [SerializeField] private float recoilSpeed = 2;

    [Header("Other")]
    [SerializeField] private Animator animator;
    [SerializeField] private OVRInput.Button shootTriger = OVRInput.Button.PrimaryIndexTrigger;
    [SerializeField] private float destroyCaseTimer = 5;
    [SerializeField] private float destroyMuzzleTimer = 1;

    private float recoil;
    private OVRGrabbable ovrGrabbable;
    private float fireRateTimer;

    private void Start()
    {
        fireRateTimer = fireRate;
        ovrGrabbable = GetComponent<OVRGrabbable>();

        if (ovrGrabbable == null)
            ovrGrabbable = GetComponentInParent<OVRGrabbable>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ovrGrabbable.isGrabbed && OVRInput.Get(shootTriger, ovrGrabbable.grabbedBy.GetController()) && fireRateTimer <= 0)
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

        Recoil();
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

        Instantiate(BulletPrefap, barrelLocation.position, new Quaternion(0, 0, 0, 0)).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * bulletPower);
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

    }
    
    private void Eject()
    {
        GameObject tempCase = Instantiate(CasingPrefap, casingEjectionLocation.position, casingEjectionLocation.rotation);

        tempCase.AddComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower),
            (casingEjectionLocation.position - casingEjectionLocation.right * 0.3f - casingEjectionLocation.up * 0.6f), 1f);

        tempCase.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        Destroy(tempCase, destroyCaseTimer);
    }
}
