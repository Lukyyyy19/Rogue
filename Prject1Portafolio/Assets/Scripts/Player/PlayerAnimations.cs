using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    PlayerMovement _playerMovement;
    PlayerInputs _playerInput = new PlayerInputs();
    AnimatorStateInfo animStateInfo;
    bool animationFinished;
    void Start()
    {
        anim = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_playerMovement._playerInputs.PlayerStates1 == PlayerStatesScript.PlayerStates.Attack)
        {
            anim.SetTrigger("Attack");
        }
    }
    void LateUpdate()
    {
        anim.SetBool("IsWalking", _playerMovement.IsMoving);
        anim.SetBool("IsGrounded", _playerMovement.IsGrounded);
        anim.SetFloat("VelocityY 0", _playerMovement.Rigidbody2D.velocity.y);
    }

    public void ResetTrigger(string triggerName)
    {
        _playerMovement._playerInputs.PlayerStates1 = PlayerStatesScript.PlayerStates.Stay;
        anim.ResetTrigger(triggerName);
    }
}
