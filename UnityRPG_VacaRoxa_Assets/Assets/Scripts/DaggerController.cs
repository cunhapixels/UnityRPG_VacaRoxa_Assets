using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerController : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    Quaternion currentRotation;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.x < -10 || transform.position.x > 10) {
            Destroy(this.gameObject);
        }

        currentRotation.eulerAngles += new Vector3(0f, 0f, 2.5f);
        transform.rotation = currentRotation;
    }
}
