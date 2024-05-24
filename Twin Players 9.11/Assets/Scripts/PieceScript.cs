using UnityEngine;
using UnityEngine.SceneManagement;
public class PieceScript : MonoBehaviour
{
    private readonly Vector3 _pieceRotation = new(-8f, -14f, -5f);
    private void Update() => transform.Rotate(_pieceRotation * Time.deltaTime);

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
            Debug.Log("Game Ended!\nCongrats!!!");
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
