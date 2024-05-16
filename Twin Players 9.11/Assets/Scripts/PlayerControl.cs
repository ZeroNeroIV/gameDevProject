using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

/*
    This script controls all the basic player actions.
    Like: Move, Look, Jump, Equip, Fire
    --ZeroNeroIV--
*/

public class PlayerControl : MonoBehaviour
{
    //! NEW INPUT SYSTEM:
    // The following is for player input, movement, looking and jumping inputs are all taken from it.
    // They are all connected to the PlayerInput, which is attached to the player as a component.
    // Their setup is as follows:
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _lookAction;

    private InputAction _fireAction;
    // And continued in the "Start" functions.
    // Each input action is used in a separate function that is called in "Update".

    //------------------------------------------------------------------------------------------------------------//

    //! NEW INPUT SYSTEM VARIABLES:
    // Each variable is used for its corresponding action.

    //** MOVEMENT: This variable is used to store the value of the movement action.
    //? (Press/Hold) - (Changing the X and Z axises for Position)
    private Vector2 _movementActionValue;

    //** LOOK: This variable is used to store the value of the look action.
    //? (Press/Hold) - (Changing the X and Y axises for Rotation)
    private Vector2 _lookActionValue;

    //** FIRE: This variable is used to store the value of the fire action.
    //? (Press)
    private bool _fireActionValue;

    //------------------------------------------------------------------------------------------------------------//

    //! CUSTOM VARIABLES:

    //? Rigidbody -- for better physics
    private Rigidbody _rb;

    //? Bullet game object -- for shooting
    [SerializeField] private GameObject bullet;

    //? Shooting position -- the position for the bullets to be instantiated from.
    private GameObject _shootingPosition;

    //? Movement speed
    private const float MovementSpeed = 50f;

    //? Rotation speed
    private const float RotationSpeed = 50f;

    //? Jump height
    private const float JumpHeight = 30f;

    //? Jumping delay
    private bool _delayJump = false;
    private const int DefaultDelayJumpTime = 150;
    private int _delayJumpTime = DefaultDelayJumpTime;

    //------------------------------------------------------------------------------------------------------------//

    private void Start()
    {
        // continuing the setup for each input action:

        //? Accessing the "PlayerInput" component.
        _playerInput = GetComponent<PlayerInput>();
        /*
            NOTE:
            -- _playerInput is attached to the player as a component.
            -- IMPORTANT:
                After attaching the "Action" InputAction to the PlayerInput,
                the "Default Map" should be set up depending on each Player (it varies for different players).
        */
        //? Setting up each input action:
        _moveAction = _playerInput.actions["Move"];
        _jumpAction = _playerInput.actions["Jump"];
        _lookAction = _playerInput.actions["Look"];
        _fireAction = _playerInput.actions["Fire"];

        //? Accessing the "Rigidbody" component.
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //? Moving the player
        MovePlayer();

        //? Rotating the player/camera
        LookPlayer();

        //? Jumping
        // If the key assigned for jumping is triggered (Press), the player jumps.
        Jump();

        //? Equipping
        // For easiness, if the player moves through an equitable object, the player equips it.
        Equip();

        //? Shooting
        // If the key assigned for shooting bullets is triggered (Press/Hold), the player shoots bullets.
        Shooting();
    }

    // Function to move the player according to its inputs.
    private void MovePlayer()
    {
        _movementActionValue = _moveAction.ReadValue<Vector2>() * (Time.fixedDeltaTime * MovementSpeed);
        gameObject.transform.Translate(new Vector3(_movementActionValue.y, 0, -_movementActionValue.x));
    }

    // Function to rotate the player according to its inputs.
    private void LookPlayer()
    {
        _lookActionValue = _lookAction.ReadValue<Vector2>() * (Time.fixedDeltaTime * RotationSpeed);
        gameObject.transform.Rotate(new Vector3(0, _lookActionValue.x, 0));
    }

    // Function to make the player jump according to its inputs.
    private void Jump()
    {
        // If the action is triggered, there will be a delay for the next jump
        if (!_delayJump)
        {
            if (_jumpAction.triggered)
            {
                // To jump smoothly, using rigidbody "AddForce" Method instead of normal position update.
                _rb.AddForce(Vector2.up * JumpHeight, ForceMode.Impulse);
            }

            _delayJump = true;
        }
        else
        {
            if (--_delayJumpTime == 0)
            {
                _delayJump = false;
                _delayJumpTime = DefaultDelayJumpTime;
            }
        }
    }

    // Function to let the player pick/equip equitable objects.
    private void Equip()
    {
    }

    // Function to shoot bullets according to the player's inputs.
    private void Shooting()
    {
        _fireActionValue = _fireAction.ReadValue<bool>();
        if (_fireActionValue)
            Instantiate(bullet, _shootingPosition.transform.position, _shootingPosition.transform.rotation);
    }
}
