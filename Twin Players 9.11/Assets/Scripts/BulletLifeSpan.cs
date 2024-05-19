using UnityEngine;

public class BulletLifeSpan : MonoBehaviour
{
    [SerializeField] private float destructionAfterDelay = 10f;
    private void Start() => Destroy(gameObject, destructionAfterDelay * Time.deltaTime);

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) return;
        Destroy(gameObject);
    }
}
