using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    [Header("Player Health Things")]
    public float StartingHealth = 100f;
    public float presentHealth;











    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        presentHealth = StartingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playerHitDamage(float takeDamage)
    {
        presentHealth -= takeDamage;

        if (presentHealth < 0)
        {
            playerDie();
        }
    }
    private void playerDie()
    {
        Cursor.lockState = CursorLockMode.None;
        Object.Destroy(gameObject, 1.0f);
    }
}
