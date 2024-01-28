using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerStatsComponent), typeof(PlayerMovementComponent), typeof(PlayerAttackComponent))]

public class Player : MonoBehaviour
{
    //public event Action<Vector3> OnHitGround = null;
    //public event Action OnWorldPositionSet = null;

    //[SerializeField] Vector3 worldPosition = Vector3.zero;
    //[SerializeField] LayerMask maskGround = 0;
    //[SerializeField] float customTickRate = .2f;
    //[SerializeField] float detectionRange = 50;
    double score = 0;
    public double Score => score;

    [SerializeField] Controls controls = null;
    [SerializeField] InputAction move = null;
    [SerializeField] InputAction rotate = null;
    [SerializeField] InputAction leftClick = null;
    [SerializeField] InputAction skill = null;

    [SerializeField] PlayerStatsComponent playerStats = null;
    [SerializeField] PlayerMovementComponent movement = null;
    [SerializeField] PlayerAttackComponent attack = null;
    //[SerializeField] GameObject test = null;

    //bool detected = false;
    //Ray screenRay = new Ray();

    //public Vector3 WorldPosition => worldPosition;
    public InputAction Move => move;
    public InputAction Rotate => rotate;
    public PlayerStatsComponent PlayerStats => playerStats;
    public PlayerMovementComponent Movement => movement;
    public PlayerAttackComponent Attack => attack;
    //public GameObject Test => test;

    private void Awake()
    {
        Time.timeScale = 1;
        controls = new Controls();
        Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Init();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        move = controls.Player.Movement;
        move.Enable();
        rotate = controls.Player.Rotate;
        rotate.Enable();
        leftClick = controls.Player.Attack;
        leftClick.Enable();
        leftClick.performed += attack.Attack;
        skill = controls.Player.Skill1;
        skill.Enable();
        skill.performed += attack.Heal;
    }

    void Init()
    {
        playerStats = GetComponent<PlayerStatsComponent>();
        movement = GetComponent<PlayerMovementComponent>();
        attack = GetComponent<PlayerAttackComponent>();

        playerStats.OnDeath += playerStats.SetIsDead;
        playerStats.OnIsDeadUpdated += Death;

        //test = GetComponent<GameObject>();
        //InvokeRepeating(nameof(Detect), 0, customTickRate);
        //OnHitGround += SetWorldPosition;

    }

    void Death()
    {
        Time.timeScale = 0;
        Destroy(this.gameObject);
        EntityManager.Instance.RemoveAll();
        double _score = Math.Round(Spawner.Instance.TotalTimer, 2);
        score = _score;
        Cursor.lockState = CursorLockMode.None;
        //Debug.Log(_score);
    }

    //void Detect()
    //{
    //    if (!playerStats) return;
    //    Vector2 _pos2D = rotate.ReadValue<Vector2>();
    //    Vector3 _pos = new Vector3(_pos2D.x, _pos2D.y, 0);
    //    screenRay = Camera.main.ScreenPointToRay(_pos);

    //    bool _hitGround = Physics.Raycast(screenRay, out RaycastHit _result, detectionRange, maskGround);
    //    detected = _hitGround;
    //    if (_hitGround)
    //    {
    //        OnHitGround?.Invoke(_result.point);
    //    }
    //}

    //void SetWorldPosition(Vector3 _pos)
    //{
    //    worldPosition = _pos;
    //    OnWorldPositionSet?.Invoke();
    //}
}
