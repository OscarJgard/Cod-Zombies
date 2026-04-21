using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walking : MonoBehaviour
{
    [Header("Zombie and Damage")]
    public float giveDamage = 5f;

    [Header("Zombie Things")]
    public NavMeshAgent zombieAgent;
    public Transform lookPoint;
    public Camera AttackingRaycastArea;
    public Transform playerBody;
    public LayerMask playerLayer;

    [Header("Zombie Guarding variable")]
    public GameObject[] walkPoints;
    int currentZombiePosition = 0;
    public float zombieSpeed;
    float walkingPointRadius = 2;

    [Header("Zombie Attacking Var")]
    public float timeBtwAttack;
    bool previouslyAttacked;

    [Header("Zombie mood/states")]
    public float visionRadius;
    public float attackingRadius;
    public bool playerInVisionRadius;
    public bool playerInAttackingRadius;

    private void Awake()
    {
        zombieAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInVisionRadius = Physics.CheckSphere(transform.position, visionRadius, playerLayer);
        playerInAttackingRadius = Physics.CheckSphere(transform.position, attackingRadius, playerLayer);
        
        if (!playerInVisionRadius && !playerInAttackingRadius) Guard();
        if (playerInVisionRadius && !playerInAttackingRadius) Pursueplayer();
        if (playerInVisionRadius && playerInAttackingRadius) AttackPlayer();
    }

    private void Guard()
    {
        if (Vector3.Distance(walkPoints[currentZombiePosition].transform.position, transform.position) < walkingPointRadius)
        {
            currentZombiePosition = Random.Range(0, walkPoints.Length);
            if (currentZombiePosition >= walkPoints.Length)
            {
                currentZombiePosition = 0;

            }
        }
       transform.position = Vector3.MoveTowards(transform.position, walkPoints[currentZombiePosition].transform.position, zombieSpeed * Time.deltaTime);
        //Ändrar zombies hastighet och riktning mot den aktuella walkpointen, så att den rör sig mot den.
        transform.LookAt(walkPoints[currentZombiePosition].transform.position);
    }
    private void Pursueplayer()
    {
        zombieAgent.SetDestination(playerBody.position);
    }

    private void AttackPlayer()
    {
        if(!previouslyAttacked)
        {
            RaycastHit hitinfo;
            if(Physics.Raycast(AttackingRaycastArea.transform.position, AttackingRaycastArea.transform.forward, out hitinfo, attackingRadius))
            {
                Debug.Log("Attacking" + hitinfo.transform.name);
            }
            previouslyAttacked = true;
            Invoke(nameof(ActiveAttacking), timeBtwAttack);
        }
    }
    private void ActiveAttacking()
    {
        previouslyAttacked = false;
    }
}


