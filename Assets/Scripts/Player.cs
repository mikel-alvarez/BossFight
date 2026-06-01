using UnityEngine;

public class Player : MonoBehaviour
{
   private Rigidbody2D rb;
   private int health = 100;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
    }
    public void TakeDamage(int damage)
    {
        print("Player took damage: " + damage);
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // Handle player death (e.g., respawn, game over screen)
        Debug.Log("Player has died.");
    }
}
