using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPew : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;
    public KeyCode key;
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Target taget = hit.transform.GetComponent<Target>();
            if(taget != null)
            {
                taget.TakeDamage(damage);
            }
        }
    }
}
