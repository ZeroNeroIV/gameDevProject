using UnityEngine;
using UnityEngine.SceneManagement;
public class PieceScript : MonoBehaviour
{
    private static int _sceneCount;
    private readonly Vector3 _pieceRotation = new(-8f, -14f, -5f);
    private void Update() => transform.Rotate(_pieceRotation * Time.deltaTime);

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (_sceneCount + 1 >= SceneManager.sceneCount)
            Debug.Log("Game Ended!\nCongrats!!!");
        else
            SceneManager.LoadScene(++_sceneCount);
    }
}
