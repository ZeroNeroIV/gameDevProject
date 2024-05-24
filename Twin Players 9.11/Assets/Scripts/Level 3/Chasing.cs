using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 100;
    float rotationSpeed = 70f;
    private GameObject p;

    void Start()
    {
        p = GameObject.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        //float x = 0, y = 0, z = 0;
        //  transform.LookAt(p.transform);
             Transform target = p.transform;
        
        // Calculate the direction vector
            Vector3 direction = target.position - transform.position;
            direction.y = 0; // Optional: Keep the y component zero to only rotate on the y-axis

            // Calculate the rotation towards the target
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Smoothly rotate towards the target
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x , transform.position.y , target.position.z), speed * Time.deltaTime);
    }


   
}
