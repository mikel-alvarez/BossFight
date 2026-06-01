using UnityEngine;

public class Proyectile : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Proyectile collided with: " + collision.gameObject.name);
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(5);
        }
        Destroy(gameObject);
    }
}
