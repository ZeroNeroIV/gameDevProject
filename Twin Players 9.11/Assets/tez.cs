using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class tez : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
      private void OnDestroy()
    { 
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
            Debug.Log("Game Ended!\nCongrats!!!");
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                  SceneManager.LoadScene( SceneManager.sceneCountInBuildSettings-1);

    }
}
