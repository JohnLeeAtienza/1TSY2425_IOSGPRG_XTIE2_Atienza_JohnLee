using System.Collections;
using UnityEngine;

public enum EnemyState
{
    Patrol,
    Detect,
    Attack
}

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 10f;
    public float attackRange = 5f;
    public float attackCooldown = 1f;

    private EnemyState currentState;
    private Transform player;
    private Animator animator;
    private float lastAttackTime;
    private EnemyWeapon enemyWeapon; 

    void Start()
    {
        currentState = EnemyState.Patrol; // Start in Patrol state
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        enemyWeapon = GetComponent<EnemyWeapon>(); 

        StartCoroutine(StateMachine());
    }

    IEnumerator StateMachine()
    {
        while (true)
        {
            switch (currentState)
            {
                case EnemyState.Patrol:
                    Patrol();
                    break;
                case EnemyState.Detect:
                    Detect();
                    break;
                case EnemyState.Attack:
                    Attack();
                    break;
            }
            yield return null;
        }
    }

    void Patrol()
    {
        Vector3 patrolDirection = new Vector3(Mathf.Sin(Time.time) * 2f, 0, Mathf.Cos(Time.time) * 2f);
        transform.Translate(patrolDirection * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            currentState = EnemyState.Detect; 
        }
    }

    void Detect()
    {
        if (player == null) return;

        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            currentState = EnemyState.Attack;
        }
    }

    void Attack()
    {
        if (player == null) return;

        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            if (Time.time - lastAttackTime > attackCooldown)
            {
                enemyWeapon.TryShoot(); 
                lastAttackTime = Time.time;
            }
        }
        else
        {
            enemyWeapon.TryShoot();
        }
    }
}
