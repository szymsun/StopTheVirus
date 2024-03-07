using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D _rb;

    public float speed = 2f;
    public float groundDistance = 0.2f;

    private bool _canRun;
    private bool _grounded;
    
    [SerializeField]
    public bool canRun
    {
        get => _canRun;
        set
        {
            if (value != _canRun)
            {
                if (value)
                {
                    EnableShit();
                    _canRun = true;
                }
                else
                {
                    DisableShit();
                    _canRun = false;
                }
            }
        }
    }
    public LayerMask groundMask;
    
    
    private Vector2 _velocity;
    private float _xInput;
    private bool _jump, _attack;

    private bool IsGrounded
    {
        get
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundMask);
            if (hit.collider.gameObject.layer == groundMask)
            {
                _grounded = true;
                return true;
            }

            _grounded = false;
            return false;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _canRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canRun)
            GetInput();
    }

    private void FixedUpdate()
    {
        if (canRun)
        {
            // apply physics
            Move();
            Jump();
        }
    }

    void GetInput()
    {
        _xInput = Input.GetAxis("Horizontal");
        _jump = Input.GetKey(KeyCode.W);
        _attack = Input.GetKey(KeyCode.Space);
    }

    void Move()
    {
        _rb.velocity = new Vector2(_xInput, _rb.velocity.y);
    }

    void Jump()
    {
        if (_jump && IsGrounded)
        {
            _rb.AddForce(Vector2.up, ForceMode2D.Impulse);
        }
    }

    void EnableShit()
    {
        _rb.simulated = true;
    }

    void DisableShit()
    {
        _rb.simulated = false;
    }
}
