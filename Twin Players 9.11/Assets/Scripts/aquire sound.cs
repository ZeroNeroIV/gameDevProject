using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
public GameObject component;
    public AudioSource audioSource;

    void Start()
    {
        // Ensure there is an AudioSource component attached to this GameObject
    }

    // This function is called when the Collider other enters the character's collider
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Component")) // Replace "ComponentTag" with the tag of the component you want to detect
        {
          
                // Play the collision sound
                audioSource.Play();
                Destroy(component);
                
            }
        
    }

    internal void Move(Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}
