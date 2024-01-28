using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackComponent : MonoBehaviour
{

    [SerializeField] PlayerStatsComponent playerStats = null;
    [SerializeField] Player player = null;
    [SerializeField] LayerMask enemyLayer = 0;
    [SerializeField] float currentTime = 0;
    [SerializeField] float skill1Cooldown = 5, skill1CurrentTime = 0;
    [SerializeField] bool canAttack = true, skill1Ready = true;
    [SerializeField] int energyCost = 15, hpToRestore = 2;

    public float Skill1Cooldown => skill1Cooldown;
    public float Skill1CurrentTime => skill1CurrentTime;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canAttack)
            IncreaseTime(ref currentTime, playerStats.AttackSpeed, ref canAttack);
        if (!skill1Ready)
            IncreaseTime(ref skill1CurrentTime, skill1Cooldown, ref skill1Ready);
    }

    public void Attack(InputAction.CallbackContext _context)
    {
        if (!player || !canAttack) return;
        canAttack = false;
        Vector3 _direction = ((player.transform.position + player.transform.forward) - player.transform.position).normalized;
        bool _hasHit = Physics.Raycast(player.transform.position, _direction, out RaycastHit _result, playerStats.Range, enemyLayer);
        Debug.DrawRay(player.transform.position, _direction * playerStats.Range, _hasHit ? Color.green : Color.red, 0.2f);
        if (!_hasHit) return;
        //Debug.Log("Hit");
        Enemy _enemy = _result.transform.GetComponent<Enemy>();
        if(!_enemy) return;
        _enemy.Stats.AddHp(-playerStats.Damage);
        //Debug.Log(_enemy.Stats.CurrentHp);
    }

    void Init()
    {
        player = GetComponent<Player>();
        if(!player) return;
        playerStats = GetComponent<PlayerStatsComponent>();
        if(!playerStats) return;

    }

    void IncreaseTime(ref float _current, float _max, ref bool _toSwitch)
    {
        _current += Time.deltaTime;
        if(_current >= _max)
        {
            _current = 0;
            _toSwitch = true;
        }
    }

    public void Heal(InputAction.CallbackContext _context)
    {
        if (!playerStats || playerStats.CurrentEnergy <= energyCost || playerStats.CurrentHp >= 10 || !skill1Ready) return;
        
        playerStats.AddEnergy(-energyCost);
        playerStats.AddHp(hpToRestore);
        skill1Ready = false;
    }
}
