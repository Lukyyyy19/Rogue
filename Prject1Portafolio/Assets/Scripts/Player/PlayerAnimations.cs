using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    PlayerMovement _playerMovement;
    ComboAttack _comboAttack;
    
    AnimatorStateInfo animStateInfo;
    bool animationFinished;
    void Start()
    {
        anim = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _comboAttack = GetComponent<ComboAttack>();
    }

    private void Update()
    {
        if (_playerMovement._playerInputs.PlayerStates1 == PlayerStatesScript.PlayerStates.Attack){
            // if (_comboAttack.canAttack1)
            // {
                anim.SetTrigger("Attack");
                // _comboAttack.canAttack1 =false;
                // _comboAttack.QuitarAccion();
            }
        

        // else if(_comboAttack.canAttack2){
        //     anim.SetTrigger("Attack1");
        //     _comboAttack.canAttack2 = false;
        //     _comboAttack.QuitarAccion();
        // }
        // else if(_comboAttack.canAttack3){
        //     anim.SetTrigger("Attack2");
        //     _comboAttack.canAttack3 = false;
        //     _comboAttack.QuitarAccion();
        // }
    }
    void LateUpdate()
    {
        anim.SetBool("IsWalking", _playerMovement.IsMoving);
        anim.SetBool("IsGrounded", _playerMovement.IsGrounded);
        anim.SetFloat("VelocityY 0", _playerMovement.Rigidbody2D.velocity.y);
    }

    public void ResetTrigger(string triggerName)
    {
        // if(_comboAttack._comboQueue.Count==0){
            _playerMovement._playerInputs.PlayerStates1 = PlayerStatesScript.PlayerStates.Stay;
        // }
        anim.ResetTrigger(triggerName);
    }
}
