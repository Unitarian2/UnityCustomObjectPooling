using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBallFactory : Factory
{
    [SerializeField] private StickyBall productPrefab;
    [SerializeField] private Transform spawnedBallParent;
    public override IBallProduct GetProduct(Vector3 position)
    {
        PooledObject pooledObject = ObjectPool.Instance.GetPooledObject(productPrefab.GetComponent<PooledObject>(), PoolObjectType.StickyBall);
        pooledObject.gameObject.transform.localPosition = position;
        pooledObject.gameObject.transform.SetParent(spawnedBallParent);
        StickyBall newProduct = pooledObject.gameObject.GetComponent<StickyBall>();

        newProduct.Initialize(); 
        return newProduct;
    }
}
