using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MobControl : MonoBehaviour
{
    [SerializeField] private float _mobMovementSpeed = 5f;
    [SerializeField] private float _mobRotationSpeed = 15f;

    [SerializeField] private Transform _chasedObjectPTransform;

    // Start is called before the first frame update
    void Start()
    {
    }
      private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (_chasedObjectPTransform.position - transform.position) * Time.fixedDeltaTime *
                                         _mobMovementSpeed;
        var step = (Time.fixedDeltaTime * _mobRotationSpeed);
        gameObject.transform.rotation = new Quaternion(_chasedObjectPTransform.rotation.x * step,
            _chasedObjectPTransform.rotation.y * step, -_chasedObjectPTransform.rotation.z * step,
            _chasedObjectPTransform.rotation.w * step);
    }
}
