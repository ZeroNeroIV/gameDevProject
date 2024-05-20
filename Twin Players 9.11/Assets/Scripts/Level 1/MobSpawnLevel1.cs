using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class MobSpawnLevel1 : MonoBehaviour
{
    [SerializeField] private GameObject _mob;
    [SerializeField] private GameObject _bossMob;

    const float Delay = 10.0f;
    float _timer = 0;
    bool _isDelayed = true;
    // Start is called before the first frame update
    List<GameObject> v = new List<GameObject>();
    int _count = 0;
    void Start()
    {
        Invoke("killAll", 20);
        InvokeRepeating("habal", 0.1f ,0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    GameObject cl;
    void habal()
    {
        if(_count >= 10)
        {
            CancelInvoke("habal");
            InvokeRepeating("boss", 0.5f ,0.5f);
            _count = 0;
        }
        _count++;
        cl = new GameObject("");
        cl = Instantiate(_mob, gameObject.transform.position, gameObject.transform.rotation);
        //Destroy(cl, 10.0f);

       v.Add(cl);
    }
    void boss()
    {
        if(_count >= 3)
        {
            CancelInvoke("boss");
        }
        _count++;
        cl = new GameObject("");
        cl = Instantiate(_bossMob, gameObject.transform.position, gameObject.transform.rotation);
        //Destroy(cl, 10.0f);

       v.Add(cl);
    }
    void killAll()
    {
        foreach(GameObject cl in v)
        {
            Destroy(cl , 1.0f);
        }
    }

    void FirstWave()
    {
    
       
       

       
        
    }
}
