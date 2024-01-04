using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PooledObject : MonoBehaviour
{
    private ObjectPool pool;
    public ObjectPool Pool { get => pool; set => pool = value; }

    public PoolObjectType poolObjectType;
    public void Release()
    {
        pool.ReturnToPool(this, poolObjectType);
    }
}
