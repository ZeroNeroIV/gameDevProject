using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnLevel1 : MonoBehaviour
{
    [SerializeField] private GameObject _mob;
    [SerializeField] private GameObject _bossMob;

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
            Instantiate(_mob, gameObject.transform.position, gameObject.transform.rotation);
            for (int j = 0; j < 100; j++) ;
        }
        
        for (int j = 0; j < 200; j++) ;
        Instantiate(_bossMob, gameObject.transform.position, gameObject.transform.rotation);
    }
}
