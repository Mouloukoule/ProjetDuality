using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] int energyToGive = 5;

    private void OnTriggerEnter(Collider other)
    {
        Player _player = other.GetComponent<Player>();
        if (!_player) return;
        _player.PlayerStats.AddEnergy(energyToGive);
        Destroy(this.gameObject);
    }
}
