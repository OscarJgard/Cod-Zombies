using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamage : MonoBehaviour
{
    public float Damage;
    public float BulletRange;
    private Transform Playercamera;


    private void Start()
    {
        Playercamera = Camera.main.transform;
    }

    public void Shoot()
    {
        Ray gunRay = new Ray(Playercamera.position, Playercamera.forward);

        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= Damage;
            }
        }
    }
}
