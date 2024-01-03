using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BouncyBallFactory : Factory
{
    [SerializeField] private BouncyBall productPrefab;
    [SerializeField] private Transform spawnedBallParent;
    public override IBallProduct GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(productPrefab.gameObject, position, Quaternion.identity, spawnedBallParent);
        BouncyBall newProduct = instance.GetComponent<BouncyBall>();
        
        newProduct.Initialize();
        return newProduct;
    }
}
