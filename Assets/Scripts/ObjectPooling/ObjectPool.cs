using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] private uint initPoolSize;
    [SerializeField] private PooledObject bouncyBallToPool;
    [SerializeField] private PooledObject stickyBallToPool;
    
    // store the pooled objects in a collection
    private Stack<PooledObject> stack;
    [SerializeField] private List<PoolElement<PoolObjectType, PooledObject>> pooledObjectList;

    private void Start()
    {
        SetupPool();
    }
    // creates the pool (invoke when the lag is not noticeable)
    private void SetupPool()
    {
        //stack = new Stack<PooledObject>();
        pooledObjectList = new List<PoolElement<PoolObjectType, PooledObject>>();

        PooledObject instance = null;
        for (int i = 0; i < initPoolSize; i++)
        {
            instance = Instantiate(bouncyBallToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);

            pooledObjectList.Add(new PoolElement<PoolObjectType, PooledObject> { Key = PoolObjectType.BouncyBall, Value = instance });
            //stack.Push(instance);
        }

        for (int i = 0; i < initPoolSize; i++)
        {
            instance = Instantiate(stickyBallToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);

            pooledObjectList.Add(new PoolElement<PoolObjectType, PooledObject> { Key = PoolObjectType.StickyBall, Value = instance });
            //stack.Push(instance);
        }
    }

    // returns the first active GameObject from the pool
    public PooledObject GetPooledObject(PooledObject objectToPool, PoolObjectType poolObjectType)
    {
        
        // if the pool is not large enough, instantiate a new PooledObjects
        if (!pooledObjectList.Exists(x=>x.Key == poolObjectType))
        {
            
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this;
            return newInstance;
        }
        // otherwise, just grab the next one from the list
        PoolElement<PoolObjectType, PooledObject> nextInstance = pooledObjectList.FirstOrDefault(x => x.Key == poolObjectType);
        pooledObjectList.Remove(nextInstance);
        nextInstance.Value.gameObject.SetActive(true);
        return nextInstance.Value;

        
    }

    public void ReturnToPool(PooledObject pooledObject, PoolObjectType poolObjectType)
    {
        //stack.Push(pooledObject);

        pooledObjectList.Add(new PoolElement<PoolObjectType, PooledObject> { Key = poolObjectType, Value = pooledObject });
        pooledObject.gameObject.SetActive(false);
    }
}

public enum PoolObjectType
{
    BouncyBall,
    StickyBall
}
