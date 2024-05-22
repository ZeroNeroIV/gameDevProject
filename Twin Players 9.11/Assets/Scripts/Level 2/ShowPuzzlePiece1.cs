using UnityEngine;

namespace Level_2
{
    public class ShowPuzzlePiece1 : MonoBehaviour
    {
        [SerializeField] private GameObject cage;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            Destroy(cage);
            Destroy(this);
        }
    }
}
