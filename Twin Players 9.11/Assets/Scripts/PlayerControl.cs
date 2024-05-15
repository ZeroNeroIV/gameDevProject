using UnityEngine;
using UnityEngine.InputSystem;

/*  
    This script controls all the basic player actions.
    Like: Move, Look, Jump, Equip, Fire
    --ZeroNeroIV--
*/

public class PlayerControl : MonoBehaviour
{
    //! NEW INPUT SYSTEM:
    // The following is for player input, movement, looking, jumping and equipping inputs are all taken from it.
    // They are all connected to the PlayerInput, which is attached to the player as a component.
    // Their setup is as follows:
    private PlayerInput playerInput;    
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction lookAction;
    private InputAction equipAction;
    private InputAction fireAction;
    // And continued in the "Start" functions.
    // Each input action is used in a separate function that is called in "Update".

    //------------------------------------------------------------------------------------------------------------//

    //! NEW INPUT SYSTEM VARIABLES:
    // Each variable is used for its corresponding action.

    //** MOVEMENT: This variable is used to store the value of the movement action.
    //? (Press/Hold) - (Changing the X and Z axises for Position)
    private Vector2 movementActionValue;

    //** LOOK: This variable is used to store the value of the look action.
    //? (Press/Hold) - (Changing the X and Y axises for Rotation)
    private Vector2 lookActionValue;
    
    //** JUMP: This variable is used to store the value of the jump action.
    //? (Press) - (Changing the Y axis for Position) 
    private bool jumpActionValue;
    
    //** EQUIP: This variable is used to store the value of the equip action.
    //? (Press) 
    private bool fireActionValue;

    //** FIRE: This variable is used to store the value of the fire action.
    //? (Press)
    private bool equipActionValue;

    //------------------------------------------------------------------------------------------------------------//

    //! CUSTOM VARIABLES:
    
    //? Movement speed
    private float movementSpeed = 50f;
    
    //? Rotation speed
    private float rotationSpeed = 50f;
    
    //? Rigidbody
    private Rigidbody rb;

    //? Jump height
    private float jumpHeight = 25f;

    //? Jumping delay
    private bool delayJump = false;
    private const int defaultDelayJumpTime = 175;
    private int delayJumpTime = defaultDelayJumpTime;

    //------------------------------------------------------------------------------------------------------------//

    void Start()
    {
        // continuing the setup for each input action:
        
        //? Accessing the PlayerInput component.
        playerInput = GetComponent<PlayerInput>();
        /*   
            NOTE:
            -- playerInput is attached to the player as a component.
            -- IMPORTANT: 
                After attaching the "Action" InputAction to the PlayerInput,
                the "Default Map" should be set up (it varies for different players).
        */ 
        //? Setting up each input action:
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        lookAction = playerInput.actions["Look"];
        equipAction = playerInput.actions["Equip"];
        fireAction = playerInput.actions["Fire"];

        //? Accessing the Rigidbody component.
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //? Moving the player
        MovePlayer();
        
        //? Rotating the player/camera
        LookPlayer();
        
        //? Jumping the player 
        JumpPlayer();
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
        // If the action is triggered, there will be a delay for the next jump
        if (!delayJump)
        {
            jumpActionValue = jumpAction.triggered;
            if (jumpActionValue) {
                // To jump smoothly, using rigidbody force instead of normal position update.
                rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            }
            delayJump = jumpActionValue;
        }
        else
        {
            if (--delayJumpTime == 0)
            {
                delayJump= false;
                delayJumpTime = defaultDelayJumpTime;
            }
        }
    }
}
