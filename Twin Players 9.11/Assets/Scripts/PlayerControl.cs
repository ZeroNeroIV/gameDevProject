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
    // The following is for player input, movement, looking and jumping inputs are all taken from it.
    // They are all connected to the PlayerInput, which is attached to the player as a component.
    // Their setup is as follows:

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

    //? Bullet game objects -- for shooting
    private const int BulletCount = 4;
    private int _currentBullet;
    private GameObject[] _bullets;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject iceBullet;
    [SerializeField] private GameObject stunBullet;
    [SerializeField] private GameObject poisonBullet;

    //? Shooting position -- the position for the bullets to be instantiated from.
    private GameObject _shootingPosition;

    //? Movement speed
    private const float MovementSpeed = 50f;

    //? Rotation speed
    // private const float RotationSpeed = 50f;
    private const float RotationSpeed = 25f;
    private const float ClampValue = .9f;
    private Vector2 _currentRotation = Vector2.zero;

    //? Jump height
    private const float JumpHeight = 30f;

    //? Jumping delay
    private bool _delayJump;
    private const int DefaultDelayJumpTime = 30;
    private int _delayJumpTime = DefaultDelayJumpTime;



    //------------------------------------------------------------------------------------------------------------//

    private void Start()
    {
        _bullets = new[] { bullet, iceBullet, stunBullet, poisonBullet };

        // continuing the setup for each input action

        _head = GameObject.Find($"{gameObject.name}/Head");
        //? Accessing the "Rigidbody" component.
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = true;
        _rb.velocity = 10 * Vector3.down;
    }

    // Update is called once per frame
    private void Update()
    {
        MoveAndLook();
        //? Equipping
        // For easiness, if the player moves through an equitable object, the player equips it.
        Equip();
    }

    private void OnMove(InputValue val)
    {
        _movementActionValue = val.Get<Vector2>() * (Time.deltaTime * MovementSpeed);
    }
    private void OnLook(InputValue val)
    {
        _lookActionValue = val.Get<Vector2>();
    }

    private void MoveAndLook()
    {
        gameObject.transform.Translate(new Vector3(_movementActionValue.y, 0f, -_movementActionValue.x) * (Time.deltaTime * MovementSpeed));

        _currentRotation.y -= _lookActionValue.x;
        _currentRotation.x += _lookActionValue.y;
        _currentRotation.x = Mathf.Clamp(_lookActionValue.y, -ClampValue, ClampValue) * Mathf.Deg2Rad * RotationSpeed;
        _head.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, _currentRotation.x));
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, -_currentRotation.y, 0f));
    }

    private void OnChangeWeapon(InputValue val)
    {
        var value = val.Get<float>();
        _currentBullet = value switch
        {
            > 0 => (_currentBullet + 1) % BulletCount,
            < 0 => (_currentBullet - 1 + BulletCount) % BulletCount,
            _ => _currentBullet
        };
    }

    private void OnJump(InputValue val)
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
            if (--_delayJumpTime > 0) return;
            _delayJump = false;
            _delayJumpTime = DefaultDelayJumpTime;
        }
    }

    private void Equip()
    {
    }

    private void OnFire(InputValue val)
    {
        Instantiate(_bullets[_currentBullet], _shootingPosition.transform.position, _shootingPosition.transform.rotation);
    }
}
