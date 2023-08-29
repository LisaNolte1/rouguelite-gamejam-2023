using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CrabAI : EnemyAbstract
{
    private Transform target;

    private Animator animator;

    public float nextWayPointDistance = 1f;

    public float followDistance = 4f;

    public GameObject enemyGFX;

    public float updateRate = 2f;
    public float range = 12f;
    private Seeker seeker;
    private Rigidbody2D rb;
    public Path path;
    private int currentWaypoint = 0;
    public float speed = 100f;
    public ForceMode2D fmode;

    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWaypointDistance = 3;

    public int health = 10;
    public float damage = 1f;
    public int armour = 2;
    public float attackRange = 2f;
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
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        CoinAmount = 3;
        LootDropChance = 50;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            yield break;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    void UpdateTarget()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Player");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
        if (enemyDistance < shortestDistance)
        {
            shortestDistance = enemyDistance;
            nearestEnemy = enemy;
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            range = 15f;
            seeker.StartPath(transform.position, target.position, OnPathComplete);
        }
        else
        {
            target = null;
        }

    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void StartPath()
    {
        seeker.StartPath(transform.position, target.position, OnPathComplete);
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            range = 12f;
            animator.SetBool("IsMoving", false);
            return;
        }

        if (path == null)
        {
            animator.SetBool("IsMoving", false);
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            pathIsEnded = true;
            animator.SetBool("IsMoving", false);
            return;
        }
        pathIsEnded = false;
        animator.SetBool("IsMoving", true);

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fmode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }

    void Update()
    {
        Attack();
    }

    public override void Attack()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        float distanceToTarget = Vector2.Distance(rb.position, target.position);

        if (distanceToTarget <= attackRange && attackCounter >= attackCooldown)
       {
            InflictDamage();
            SetAttackAnimBool(target);
        }else {
            attackCounter += Time.deltaTime;
            animator.SetBool("IsAttackingUp", false);
            animator.SetBool("IsAttackingDown", false);
        }

    }

    public void InflictDamage()
    {
        StatManager.damagePlayer(Damage);
        lastAttackTime = Time.time; // Set last attack time for cooldown
        attackCounter = 0f;
    }

    public override void damageEnemy(float damageInflicted)
    {
        LowerHealth(damageInflicted);
    }

    private void SetAttackAnimBool(Transform target)
    {
        if (target.position.y > transform.position.y)
        {
            animator.SetBool("IsAttackingUp", true);
            animator.SetBool("IsAttackingDown", false);
        } else if (target.position.y < transform.position.y)
        {
            animator.SetBool("IsAttackingDown", true);
            animator.SetBool("IsAttackingUp", false);
        }
    }
}
