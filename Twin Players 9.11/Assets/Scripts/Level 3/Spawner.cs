using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour

{
    // made by codeium AI مو انا
    // غير مكتمل لسا بدو تعديل يمكن انا ماجربتو لأنو مافي بريفاب حط السكربت عليه
    // -أحمد
    public GameObject enemy;
    public string he;
    public GameObject enemySpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Spawns enemies based on current wave
    void Update()
    {
        bool wave1Done = GameObject.Spawner.enemy.Length == 0;
        bool wave2Done = false;
        int currentWave = 1;
        float timeToNextWave = 0;

        if (wave1Done && currentWave == 1)
        {
            currentWave = 2;
            timeToNextWave = 2f;
            wave2Done = false;
        }
        else if (!wave2Done && timeToNextWave <= 0)
        {
            wave2Done = true;
            timeToNextWave = 2f;
            for (int i = 0; i < 2; i++)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
            }
        }
        else
        {
            timeToNextWave -= Time.deltaTime;
        }
    }
    
}

