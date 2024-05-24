using UnityEngine;

// Mohammad work:
// this code is for making the pyramid rotate when the bullet hit the cone

namespace Level_2
{
    public class ConeMoving : MonoBehaviour
    {
        public bool done;
        private int _counter = 1;
        // Speed of rotation around each axis (degrees per second)
        private readonly Vector3 _rotationSpeed = new (0f, 6000f, 0f);
        private void Checking() => done = _counter%3 == 0;
        // This method is called when the bullet collides with another collider
        private void OnCollisionEnter(Collision other)
        {
            // Check if the collided object has the tag "Button"
            if (!other.gameObject.CompareTag("Bullet")) return;
            // Call the method to perform the action when the button is hit
            ConeMove();
        }
        // This method contains the action to perform when the button is hit
        private void ConeMove()
        {
            // Apply the rotation to the cone
            transform.Rotate(_rotationSpeed * Time.deltaTime);
            _counter++;
            Checking();
        }
    }
}
