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
        if (automatic)

        {
            if (Input.GetMouseButtonDown(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }

        CurrentCooldown -= Time.deltaTime;

    }
}
