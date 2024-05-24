using UnityEngine;

public class ShowPuzzlePiece : MonoBehaviour
{
    [SerializeField] private GameObject cage;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Destroy(cage);
        Destroy(this);
    }
}
