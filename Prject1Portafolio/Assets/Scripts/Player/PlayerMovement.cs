using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStatesScript;
public class PlayerMovement : MonoBehaviour
{
    public PlayerInputs _playerInputs;
    Rigidbody2D _rigidbody2D;
    public float speed = 5f;
    public float jumpForce = 5f;
    [SerializeField] private bool isGrounded;
    private float jumpTime;
    private float coyoteTime;
    private float coyoteTimeStart = 0.25f;
    private bool isMoving;
    [SerializeField] private float startJumpTime;
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
    public bool IsMoving { get => isMoving; }
    public Rigidbody2D Rigidbody2D { get => _rigidbody2D; }

    private void Start()
    {
        _playerInputs = new PlayerInputs();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInputs.PlayerStates1 = PlayerStates.Stay;
    }
    void Update()
    {
#if UNITY_ANDROID
        _playerInputs.AndroidSystem();
#endif

#if UNITY_EDITOR
        _playerInputs.PCSystem();
#endif
        if (!isGrounded)
        {
            jumpTime -= Time.deltaTime;
            coyoteTime += Time.deltaTime;
            if (jumpTime <= 0)
            {
                if (_playerInputs.PlayerStates1 != PlayerStates.Stay)
                    _playerInputs.PlayerStates1 = PlayerStates.Fall;
            }
        }
        else
        {
            jumpTime = startJumpTime;

            coyoteTime = 0;
        }
    }
    private void FixedUpdate()
    {
        switch (_playerInputs.PlayerStates1)
        {
            case PlayerStates.Right:
                _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
                isMoving = true;
                transform.localScale = new Vector2(1, 1);
                break;
            case PlayerStates.Left:
                _rigidbody2D.velocity = new Vector2(-speed, _rigidbody2D.velocity.y);
                isMoving = true;
                transform.localScale = new Vector2(-1, 1);
                break;
            case PlayerStates.Stay:
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
                isMoving = false;
                break;
            case PlayerStates.Jump:
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);

                if (coyoteTime < coyoteTimeStart && !isGrounded)
                {
                    _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
                }
                break;
            case PlayerStates.Fall:
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y);
                isMoving = false;
                break;
        }
    }

}
