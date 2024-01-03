using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private StickyBallFactory _stickyBallFactory;
    private BouncyBallFactory _bouncyBallFactory;

    

    void Start()
    {
        _stickyBallFactory = GetComponent<StickyBallFactory>();
        _bouncyBallFactory = GetComponent<BouncyBallFactory>();
    }

    void OnEnable()
    {
        StartCoroutine(SpawnProcess());
    }
    
    IEnumerator SpawnProcess()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // Her 2 saniyede bir bekle
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        Factory chosenFactory = Random.value < 0.5f ? _stickyBallFactory : _bouncyBallFactory;
        IBallProduct spawnedProduct = chosenFactory.GetProduct(GetSpawnPos());

    }

    private Vector3 GetSpawnPos()
    {
        return new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(1f, 1.2f), Random.Range(-0.05f, 0.05f));
    }
}
