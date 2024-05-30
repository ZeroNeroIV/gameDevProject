using UnityEngine;
using UnityEngine.InputSystem;

/*
    This script controls all the basic player actions.
    Like: Move, Look, Jump, Fire, Changing weapons
    --ZeroNeroIV--
*/
public class PlayerControl : MonoBehaviour
{
    // Material
    private static Material _player1Material;
    private static Material _player2Material;
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
    private const float MovementSpeed = 45f;
    private bool _canMove = true;

    //? Rotation speed
    public float rotationSpeed = 35f;
    private const float ClampValue = 45f;
    private Vector2 _currentRotation = Vector2.zero;

    //? Jump height
    private const float JumpHeight = 30f;
    //------------------------------------------------------------------------------------------------------------//
    private void Start()
    {
        GameObject.Find($"{gameObject.name}/Body").GetComponent<Renderer>().material = gameObject.name == "Player 1" ? _player1Material : _player2Material;
        // All bullet types.
        _bullets = new[] { bullet, iceBullet, stunBullet, poisonBullet };
        // Head of the player.
        _head = GameObject.Find($"{gameObject.name}/Head");
        // Shooting point.
        _shootingPosition = GameObject.Find($"{gameObject.name}/Head/Shooting Point");
        // Accessing the "Rigidbody" component.
        _rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
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
        // Adjust the current rotation values based on input
        _currentRotation += new Vector2(-Mathf.Clamp(_lookActionValue.y, -ClampValue, ClampValue + 45f), _lookActionValue.x);

        // Apply the rotations to the head and body
        _head.transform.localRotation = Quaternion.Euler(_currentRotation.x * (Gamepad.current is not null ? 7f : 1), 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, _currentRotation.y * (Gamepad.current is not null ? 7f : 1), 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terrain") || other.CompareTag("Plate"))
            _canMove = true;
        if (other.CompareTag("MaterialExchange"))
        {
            GameObject.Find($"{gameObject.name}/Body").GetComponent<Renderer>().material =
                other.gameObject.GetComponent<Renderer>().material;
            if (gameObject.name.Equals("Player 1"))
                _player1Material = other.gameObject.GetComponent<Renderer>().material;
            else
                _player2Material = other.gameObject.GetComponent<Renderer>().material;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Terrain") || other.CompareTag("Plate"))
            _canMove = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Terrain") || other.CompareTag("Plate"))
            _canMove = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Terrain") || other.collider.CompareTag("Plate"))
            _canMove = true;
        if (other.collider.CompareTag("MaterialExchange"))
        {
            GameObject.Find($"{gameObject.name}/Body").GetComponent<Renderer>().material =
                other.gameObject.GetComponent<Renderer>().material;
            if (gameObject.name.Equals("Player 1"))
                _player1Material = other.gameObject.GetComponent<Renderer>().material;
            else
                _player2Material = other.gameObject.GetComponent<Renderer>().material;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("Terrain") || other.collider.CompareTag("Plate"))
            _canMove = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Terrain") || other.collider.CompareTag("Plate"))
            _canMove = false;
    }

    // Gets movement input values.
    private void OnMove(InputValue val) => _movementActionValue = val.Get<Vector2>() * (MovementSpeed * Time.deltaTime);
    // Gets looking input values.
    private void OnLook(InputValue val) => _lookActionValue = val.Get<Vector2>() * (rotationSpeed * Time.deltaTime);

    // Changes Bullet Type.
    private void OnWeaponChange(InputValue val) => _currentBullet = val.Get<float>() switch
    {
        > 0 => (_currentBullet + 1) % BulletCount,
        < 0 => (_currentBullet - 1 + BulletCount) % BulletCount,
        _ => _currentBullet
    };

    // Jumping when the corresponding input is pressed.
    // To jump smoothly, using rigidbody "AddForce" Method instead of normal position update.
    private void OnJump(InputValue val)
    {
        if (!_canMove) return;
        _rb.AddForce(Vector3.up * JumpHeight, ForceMode.VelocityChange);
    }

    // Shooting when the corresponding input is pressed.
    private void OnFire(InputValue val) => Instantiate(_bullets[_currentBullet], _shootingPosition.transform.position, _shootingPosition.transform.rotation);
}
