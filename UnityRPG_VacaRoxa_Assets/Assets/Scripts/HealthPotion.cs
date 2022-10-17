using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class HealthPotion : ItemPickable
{
    private ICurable<float> curableEntity;
    [SerializeField] private float cureAmount;

    private void OnTriggerEnter2D(Collider2D col)
    {
        curableEntity = col.gameObject.GetComponent<ICurable<float>>();
        
        curableEntity.ApplyCure(cureAmount);
        
        Destroy(gameObject);
    }
}
