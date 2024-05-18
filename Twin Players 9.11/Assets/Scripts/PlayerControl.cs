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

    private InputAction _fireAction;
    // And continued in the "Start" functions.
    // Each input action is used in a separate function that is called in "Update".

    //------------------------------------------------------------------------------------------------------------//

    //! NEW INPUT SYSTEM VARIABLES:
    // Each variable is used for its corresponding action.

    //** MOVEMENT: This variable is used to store the value of the movement action.
    //? (Press/Hold) - (Changing the X and Z axes for Position)
    private Vector2 _movementActionValue;

    //** LOOK: This variable is used to store the value of the look action.
    //? (Press/Hold) - (Changing the X and Y axes for Rotation)
    private Vector2 _lookActionValue;

    //** FIRE: This variable is used to store the value of the fire action.
    //? (Press)
    private bool _fireActionValue;

    //------------------------------------------------------------------------------------------------------------//

    //! CUSTOM VARIABLES:

    private GameObject _head;

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
    private const float ClampValue = .45f;
    private Vector3 _currentRotation = Vector3.zero;

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

        _head = GameObject.Find($"{gameObject.name}/Head");
        //? Accessing the "Rigidbody" component.
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = true;
        _rb.velocity = 10 * Vector3.down;
    }

    // Update is called once per frame
    private void Update()
    {
        //? Equipping
        // For easiness, if the player moves through an equitable object, the player equips it.
        Equip();
    }

    private void OnMove(InputValue val)
    {
        _movementActionValue = val.Get<Vector2>() * (Time.deltaTime * MovementSpeed);
        gameObject.transform.Translate(new Vector3(_movementActionValue.y, 0, -_movementActionValue.x));
    }

    private void OnLook(InputValue val)
    {

        _lookActionValue = val.Get<Vector2>();
        _currentRotation.z = _lookActionValue.y;
        _currentRotation.y = Mathf.Clamp(_lookActionValue.x, -ClampValue, ClampValue);
        _head.transform.rotation = Quaternion.Euler(_currentRotation);
    }

    private void OnJump()
    {
        // If the action is triggered, there will be a delay for the next jump
        if (!_delayJump)
        {
            // To jump smoothly, using rigidbody "AddForce" Method instead of normal position update.
            _rb.AddForce(Vector2.up * JumpHeight, ForceMode.Impulse);
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

    private void Equip()
    {
    }

    private void OnFire(InputValue val)
    {
        Instantiate(bullet, _shootingPosition.transform.position, _shootingPosition.transform.rotation);
    }
}
