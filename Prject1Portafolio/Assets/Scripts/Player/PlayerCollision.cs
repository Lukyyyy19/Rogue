using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStatesScript;

public class PlayerCollision : MonoBehaviour
{
    PlayerMovement _playerMovement;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Wall")){
            _playerMovement._playerInputs.PlayerStates1 = PlayerStates.Stay;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<IInteracteable>() == null) return;
        var coins = other.GetComponent<IInteracteable>().Interact();
        Debug.Log(coins);
    }

}
