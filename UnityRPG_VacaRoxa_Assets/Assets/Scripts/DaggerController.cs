using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerController : MonoBehaviour {
    [SerializeField] float damage;
    Quaternion currentRotation;

    void Update() {
        if (transform.position.x < -10 || transform.position.x > 10) {
            Destroy(this.gameObject);
        }

        currentRotation.eulerAngles += new Vector3(0f, 0f, 15f);
        transform.rotation = currentRotation;
    }

    public float GetDamage() {
        return damage;
    }
}
