using IA.Decision.BehaviourTree;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boss : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float health = 100f;
    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private Task root;

    [SerializeField] private InputActionReference prueba;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle boss death (e.g., play animation, drop loot, etc.)
        Debug.Log("Boss defeated!");
        
    }

    private void Update()
    {
     
            root.Execute();
        
    }


}
