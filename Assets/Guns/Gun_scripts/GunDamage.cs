using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamage : MonoBehaviour
{
    public float Damage;
    public float BulletRange;
    private Transform Playercamera;
    public Camera camera;


    private void Start()
    {
        Debug.Log("Gundmg start");
        Playercamera = camera.transform;
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
        Ray gunRay = new Ray(Playercamera.position, Playercamera.forward);

        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            Debug.Log("Shoot if1");
            if (hitInfo.collider.gameObject.TryGetComponent(out ZombieScript enemy))
            {
                Debug.Log("Shoot if2");
                enemy.presentHealth -= Damage;
            }
        }
    }
}
