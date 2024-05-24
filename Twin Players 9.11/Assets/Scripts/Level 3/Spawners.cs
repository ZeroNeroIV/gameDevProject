using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField] private GameObject bigSpider;
    [SerializeField] private GameObject bigZombie;
    [SerializeField] private GameObject spider;
    [SerializeField] private GameObject zombie;

    [SerializeField] private GameObject sp1;
    [SerializeField] private GameObject sp2;
    [SerializeField] private GameObject sp3;
    private List<GameObject> _spawners;
    private int _plate;
    private int _cnt;
    private int _cnt2;
    private List<GameObject> _clones;
    private void Start()
    {
        _spawners = new List<GameObject>{sp1,sp2, sp3};
        _clones = new List<GameObject>();
        Invoke(nameof(Wave1) , 15);
    }
    private void KillAll()
    {
        foreach (var obj in _clones) Destroy(obj);
    }
    private void SpawnSpider()
    {
        _cnt++;
        _plate++;
        _plate %= 3;
        var clone = Instantiate(spider, _spawners[_plate].transform.position, _spawners[_plate].transform.rotation);
        _clones.Add(clone);
        if (_cnt != 10) return;
        _cnt = 0;
        CancelInvoke(nameof(SpawnSpider));
        Wave2();
    }
    private void SpawnZombie()
    {
        _cnt++;
        _plate++;
        _plate %= 3;
        var clone = Instantiate(zombie, _spawners[_plate].transform.position, _spawners[_plate].transform.rotation);
        _clones.Add(clone);
        if (_cnt != 10) return;
        _cnt = 0;
        CancelInvoke(nameof(SpawnZombie));
        Wave3();
    }

    private void Wave1() => InvokeRepeating(nameof(SpawnSpider), 0.5f , 3.0f);
    private void Wave2()
    {
        KillAll();
        InvokeRepeating(nameof(SpawnZombie), 5.5f , 3.0f);
    }
    private void SpawnBigSpider()
    {
        _cnt++;
        _plate++;
        _plate %= 3;
        var clone = Instantiate(bigSpider, _spawners[_plate].transform.position, _spawners[_plate].transform.rotation);
        _clones.Add(clone);
        if (_cnt != 11) return;
        _cnt = 0;
        CancelInvoke(nameof(SpawnBigSpider));
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
    private void Wave3()
    {
        KillAll();
        InvokeRepeating(nameof(SpawnBigSpider), 5.5f , 2.0f);
        InvokeRepeating(nameof(SpawnBigZombie), 5.5f , 3.0f);
    }
}
