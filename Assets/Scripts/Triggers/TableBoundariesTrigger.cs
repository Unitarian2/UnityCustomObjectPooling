using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBoundariesTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            other.gameObject.GetComponent<PooledObject>().Release();
            //Debug.LogWarning("A ball is out of bounds!" + other.gameObject.GetComponent<PooledObject>().poolObjectType);
        }
    }
}
