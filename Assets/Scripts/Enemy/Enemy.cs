using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyStatsComponent), typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    const string IDLE = "Idle";
    const string WALK = "Walk";

    [SerializeField] EnemyStatsComponent stats = null;
    [SerializeField] Player playerRef = null;
    [SerializeField] NavMeshAgent agent = null;
    [SerializeField] PickupItem itemToDrop = null;
    [SerializeField] Animator enemyAnimator = null;
    [SerializeField] float idleTime = 1;
    [SerializeField] bool canMove = false;

    public EnemyStatsComponent Stats => stats;
    public Player PlayerRef { get { return playerRef; } set { playerRef = value; } }

    void Start()
    {
        Init();
        //Invoke(nameof(TestDeath), 3);
    }

    void TestDeath()
    {
        stats.AddHp(-stats.MaxHp);
    }

    void FixedUpdate()
    {
        if (!agent || !agent.enabled || !canMove || !playerRef) return;
        agent.SetDestination(playerRef.transform.position); //use navmesh to go towards player
    }

    public void Init()
    {
        stats = GetComponent<EnemyStatsComponent>();
        agent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        Invoke(nameof(AllowMovement), idleTime); //moves only after a certain time
        stats.OnDeath += stats.SetIsDead;
        stats.OnIsDeadUpdated += Death;
    }

    void AllowMovement()
    {
        canMove = true;
    }

    private void Death() 
    {
        EntityManager.Instance.RemoveEnemy(this);
        Instantiate(itemToDrop, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision) //hurts the player on collision
    {
        Player _player = collision.transform.GetComponent<Player>();
        if (!_player) return;
        _player.PlayerStats.AddHp(-stats.Damage);
    }

    void SetAnimation()
    {
        if(agent.velocity == Vector3.zero)
        {
            enemyAnimator.Play(IDLE);
        }
        else
        {
            enemyAnimator.Play(WALK);
        }
    }
}
