using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawners : MonoBehaviour
{
    [SerializeField] private GameObject bigSpider;
    [SerializeField] private GameObject bigZombie;
    [SerializeField] private GameObject spider;
    [SerializeField] private GameObject zombie;
    [SerializeField] private GameObject sp1;
    [SerializeField] private GameObject sp2;
    [SerializeField] private GameObject sp3;
    [SerializeField] private AudioSource s;

    private List<GameObject> _spawners;
    private int _plate;
    private List<GameObject> _clones;

    private bool _wave1Active = true;
    private bool _wave2Active = true;
    private bool _wave3Active = true;

    private int _enemiesRemainingInWave1;
    private int _enemiesRemainingInWave2;
    private int _enemiesRemainingInWave3;
    private int _cnt;
    private int _cnt2;

    private void Start()
    {
        s = GetComponent<AudioSource>();
        _spawners = new List<GameObject>{sp1,sp2, sp3};
        _clones = new List<GameObject>();
        Invoke(nameof(StartWave1) , 15);
    }

    private void KillAll()
    {
        foreach (var obj in _clones)
        {
            Destroy(obj);
        }
        _clones.Clear();
    }

    private void SpawnSpider()
    {
        _plate++;
        _plate %= 3;
        var clone = Instantiate(spider, _spawners[_plate].transform.position, _spawners[_plate].transform.rotation);
        _clones.Add(clone);
        _enemiesRemainingInWave1++;
        if (_enemiesRemainingInWave1 == 10)
        {
            _wave1Active = false;
            CancelInvoke(nameof(SpawnSpider));
            StartWave2();
        }
    }

    private void SpawnZombie()
    {
        _plate++;
        _plate %= 3;
        var clone = Instantiate(zombie, _spawners[_plate].transform.position, _spawners[_plate].transform.rotation);
        _clones.Add(clone);
        _enemiesRemainingInWave2++;
        if (_enemiesRemainingInWave2 == 10)
        {
            _wave2Active = false;
            CancelInvoke(nameof(SpawnZombie));
            StartWave3();
        }
    }

    private void SpawnBigSpider()
    {
        _plate++;
        _plate %= 3;
        var clone = Instantiate(bigSpider, _spawners[_plate].transform.position, _spawners[_plate].transform.rotation);
        _clones.Add(clone);
        _enemiesRemainingInWave3++;
        if (_enemiesRemainingInWave3 != 11) return;
        _wave3Active = false;
        CancelInvoke(nameof(SpawnBigSpider));
    }

    private void StartWave1()
    {
        InvokeRepeating(nameof(SpawnSpider), 0.5f, 3.0f);
    }

    private void StartWave2()
    {
        KillAll();
        InvokeRepeating(nameof(SpawnZombie), 5.5f, 3.0f);
    }

    private void StartWave3()
    {
        KillAll();
        InvokeRepeating(nameof(SpawnBigSpider), 5.5f, 2.0f);
        InvokeRepeating(nameof(SpawnBigZombie), 5.5f, 3.0f);
        Invoke(nameof(EndRound), 5f);
    }

    private void EndRound()
    {
        KillAll();
        s.Play();
        // if (_cnt != 11) return;
        // _cnt = 0;
        CancelInvoke(nameof(SpawnBigSpider));
        Destroy(gameObject, 15f);
    }
    private void SpawnBigZombie()
    {
        _cnt2++;
        _plate++;
        _plate %= 3;
        var clone =   Instantiate(bigZombie, _spawners[_plate].transform.position, _spawners[_plate].transform.rotation);
        _clones.Add(clone);
        if (_cnt2 != 9) return;
        _cnt = 0;
        CancelInvoke(nameof(SpawnBigZombie));
    }
}
