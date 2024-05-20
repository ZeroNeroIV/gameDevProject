using UnityEngine;

public class stepover : MonoBehaviour
{
    public bool isubove=false;
    // Speed of downward movement (units per second)
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Button"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the method to perform the action when the button is hit
            
                isubove=true;
            
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        // Check if the collided object has the tag "Button"
        if (collision.gameObject.CompareTag("Player"))
        {
            isubove=false;
        }
        
    }
    
}
