using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Hp : MonoBehaviour
{
    // Start is called before the first frame update
    public int mxHealth = 20;
    public int health;
    public float stopDistance = 1f; // Distance to maintain from the target
    public int damageAmount = 10; // Amount of health to reduce on collision
    public float collisionCooldown = 1f; // Time between each collision damage
    private float _lastCollisionTime;
    private GameObject _oth;
    private void Start() => health = mxHealth;
    private void Dmg(int amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy") || !(Time.time > _lastCollisionTime + collisionCooldown)) return;
        _oth = other.gameObject;
        Dmg(damageAmount);
        _lastCollisionTime = Time.time;
        MaintainDistance();
    }
    private void MaintainDistance()
    {
        // Move the enemy back to maintain the stop distance
       _oth.transform.position = new Vector3(transform.position.x-5 , transform.position.y -5, transform.position.z-5);
        transform.Translate(-1,0,-1);
    }
    private void Die()
    {
        //_health = _mxHealth;
        Destroy(gameObject);
        SceneManager.LoadScene(1);
    }
}
