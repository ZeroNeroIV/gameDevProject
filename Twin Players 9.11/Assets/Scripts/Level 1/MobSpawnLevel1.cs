using UnityEngine;

namespace Level_1
{
    public class MobSpawnLevel1 : MonoBehaviour
    {
        [SerializeField] private GameObject mob;
        [SerializeField] private GameObject bossMob;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        void FirstWave()
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(mob, gameObject.transform.position, gameObject.transform.rotation);
                for (int j = 0; j < 100; j++) ;
            }

            for (int j = 0; j < 200; j++) ;
            Instantiate(bossMob, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
