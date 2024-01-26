using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyStatsComponent), typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyStatsComponent stats = null;
    [SerializeField] Player playerRef = null;
    [SerializeField] NavMeshAgent agent = null;
    [SerializeField] PickupItem itemToDrop = null;
    [SerializeField] float idleTime = 1;
    [SerializeField] bool canMove = false;

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
        agent.SetDestination(playerRef.transform.position);
    }

    public void Init()
    {
        stats = GetComponent<EnemyStatsComponent>();
        agent = GetComponent<NavMeshAgent>();
        Invoke(nameof(AllowMovement), idleTime);
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

    private void OnCollisionEnter(Collision collision)
    {
        Player _player = collision.transform.GetComponent<Player>();
        if (!_player) return;
        _player.PlayerStats.AddHp(-stats.Damage);
    }
}
