using UnityEngine;
using UnityEngine.InputSystem;
public class movement : MonoBehaviour
{
    private const float Speed = 150f;
    private Vector2 _movementValue;

    private void Update()
    {
        transform.Translate(_movementValue.x*(Speed * Time.deltaTime), 0f, _movementValue.y* (Speed * Time.deltaTime));
        transform.Rotate(0f, _movementValue.x, 0f);
    }
    private void OnMove(InputValue val){
        _movementValue = val.Get<Vector2>() * (Speed * Time.deltaTime);
    }
}
