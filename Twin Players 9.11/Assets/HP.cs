using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    // Start is called before the first frame update
    public  int _mxHealth = 20;
    public int _health;
     public float stopDistance = 1f; // Distance to maintain from the target
    public int damageAmount = 10; // Amount of health to reduce on collision
    public float collisionCooldown = 1f; // Time between each collision damage
   private float lastCollisionTime;
    void Start()
    {
        _health = _mxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void dmg(int amount)
    {
        _health -= amount;
        if(_health <= 0)
        {
            die();
        }
    }
    GameObject oth;
    private void OnTriggerEnter(Collider other)    {
        if (other.CompareTag("Enemy") && Time.time > lastCollisionTime + collisionCooldown)
        {
            oth = other.gameObject;
                dmg(damageAmount);
                lastCollisionTime = Time.time;
                MaintainDistance();
            
        }
    }
    private void MaintainDistance()
    {
        // Move the enemy back to maintain the stop distance
       oth.transform.position = new Vector3(transform.position.x-5 , transform.position.y -5, transform.position.z-5);
        transform.Translate(-1,0,-1);
    }
    void die()
    {
        //_health = _mxHealth;
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.loadedSceneCount);
    }
}

