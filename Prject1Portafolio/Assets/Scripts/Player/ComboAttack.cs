using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStatesScript;
public class ComboAttack : MonoBehaviour
{
    [SerializeField] public Queue<PlayerStates> _comboQueue;
    PlayerMovement _playerMovement;
    public bool canAttack1;
    public bool canAttack2;
    public bool canAttack3;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _comboQueue = new Queue<PlayerStates>();
    }

    void Update()
    {
        if (_playerMovement._playerInputs.PlayerStates1 == PlayerStates.Attack)
        {
            //Invoke("QuitarAccion", 1f);
            _comboQueue.Enqueue(_playerMovement._playerInputs.PlayerStates1);
        }
        Debug.Log(_comboQueue.Count);
        if (_comboQueue.Count > 0)
        {

            if (_comboQueue.Peek() == PlayerStates.Attack)
            {
                canAttack1 = true;
               // QuitarAccion();
            }

        }
        else if (_comboQueue.Count > 1)
        {

            if (_comboQueue.Peek() == PlayerStates.Attack)
            {
                canAttack1 = true;
                canAttack2 = true;
               // QuitarAccion();
            }

        }
        else if (_comboQueue.Count > 2)
        {

            if (_comboQueue.Peek() == PlayerStates.Attack)
            {
                canAttack1 = true;
                canAttack2 = true;
                canAttack3 = true;
               // QuitarAccion();
            }

        }
        
        if(_comboQueue.Count == 0){
            _playerMovement._playerInputs.PlayerStates1 = PlayerStates.Stay;
        }
    }

    public void QuitarAccion()
    {
        if(_comboQueue.Count>0)
            _comboQueue.Dequeue();
    }
}
