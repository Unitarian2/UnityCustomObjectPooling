using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            other.gameObject.GetComponent<PooledObject>().Release();
            //Debug.LogWarning("A ball is released!" + other.gameObject.GetComponent<PooledObject>().poolObjectType);
        }
    }
}
