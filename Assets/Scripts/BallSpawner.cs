using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private StickyBallFactory _stickyBallFactory;
    private BouncyBallFactory _bouncyBallFactory;

    [SerializeField] private float _ballSpawnInterval;

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
            yield return new WaitForSeconds(_ballSpawnInterval); 
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        Factory chosenFactory = Random.value < 0.3f ? _stickyBallFactory : _bouncyBallFactory;
        IBallProduct spawnedProduct = chosenFactory.GetProduct(GetSpawnPos());

    }

    private Vector3 GetSpawnPos()
    {
        return new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(2f, 2.5f), Random.Range(-0.05f, 0.05f));
    }
}
