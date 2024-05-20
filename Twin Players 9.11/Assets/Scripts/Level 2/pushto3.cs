using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Mohammad work:
// this code is for making the pirmed routat when the bullet hit the cone

public class pushto3 : MonoBehaviour
{
    // Speed of rotation around each axis (degrees per second)
    public float rotationSpeedX = 0f;
    public float rotationSpeedY = 6000f;
    public float rotationSpeedZ = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public bool done=false;
    public int counter=1;
    // This method is called when the bullet collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Button"
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Call the method to perform the action when the button is hit
            ConeMove();
        }
    }
    // This method contains the action to perform when the button is hit
    private void ConeMove()
    {
        // Calculate the rotation for this frame
        float rotationX = rotationSpeedX * Time.deltaTime;
        float rotationY = rotationSpeedY * Time.deltaTime;
        float rotationZ = rotationSpeedZ * Time.deltaTime;
        // Apply the rotation to the cone
        transform.Rotate(rotationX, rotationY, rotationZ);
        counter++;
        checking();
    }
    public void checking()
    {
        if(counter%3==0)
            done=true;
        else 
            done=false;
    }
}
