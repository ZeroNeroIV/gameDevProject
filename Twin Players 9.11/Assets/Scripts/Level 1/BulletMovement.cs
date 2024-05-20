using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletMovement = 10f;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        _rb.mass = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        _rb.AddRelativeForce(0f, 0f, bulletMovement, ForceMode.VelocityChange);
    }
}
