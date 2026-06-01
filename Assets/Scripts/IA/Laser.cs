using UnityEngine;

public class Laser : MonoBehaviour
{
    private Collider2D hitBox;
    private void Start()
    {
        hitBox = GetComponent<Collider2D>();
        hitBox.enabled = false;
    }
    public void finish()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Laser collided with: " + collision.gameObject.name);
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(5);
        }
        
    }

    public void hitBoxActive()
    {
       hitBox.enabled = true;
    }
}

