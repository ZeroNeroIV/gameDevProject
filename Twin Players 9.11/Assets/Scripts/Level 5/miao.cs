using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
    // Speed of the plane
    public float speed = 5f;

    private Vector2 movementInput;

    void Update()
    {
        // Move the plane based on the input
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
