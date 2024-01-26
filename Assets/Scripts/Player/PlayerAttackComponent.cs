using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackComponent : MonoBehaviour
{
    [SerializeField] PlayerStatsComponent playerStats = null;
    [SerializeField] Player player = null;
    [SerializeField] LayerMask enemyLayer = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Attack(InputAction.CallbackContext _context)
    {
        Vector3 _direction = ((player.transform.position + player.transform.forward) - player.transform.position).normalized;
        bool _hasHit = Physics.Raycast(player.transform.position, _direction, out RaycastHit _result, playerStats.Range, enemyLayer);
        Debug.DrawRay(player.transform.position, _direction * playerStats.Range, _hasHit ? Color.green : Color.red, 1);
        if (!_hasHit) return;
        Debug.Log("Hit");
        Enemy _enemy = _result.transform.GetComponent<Enemy>();
        if(!_enemy) return;
        _enemy.Stats.AddHp(-playerStats.Damage);
        Debug.Log(_enemy.Stats.CurrentHp);
    }

    void Init()
    {
        player = GetComponent<Player>();
        if(!player) return;
        playerStats = GetComponent<PlayerStatsComponent>();
        if(!playerStats) return;
    }
}
