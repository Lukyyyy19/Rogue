using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
   [SerializeField] private Transform groundPoint;
    private float distance = 0.15f;
    [SerializeField]private LayerMask groundLayer;
    PlayerMovement _playerMovement;
    private void Start() {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        _playerMovement.IsGrounded = Physics2D.Raycast(groundPoint.position,Vector2.down,distance,groundLayer);
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(groundPoint.position,Vector2.down*distance);
    }
}
