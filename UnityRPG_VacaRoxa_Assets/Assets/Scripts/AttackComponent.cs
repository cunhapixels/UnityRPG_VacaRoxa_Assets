using System;
using Interfaces;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    private IDamageable<float> _damageable;
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        _damageable = col.gameObject.GetComponent<IDamageable<float>>();
        if (_damageable != null) _damageable.ApplyDamage(_damage);
    }

}
