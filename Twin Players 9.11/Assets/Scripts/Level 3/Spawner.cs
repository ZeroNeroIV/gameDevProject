using UnityEngine;

namespace Level_3
{
    public class Spawner : MonoBehaviour

    {
        // made by codeium AI مو انا
        // غير مكتمل لسا بدو تعديل يمكن انا ماجربتو لأنو مافي بريفاب حط السكربت عليه
        // -أحمد
        [SerializeField] private GameObject mob;
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating($"Spawn", 5, 5);
            Invoke($"Cancel", 20);
        }

        private void Spawn()
        {
            Instantiate(mob, transform.position, transform.rotation);
        }


        // Spawns enemies based on current wave
        void Update()
        {
//        bool wave1Done = false;
//        bool wave2Done = false;
//        int currentWave = 1;
//        float timeToNextWave = 0;
//
//        if (wave1Done && currentWave == 1)
//        {
//            currentWave = 2;
//            timeToNextWave = 2f;
//            wave2Done = false;
//        }
//        else if (!wave2Done && timeToNextWave <= 0)
//        {
//            wave2Done = true;
//            timeToNextWave = 2f;
//            for (int i = 0; i < 2; i++)
//            {
//                Instantiate(enemy, transform.position, transform.rotation);
//            }
//        }
//        else
//        {
//            timeToNextWave -= Time.deltaTime;
//        }
        }

    }
}

