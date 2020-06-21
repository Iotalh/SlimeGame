using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public Animator _actionController;
    public bool _idle;
    public bool _walk;
    public bool _attack;
    public bool _air;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        _actionController.SetBool("Idle", _idle);
        _actionController.SetBool("Walk", _walk);
        _actionController.SetBool("Attack", _attack);
        _actionController.SetBool("Air", _air);
        Walk();
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    public void Walk()
    {
        if (!controller.m_Grounded)
        {
            _idle = false;
            _walk = false;
            _attack = false;
            _air = true;
        }
        else if (Input.GetAxisRaw("Horizontal") != 0)
        {
            _idle = false;
            _walk = true;
            _attack = false;
            _air = false;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            _idle = true;
            _walk = false;
            _attack = false;
            _air = false;
        }
    }
}