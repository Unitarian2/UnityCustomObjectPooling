using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : MonoBehaviour,IBallProduct
{
    [SerializeField] private string productName = "BouncyBallProduct";
    public string ProductName { get => productName; set => productName = value; }

    public void Initialize()
    {
        gameObject.name = productName;
        StartCoroutine(ReleaseProcess());
    }

    IEnumerator ReleaseProcess()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<PooledObject>().Release();


    }

}
