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

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }


    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float velocity = Math.Abs(_playerBody.velocity.x);

        float xAxis = Input.GetAxisRaw("Horizontal");


        // Going right
        if (xAxis > 0)
        {
            if (velocity < MaxVelocity)
            {
                forceX = Speed;
                _playerAnimation.SetBool("Walk", true);
            }
        }
        else if (xAxis < 0)
        {
            if (velocity < MaxVelocity)
            {
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