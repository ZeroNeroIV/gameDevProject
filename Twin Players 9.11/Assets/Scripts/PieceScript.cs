using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PieceScript : MonoBehaviour
{
    private readonly Vector3 _pieceRotation = new(-8f, -14f, -5f);
    private void Update() => transform.Rotate(_pieceRotation * Time.deltaTime);
[SerializeField] GameObject hmar;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Destroy(gameObject);  

       // Invoke("next",3f);
       Destroy(hmar,3.0f);
      
    }
    // private void destroy()
    // { 
    //     if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
    //         Debug.Log("Game Ended!\nCongrats!!!");
    //     else
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      
    // }
   
   

}
