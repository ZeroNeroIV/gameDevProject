using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlaneMovment : MonoBehaviour
{
    private const float _speed = 150f;
    private Vector2 _movementValue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, _movementValue.y);
        transform.Rotate(0f, _movementValue.x, 0f);
    }
    private void OnMove(InputValue val){
        _movementValue = val.Get<Vector2>()*_speed* Time.deltaTime;
    }
}
