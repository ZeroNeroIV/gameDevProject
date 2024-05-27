using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquiresounds : MonoBehaviour
{
    public GameObject Component;
   public AudioSource aquire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("component")){
            aquire.Play();
    
        }
    }
}
