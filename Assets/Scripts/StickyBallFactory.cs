using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBallFactory : Factory
{
    [SerializeField] private StickyBall productPrefab;
    [SerializeField] private Transform spawnedBallParent;
    public override IBallProduct GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(productPrefab.gameObject, position, Quaternion.identity, spawnedBallParent);
        StickyBall newProduct = instance.GetComponent<StickyBall>();

        newProduct.Initialize(); 
        return newProduct;
    }
}
