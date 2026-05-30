using IA.BlackBoard;
using IA.Decision.BehaviourTree;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boss : MonoBehaviour
{
    [Header("Boss Settings")]
    [SerializeField] private Animator animator;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private Task root;
    private int hitRecive = 0;
    private bool isProtected = false;

    [Header("References")]
    [SerializeField] private BlackBoard blackBoard;
    [SerializeField] private Transform player;


    private void Start()
    {
        health = maxHealth;
        root.SetBlackBoard(blackBoard);
        blackBoard.SetData("PlayerTransform", player);
        blackBoard.SetData("BossTransform", transform);
        blackBoard.SetData("vidaBoss", health);
        blackBoard.SetData("maxVidaBoss", maxHealth);
        blackBoard.SetData("hitRecive", hitRecive);
        blackBoard.SetData("boss",this);

    }
    public void TakeDamage(float damage)
    {
        if (isProtected)
        {
            return;
        }
        health -= damage;
        hitRecive++;
        blackBoard.SetData("hitRecive", hitRecive);
        blackBoard.SetData("vidaBoss", health);
        if (health <= 0)
        {
            Die();
        }
    }
    public void Atack(AttackType attackType)
    {
        switch (attackType)
        {
            case AttackType.Melee:
                AttackMelee();
                break;
            case AttackType.Ranged:
                AttackRanged();
                break;
            case AttackType.Jump:
                AttackSalto();
                break;
            case AttackType.Rayo:
                AttackRayo();
                break;
            case AttackType.DoubleRanged:
                AttackDoble();
                break;
            case AttackType.Area:
                AttackArea();
                break;
        }
    }
    public void ProtectMode()
    {
        isProtected = true;
        hitRecive = 0;
            blackBoard.SetData("hitRecive", hitRecive);
            Debug.Log("Boss is now protected!");
    }
    public void AttackMelee()
    {
        animator.Play("meleeAttack");
        Debug.Log("Boss attacks for " + attackDamage + " damage!");
        // Aquí podrías implementar la lógica para dañar al jugador
    }

    public void AttackRanged()
    {
        Debug.Log("Boss performs a ranged attack for " + attackDamage + " damage!");
        // Aquí podrías implementar la lógica para un ataque a distancia
    }

    public void AttackRayo()
    {
        Debug.Log("Boss performs a lightning attack for " + attackDamage + " damage!");
        // Aquí podrías implementar la lógica para un ataque de rayo
    }
    public void AttackDoble()
    {
        Debug.Log("Boss performs a double attack for " + attackDamage * 2 + " damage!");
        // Aquí podrías implementar la lógica para un ataque doble  
    }
    public void AttackArea()
    {
        Debug.Log("Boss performs an area attack for " + attackDamage + " damage!");
        // Aquí podrías implementar la lógica para un ataque de área
    }
    public void AttackSalto()
    {
        Debug.Log("Boss performs a jump attack for " + attackDamage + " damage!");
        // Aquí podrías implementar la lógica para un ataque de salto
    }
    private void Die()
    {
        Debug.Log("Boss defeated!");
        animator.Play("death");
    }

    private void Update()
    {
        root.Execute();
    }


}
