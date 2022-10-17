using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class ShieldPickable : ItemPickable
{
    private IShieldable<float> shieldableEntity;
    [SerializeField] private float shieldAmount;

    private void OnTriggerEnter2D(Collider2D col)
    {
        shieldableEntity = col.gameObject.GetComponent<IShieldable<float>>();
        
        shieldableEntity.AddShield(shieldAmount);
        
        Destroy(gameObject);
    }
}
