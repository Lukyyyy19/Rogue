using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStatesScript;
public class PlayerInputs
{
    private const float _maxError = 1f;
    private const float _minError = -_maxError;
    private PlayerStates playerStates1;
    public PlayerStates PlayerStates1 { get => playerStates1; set => playerStates1 = value;}
    #region Android
#if UNITY_ANDROID
    Touch _touch;
    Vector2 _touchStartPosition;
    Vector2 _touchEndPosition;
    Vector2 _touchDeltaPosition;
    public bool moveRight;
    public bool moveLeft;


    public void AndroidSystem()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                _touchStartPosition = Camera.main.ScreenToWorldPoint(_touch.position);
            }
            else if (_touch.phase == TouchPhase.Ended)
            {
                _touchEndPosition = Camera.main.ScreenToWorldPoint(_touch.position);
                _touchDeltaPosition = _touchEndPosition - _touchStartPosition;
                if (_touchDeltaPosition.x > 0 && _touchDeltaPosition.y > _minError && _touchDeltaPosition.y < _maxError)
            {               
                PlayerStates1 = PlayerStates.Right;
            }
            else if (_touchDeltaPosition.x < 0 && _touchDeltaPosition.y > _minError && _touchDeltaPosition.y <_maxError)
            {
                PlayerStates1 = PlayerStates.Left;
            }
            else if (_touchDeltaPosition.y < 0 && _touchDeltaPosition.x > _minError && _touchDeltaPosition.x <_maxError)
            {
                PlayerStates1 = PlayerStates.Stay;
            }
            else if (_touchDeltaPosition.y > 0 && _touchDeltaPosition.x > _minError*1.5f && _touchDeltaPosition.x <_maxError*1.5f)
            {
                PlayerStates1 = PlayerStates.Jump;
            }
            else if(Mathf.Approximately(0,_touchDeltaPosition.x) && Mathf.Approximately(0,_touchDeltaPosition.y)){
                PlayerStates1 = PlayerStates.Attack;
            }
            }
        }
    }
#endif
    #endregion
    #region PC
#if UNITY_EDITOR
    Vector2 _mouseStartPosition;
    Vector2 _mouseEndPosition;
    Vector2 _mouseDeltaPosition;
    public bool moveRightUE;
    public bool moveLeftUE;
    public bool jumpUE;
    public bool attackUE;
    public bool stayUE;


    public void PCSystem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _mouseEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mouseDeltaPosition = _mouseEndPosition -= _mouseStartPosition;
            if (_mouseDeltaPosition.x > 0 && _mouseDeltaPosition.y > _minError && _mouseDeltaPosition.y < _maxError)
            {
                PlayerStates1 = PlayerStates.Right;
            }
            else if (_mouseDeltaPosition.x < 0 && _mouseDeltaPosition.y > _minError && _mouseDeltaPosition.y <_maxError)
            {
                PlayerStates1 = PlayerStates.Left;
            }
            else if (_mouseDeltaPosition.y < 0 && _mouseDeltaPosition.x > _minError && _mouseDeltaPosition.x <_maxError)
            {
                PlayerStates1 = PlayerStates.Stay;
            }
            else if (_mouseDeltaPosition.y > 0 && _mouseDeltaPosition.x > _minError*1.5f && _mouseDeltaPosition.x <_maxError*1.5f)
            {
                PlayerStates1 = PlayerStates.Jump;
            }
            else if(Mathf.Approximately(0,_mouseDeltaPosition.x) && Mathf.Approximately(0,_mouseDeltaPosition.y)){
                PlayerStates1 = PlayerStates.Attack;
            }
        }
    }
#endif
    #endregion
}
