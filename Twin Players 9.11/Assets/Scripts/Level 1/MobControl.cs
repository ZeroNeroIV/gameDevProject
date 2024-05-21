using UnityEngine;

namespace Level_1
{
    public class MobControl : MonoBehaviour
    {
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
    }
}
