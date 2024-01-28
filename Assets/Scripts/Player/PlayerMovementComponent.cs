using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50;

    [SerializeField] Player player = null;
    [SerializeField] PlayerStatsComponent playerStats = null;
    [SerializeField] float maxCoordinate = 125;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    void Init()
    {
        player = GetComponent<Player>();
        playerStats = GetComponent<PlayerStatsComponent>();
        //player.OnWorldPositionSet += Rotate;
    }

    void Move()
    {
        if(!player ||  !playerStats) return;
        Vector3 _movementDirection = player.Move.ReadValue<Vector3>();
        if(_movementDirection.z !=0 || _movementDirection.x !=0)
        {
            transform.position += transform.forward * _movementDirection.z * playerStats.MoveSpeed * Time.deltaTime;
            transform.position += transform.right * _movementDirection.x * playerStats.MoveSpeed * Time.deltaTime;
        }
        if (transform.position.x >= maxCoordinate) transform.position = new Vector3(maxCoordinate, transform.position.y, transform.position.z);
        if (transform.position.x <= -maxCoordinate) transform.position = new Vector3(-maxCoordinate, transform.position.y, transform.position.z);
        if (transform.position.z >= maxCoordinate) transform.position = new Vector3(transform.position.x, transform.position.y, maxCoordinate);
        if (transform.position.z <= -maxCoordinate) transform.position = new Vector3(transform.position.x, transform.position.y, -maxCoordinate);
    }

    public void Rotate()
    {
        if(!player || !playerStats) return;
        float _rotationValue = player.Rotate.ReadValue<float>();
        //Vector3 _lookAtDirection = player.WorldPosition - transform.position;
        //if (_lookAtDirection == Vector3.zero) return;
        //Quaternion _newRotation = Quaternion.LookRotation(_lookAtDirection);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, _newRotation, rotationSpeed * Time.deltaTime);
        transform.eulerAngles += transform.up * _rotationValue * rotationSpeed * Time.deltaTime;
    }
}
