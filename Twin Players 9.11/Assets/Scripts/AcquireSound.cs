using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AcquireSound : MonoBehaviour
{
    private AudioSource _acquire;

    private void Start() => _acquire = GetComponent<AudioSource>();

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("component")){
            _acquire.Play();
        }
    }
}
