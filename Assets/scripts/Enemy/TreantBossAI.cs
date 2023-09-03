using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantBossAI : EnemyAbstract
{
    private Transform target;

    private Animator animator;

    public GameObject enemyGFX;

    public float updateRate = 2f;
    public float range = 12f;
    private Rigidbody2D rb;

    public int health = 500;
    public float damage = 10f;
    public int armour = 10;
    public float attackRange = 3f;
    public float attackCooldown = 2f;
    private float lastAttackTime = 0f;
    private float attackCounter = 0f;

    public override int Health { get; set; }
    public override float Damage { get; set; }
    public override int Armour { get; set; }
    public override int CoinAmount { get; set; }
    public override int LootDropChance { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Health = health;
        Damage = damage;
        Armour = armour;
        rb = GetComponent<Rigidbody2D>();
        CoinAmount = 2;
        LootDropChance = 30;
        //InvokeRepeating("UpdateTarget", 0f, 0.5f);
        //StartCoroutine(UpdatePath());
    }

    void Update()
    {
        Attack();
        HealthCheck();
    }

    public override void Attack()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        float distanceToTarget = Vector2.Distance(rb.position, target.position);

        if (distanceToTarget <= attackRange && attackCounter >= attackCooldown)
        {
            animator.SetBool("IsAttacking", true);
            InflictDamage();
        }
        else
        {
            attackCounter += Time.deltaTime;
            animator.SetBool("IsAttacking", false);
        }

    }

    public void SpawnFade()
    {
        GameObject fade = Resources.Load<GameObject>("Fade");
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - 1.5f);
        GameObject fade1 = Instantiate(fade, pos, Quaternion.identity);
    }

    public void InflictDamage()
    {
        StatManager.damagePlayer(Damage);
        lastAttackTime = Time.time; // Set last attack time for cooldown
        attackCounter = 0f;
        Debug.Log("Inflict Damage Bool: " + animator.GetBool("IsAttacking"));
    }

    public override void damageEnemy(float damageInflicted)
    {
        LowerHealth(damageInflicted);
        Debug.Log("Treant health: " + this.Health);
    }

    private void OnDestroy()
    {
        animator.SetBool("IsDead", true);
        GameObject rocket = Resources.Load<GameObject>("RocketPart");
        GameObject rocketPart = Instantiate(rocket, transform.position, Quaternion.identity);
    }

    private void HealthCheck()
    {
        if (this.Health <= health * 3 / 10)
        {
            animator.SetBool("Enraged", true);
            this.Damage = damage * 2;
            this.Armour = armour * 2;
        }
    }
}
