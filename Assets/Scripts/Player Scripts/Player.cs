using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 8f;
    public float MaxVelocity = 4f;

    private Rigidbody2D _playerBody;
    private Animator _playerAnimation;

    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }


    private void PlayerMoveKeyboard()
    {
        var forceX = 0f;
        var velocity = Math.Abs(_playerBody.velocity.x);
        var xAxis = Input.GetAxisRaw("Horizontal");
        var scale = transform.localScale;


        // Going right
        if (xAxis > 0)
        {
            if (velocity < MaxVelocity)
            {
                scale.x = 1f;
                transform.localScale = scale;
                forceX = Speed;
                _playerAnimation.SetBool("Walk", true);
            }
        }
        else if (xAxis < 0)
        {
            if (velocity < MaxVelocity)
            {
                scale.x = -1f;
                transform.localScale = scale;
                forceX = -Speed;
                _playerAnimation.SetBool("Walk", true);
            }
        }
        else
        {
            _playerAnimation.SetBool("Walk", false);
        }

        _playerBody.AddForce(new Vector2(forceX, 0));
    }
}