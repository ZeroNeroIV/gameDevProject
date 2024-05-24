using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    // Start is called before the first frame update
       [SerializeField] private GameObject bigspid;
        [SerializeField] private GameObject bigzomb;
    [SerializeField] private GameObject spid;
        [SerializeField] private GameObject zomb;

         [SerializeField] private GameObject sp1;
        [SerializeField] private GameObject sp2;
        [SerializeField] private GameObject sp3;
      [SerializeField] AudioSource domain;
              [SerializeField] AudioClip dom;


        // Start is called before the first frame update
        private List<GameObject> _spawners;
        private int _plate = 0, _cnt = 0;
     List<GameObject> clones;
        void Start()
        {
            domain.enabled = true;

            _spawners = new List<GameObject>{sp1,sp2, sp3};
            clones = new List<GameObject>();
            //InvokeRepeating($"Spawn", 5, 5);
            //Invoke($"Cancel", 20);
    
            domain.clip = dom;
           // domain.Play();
            
            // while(domain.isPlaying)
            // {

            // }
                Invoke("wave1" , 21);
        }
        void killAll()
        {
            foreach (GameObject obj in clones)
            Destroy(obj);
        }
        private void Spawnspi()
        {
            _cnt++;
            _plate++;
            _plate %= 3;
         GameObject clone =   Instantiate(spid, _spawners[_plate].transform.position, _spawners[_plate].transform.rotation);
         clones.Add(clone);
             if(_cnt == 10)
            {
            _cnt = 0;
            CancelInvoke("Spawnspi");
            wave2();
            }
        }
    private int _cnt2 = 0;
         private void Spawnzomb()
        {
            _cnt++;
            _plate++;
            _plate %= 3;
         GameObject clone =   Instantiate(zomb, _spawners[_plate].transform.position, _spawners[_plate].transform.rotation);
         clones.Add(clone);
            if(_cnt == 10)
            {
                _cnt = 0;
                CancelInvoke("Spawnzomb");
                wave3();
            }
        }
        
        // Spawns enemies based on current wave
        void Update()
        {

        }
       
        void wave1()
        {
            InvokeRepeating("Spawnspi", 0.5f , 3.0f);
            // while(_cnt<10)
            // {

            // }
            // _cnt = 0;
            //CancelInvoke("Spawnspi");
           // wave2();
        }
         void wave2()
        {
             killAll();
             InvokeRepeating("Spawnzomb", 5.5f , 3.0f);
        }
         private void Spawnbigspi()
        {
            _cnt++;
            _plate++;
            _plate %= 3;
         GameObject clone =   Instantiate(bigspid, _spawners[_plate].transform.position, _spawners[_plate].transform.rotation);
         clones.Add(clone);
            if(_cnt == 11)
            {
                _cnt = 0;
                CancelInvoke("Spawnbigspi");
            }
        }
          private void Spawnbigzomb()
        {
            _cnt2++;
            _plate++;
            _plate %= 3;
         GameObject clone =   Instantiate(bigzomb, _spawners[_plate].transform.position, _spawners[_plate].transform.rotation);
         clones.Add(clone);
            if(_cnt2 == 9)
            {
                _cnt = 0;
                CancelInvoke("Spawnbigzomb");
            }
        }
         void wave3()
        {
             killAll();
             InvokeRepeating("Spawnbigspi", 5.5f , 2.0f);
             InvokeRepeating("Spawnbigzomb", 5.5f , 3.0f);



        }
}
