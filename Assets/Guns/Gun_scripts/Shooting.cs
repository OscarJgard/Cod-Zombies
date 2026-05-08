using UnityEngine.Events;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public UnityEvent OnGunShoot;
    public float FireCooldown;

    //Guns är default som semi auto

    public bool automatic;

    private float CurrentCooldown;
    void Start()
    {
        CurrentCooldown = FireCooldown;
    }


    void Update()
    {
        CurrentCooldown -= Time.deltaTime;

        if (automatic)
        {
            // Håll nere för helautomatisk
            if (Input.GetMouseButton(0) && CurrentCooldown <= 0f)
            {
                OnGunShoot?.Invoke();
                CurrentCooldown = FireCooldown;
            }
        }
        else
        {
            // Ett skott per klick (semi-auto)
            if (Input.GetMouseButtonDown(0) && CurrentCooldown <= 0f)
            {
                OnGunShoot?.Invoke();
                CurrentCooldown = FireCooldown;
            }
        }
    }
}