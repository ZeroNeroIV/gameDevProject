using UnityEngine;

namespace Level_1
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private float bulletMovement = 20f;
        [SerializeField] AudioSource domain;
        [SerializeField] AudioClip dom;
        private Rigidbody _rb;
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.useGravity = false;
            _rb.mass = 1000000f;
        }

        // Update is called once per frame
        private void Update()
        {
            _rb.AddRelativeForce(0f, 0f, bulletMovement, ForceMode.VelocityChange);
        }
        private void OnTriggerEnter(Collider other)    {
        if (other.CompareTag("Enemy")){
                Destroy(other.gameObject);
            
        }
    }
    }
}
