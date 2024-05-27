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

    [SerializeField] private AudioClip waveEndSound; // Sound to play when all enemies are dead

    private List<GameObject> _spawners;
    private int _plate;
    private List<GameObject> _clones;

    private bool wave1Active = true;
    private bool wave2Active = true;
    private bool wave3Active = true;

    private int _enemiesRemainingInWave1;
    private int _enemiesRemainingInWave2;
    private int _enemiesRemainingInWave3;

    private void Start()
    {
        _spawners = new List<GameObject>{sp1, sp2, sp3};
        _clones = new List<GameObject>();

        StartWave1();
    }

    private void Update()
    {
        // Check if all waves have ended
        if (!wave1Active && !wave2Active && !wave3Active && _clones.Count == 0)
        {
            PlayWaveEndSound();
        }
    }

    private void PlayWaveEndSound()
    {
        if (waveEndSound != null)
        {
            AudioSource.PlayClipAtPoint(waveEndSound, transform.position);
        }
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
            wave1Active = false;
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
            wave2Active = false;
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
        if (_enemiesRemainingInWave3 == 11)
        {
            wave3Active = false;
            CancelInvoke(nameof(SpawnBigSpider));
        }
    }

    private void SpawnBigZombie()
    {
        _plate++;
        _plate %= 3;
        var clone = Instantiate(bigZombie, _spawners[_plate].transform.position, _spawners[_plate].transform.rotation);
        _clones.Add(clone);
        _enemiesRemainingInWave3++;
        if (_enemiesRemainingInWave3 == 9)
        {
            wave3Active = false;
            CancelInvoke(nameof(SpawnBigZombie));
        }
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
    }
}
