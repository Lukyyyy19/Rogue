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
        Debug.Log(_playerMovement._playerInputs.PlayerStates1);

    }
    void LateUpdate()
    {
        anim.SetBool("IsWalking", _playerMovement.IsMoving);
        anim.SetBool("IsGrounded", _playerMovement.IsGrounded);
        anim.SetFloat("VelocityY 0", _playerMovement.Rigidbody2D.velocity.y);

        if (_playerMovement._playerInputs.PlayerStates1 == PlayerStatesScript.PlayerStates.Attack)
        {
            anim.SetTrigger("Attack");
            animStateInfo = anim.GetCurrentAnimatorStateInfo(0);
            var animTime = animStateInfo.normalizedTime;
            Debug.Log(animTime);
            if (animTime > 1.0f) animationFinished = true;
            if (animationFinished)
            {
                _playerMovement._playerInputs.PlayerStates1 = PlayerStatesScript.PlayerStates.Stay;
            }
        }








    }
}
