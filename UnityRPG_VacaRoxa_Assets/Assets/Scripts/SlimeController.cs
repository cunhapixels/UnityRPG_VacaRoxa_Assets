using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float health;
    [SerializeField] bool red;

    [SerializeField] bool canTakeDamage = true;

    void Update() {
        if (!red) {
            rb.velocity *= 0.9f;
        }

        //TODO: Move if red
    }   

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Dagger" && canTakeDamage) {
            if (other.gameObject.transform.position.x > transform.position.x) {
                rb.AddForce(Vector2.left * 4f, ForceMode2D.Impulse);
            } else {
                rb.AddForce(Vector2.right * 4f, ForceMode2D.Impulse);
            }

            health -= other.gameObject.GetComponent<DaggerController>().GetDamage();
            canTakeDamage = false;

            if (health <= 0) {
                Destroy(this.gameObject);
            }

            StartCoroutine("enableCanTakeDamage");
        }
    }

    IEnumerator enableCanTakeDamage() {
        yield return new WaitForSeconds(0.4f);
        canTakeDamage = true;
    }
}
