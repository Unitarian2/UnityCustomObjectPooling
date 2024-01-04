using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolElement<T, U>
{
    public T Key { get; set; }
    public U Value { get; set; }
}
