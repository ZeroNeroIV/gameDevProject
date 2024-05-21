using UnityEngine;

namespace Level_1
{
    public class MobControl : MonoBehaviour
    {
<<<<<<< HEAD
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
=======
        [SerializeField] private float mobMovementSpeed = 5f;
        [SerializeField] private float mobRotationSpeed = 15f;

        [SerializeField] private Transform chasedObjectPTransform;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            gameObject.transform.position += (chasedObjectPTransform.position - transform.position) * Time.fixedDeltaTime *
                                             mobMovementSpeed;
            var step = (Time.fixedDeltaTime * mobRotationSpeed);
            gameObject.transform.rotation = new Quaternion(chasedObjectPTransform.rotation.x * step,
                chasedObjectPTransform.rotation.y * step, -chasedObjectPTransform.rotation.z * step,
                chasedObjectPTransform.rotation.w * step);
        }
>>>>>>> 88890fea8ac73a24ae516d798cea3bbcd5bba71b
    }
}
