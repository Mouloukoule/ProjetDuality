using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerStatsComponent playerStats = null;
    public PlayerStatsComponent PlayerStats => playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStatsComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
