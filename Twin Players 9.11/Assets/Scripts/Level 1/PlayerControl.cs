using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

/*
    This script controls all the basic player actions.
    Like: Move, Look, Jump, Equip, Fire
    --ZeroNeroIV--
*/

public class PlayerControl : MonoBehaviour
{
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
    private const float MovementSpeed = 40f;
    private bool _canMove = true;

    //? Rotation speed
    private const float RotationSpeed = 10f;
    private const float ClampValue = 30f;
    private Vector2 _currentRotation = Vector2.zero;

    //? Jump height
    private const float JumpHeight = 70f;

    //------------------------------------------------------------------------------------------------------------//

    private void Start()
    {
        // All bullet types.
        _bullets = new[] { bullet, iceBullet, stunBullet, poisonBullet };
        // Shooting point.
        _shootingPosition = GameObject.Find($"{gameObject.name}/Head/Shooting Point");
        // Head of the player.
        _head = GameObject.Find($"{gameObject.name}/Head");
        // Accessing the "Rigidbody" component.
        _rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        MoveAndLook();
    }

    // When this gameObject collides - once for every new collision - with any collider.
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Terrain") || other.collider.CompareTag("Plate"))
            _canMove = true;

    }

    // When this gameObject exits/ends a collision - once for every collision exit - with any collider.
    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Terrain") || other.collider.CompareTag("Plate"))
            _canMove = false;
    }

    private void MoveAndLook()
    {
        // Movement
        if (_canMove)
            _rb.AddRelativeForce(new Vector3(_movementActionValue.x, 0f, _movementActionValue.y), ForceMode.VelocityChange);
        if (_canMove && _movementActionValue.Equals(new Vector2(0f, 0f)))
        {
            _rb.isKinematic = true;
            _rb.isKinematic = false;
        }
        // Looking
        _currentRotation.y -= _lookActionValue.x;
        _currentRotation.x += _lookActionValue.y;

        var newXRotation = Mathf.Clamp(_currentRotation.x - _lookActionValue.x, -ClampValue, ClampValue);
        var newYRotation = _currentRotation.y - _lookActionValue.y;

        _currentRotation.x = (_currentRotation.x + 360f) % 360f;

        if (_currentRotation.x > 180f)
            _currentRotation.x -= 360f;

        _currentRotation.x = Mathf.Clamp(_currentRotation.x, -ClampValue, ClampValue);

        //?OPTIONAL: Try using Rigidbody.MoveRotation();
        _head.transform.localRotation = Quaternion.Euler(new Vector3(-newXRotation, 0f, 0f));
        transform.localRotation = Quaternion.Euler(Vector3.up * (2f * -newYRotation));
    }

    // Gets movement input values.
    private void OnMove(InputValue val) => _movementActionValue = val.Get<Vector2>() * (MovementSpeed * Time.deltaTime);
    // Gets looking input values.
    private void OnLook(InputValue val) => _lookActionValue = val.Get<Vector2>() * (RotationSpeed * Time.deltaTime);

    // Changes Bullet Type.
    private void OnWeaponChange(InputValue val) => _currentBullet = val.Get<float>() switch
        {
            > 0 => (_currentBullet + 1) % BulletCount,
            < 0 => (_currentBullet - 1 + BulletCount) % BulletCount,
            _ => _currentBullet
        };

    // Jumping when the corresponding input is pressed.
    // To jump smoothly, using rigidbody "AddForce" Method instead of normal position update.
    private void OnJump(InputValue val) => _rb.AddForce(Vector3.up * JumpHeight, ForceMode.VelocityChange);


    // Shooting when the corresponding input is pressed.
    private void OnFire(InputValue val) => Instantiate(_bullets[_currentBullet], _shootingPosition.transform.position, _shootingPosition.transform.rotation);
}
