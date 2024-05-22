using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level_4
{
    public class PieceRotation : MonoBehaviour
    {
        [SerializeField] private string nextLevel;
        private readonly Vector3 _pieceRotation = new(-4f, -7f, -2.5f);
        private void Update() => transform.Rotate(_pieceRotation * Time.deltaTime);
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
