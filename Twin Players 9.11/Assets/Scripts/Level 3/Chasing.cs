using UnityEngine;
public class Chasing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 100;
    private const float RotationSpeed = 70f;
    private GameObject _player1;
    private GameObject _player2;

    private void Start()
    {
        _player1 = GameObject.Find("Player 1");
        _player2 = GameObject.Find("Player 2");
    }

    private void Update()
    {
        //  float x = 0, y = 0, z = 0;
        //  transform.LookAt(p.transform);
        var target1 = _player1.transform;
        var target2 = _player2.transform;

        // Calculate the direction vector
        var direction = Vector3.Min(target1.position - gameObject.transform.position, target2.position - gameObject.transform.position);
        var closestTarget = direction.Equals(target2.position - gameObject.transform.position) ? target2 : target1;
        direction.y = 0; // Optional: Keep the y component zero to only rotate on the y-axis

        // Calculate the rotation towards the target
        var targetRotation = Quaternion.LookRotation(direction);
        // Smoothly rotate towards the target
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(closestTarget.position.x , gameObject.transform.position.y , closestTarget.position.z), speed * Time.deltaTime);
    }
}
