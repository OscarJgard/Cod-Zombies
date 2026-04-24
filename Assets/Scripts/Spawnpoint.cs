using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public GameObject prefab;
    public float RepeatTime = 3f;


    void Start()
    {
        InvokeRepeating("Spawn", 2f, RepeatTime);
    }



    void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

}
