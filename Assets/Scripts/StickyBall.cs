using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBall : MonoBehaviour,IBallProduct
{
    [SerializeField] private string productName = "StickyBallProduct";
    public string ProductName { get => productName; set => productName = value; }
   
    public void Initialize()
    {
        gameObject.name = productName;
    }

    
}
