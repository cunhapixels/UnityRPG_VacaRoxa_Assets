using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //Initialize variables
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject mySprite;
    [SerializeField] GameObject myDagger;
    [SerializeField] float daggerSpeed;

    Vector2 myVelocity;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        if (hInput != 0) {
            mySprite.transform.localScale = new Vector3(hInput, 1f, 1f);
        }

        if (hInput != 0 || vInput != 0) {
            mySprite.GetComponent<Animator>().SetBool("isMoving", true);
        } else {
            mySprite.GetComponent<Animator>().SetBool("isMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            GameObject obj = Instantiate(myDagger, this.gameObject.transform.position, this.gameObject.transform.rotation);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(daggerSpeed * mySprite.transform.localScale.x, 0f);
        }

        myVelocity = new Vector2(hInput * moveSpeed, vInput * moveSpeed);
        rb.velocity = Vector2.Lerp(rb.velocity, myVelocity, 0.05f);
    }
}
