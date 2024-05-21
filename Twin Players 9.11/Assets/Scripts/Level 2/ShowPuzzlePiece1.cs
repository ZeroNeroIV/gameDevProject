using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPuzzlePiece1 : MonoBehaviour
{
    [SerializeField] private GameObject cage;
    private readonly Vector3 _cageRotation = new(2.5f, 5f, 3f);
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        cage.transform.Rotate(_cageRotation * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Destroy(cage);
            Destroy(this);
        }
    }
}
