using UnityEngine;
using UnityEngine.InputSystem;
public class PlaneMovement : MonoBehaviour
{
    private const float Speed = 150f;
    private Vector2 _movementValue;

    private void Update()
    {
        transform.Translate(0f, 0f, _movementValue.y);
        transform.Rotate(0f, _movementValue.x, 0f);
    }
    private void OnMove(InputValue val){
        _movementValue = val.Get<Vector2>() * (Speed * Time.deltaTime);
    }
}
