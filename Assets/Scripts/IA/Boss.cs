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
    [SerializeField] private Transform disparoPlace;
    [SerializeField] private Transform laserPlace;
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private GameObject laserPrefab;


    private void Start()
    {
        health = maxHealth;
        root.SetBlackBoard(blackBoard);
        blackBoard.SetData("PlayerTransform", player);
        blackBoard.SetData("BossTransform", transform);
        blackBoard.SetData("vidaBoss", health);
        blackBoard.SetData("maxVidaBoss", maxHealth);
        blackBoard.SetData("hitRecive", hitRecive);
        blackBoard.SetData("boss", this);
        //root.Execute();
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
        print("Boss is now protected!");
    }
    public void AttackMelee()
    {
        animator.Play("melee");
        print("Boss attacks for " + attackDamage + " damage!");
    }

    public void AttackRanged()
    {
        animator.Play("shoot");
        print("Boss performs a ranged attack for " + attackDamage + " damage!");
    }

    public void AttackRayo()
    {
        animator.Play("laser_cast");
        print("Boss performs a lightning attack for " + attackDamage + " damage!");
    }
    public void AttackDoble()
    {
        print("Boss performs a double attack for " + attackDamage * 2 + " damage!");
    }
    public void AttackArea()
    {
        print("Boss performs an area attack for " + attackDamage + " damage!");
    }
    public void AttackSalto()
    {
        print("Boss performs a jump attack for " + attackDamage + " damage!");
    }
    private void Die()
    {
        print("Boss defeated!");
        animator.Play("death");
    }

    public void shootAction()
    {
        Instantiate(proyectilPrefab, disparoPlace.position, disparoPlace.rotation);
        print("Boss shoots a projectile!");
    }
    public void laserShoot()
    {
        Instantiate(laserPrefab, laserPlace.position, laserPlace.rotation);
        print("Boss shoots a laser!");
    }
    private void Update()
    {
        root.Execute();

    }


}
