using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private PlayerInput playerInput;    
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction lookAction;
    private InputAction equipAction;
    private InputAction fireAction;

    private Vector2 movementActionValue;
    private Vector2 lookActionValue;
    private bool jumpActionValue;
    private bool fireActionValue;
    private bool equipActionValue;

    private float movementSpeed = 50f;
    private float rotationSpeed = 50f;
    private bool delayJump = false;
    private const int defaultDelayJumpTime = 50;
    private int delayJumpTime = defaultDelayJumpTime;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        lookAction = playerInput.actions["Look"];
        equipAction = playerInput.actions["Equip"];
        fireAction = playerInput.actions["Fire"];
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        LookPlayer();
        if (!delayJump)
            JumpPlayer();
        else
        {
            if (--delayJumpTime == 0)
            {
                delayJump= false;
                delayJumpTime = defaultDelayJumpTime;
            }
        }
    }

    void MovePlayer() {
        movementActionValue = moveAction.ReadValue<Vector2>();
        gameObject.transform.Translate(new Vector3(movementActionValue.y, 0, -movementActionValue.x) * Time.deltaTime * movementSpeed);
    }

    void LookPlayer() {
        lookActionValue = lookAction.ReadValue<Vector2>();
        gameObject.transform.Rotate(new Vector3(0, lookActionValue.x, 0) * Time.deltaTime * rotationSpeed);
    }

    void JumpPlayer() {
        jumpActionValue = jumpAction.triggered;
        if (jumpActionValue) {
            gameObject.transform.position += (new Vector3(0, 3, 0) * Time.deltaTime * movementSpeed);
        }
        delayJump = jumpActionValue;
    }
}
