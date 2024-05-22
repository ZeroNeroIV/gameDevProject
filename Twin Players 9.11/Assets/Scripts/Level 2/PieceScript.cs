using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level_2
{
    public class PieceScript : MonoBehaviour
    {
        [SerializeField] private string nextLevel;
        private readonly Vector3 _pieceRotation = new(-8f, -14f, -5f);
        private void Update() => transform.Rotate(_pieceRotation * Time.deltaTime);

        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.CompareTag("Player")) return;
            Destroy(gameObject);
        }
        private void OnDestroy()
        {
            if (string.IsNullOrEmpty(nextLevel)) return;
            if (nextLevel.Equals("End"))
                Debug.Log("Game Ended!\nCongrats!!!");
            else
                SceneManager.LoadScene(nextLevel);
        }
    }
}
