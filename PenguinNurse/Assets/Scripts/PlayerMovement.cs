using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 3f; // player movement speed
    private Vector3 change; // player movement direction
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start() {
        if (gameObject.GetComponent<Rigidbody2D>() != null) {
            rb2d = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();

        if (Input.GetAxis ("Horizontal") > 0){
            Vector3 newScale = transform.localScale;
            newScale.x = 1.0f;
            transform.localScale = newScale;
        }
        else if (Input.GetAxis ("Horizontal") < 0){
            Vector3 newScale =transform.localScale;
            newScale.x = -1.0f;
            transform.localScale = newScale;
        }
    }

    void UpdateAnimationAndMove() {
        if (change != Vector3.zero) {
            rb2d.MovePosition(transform.position + change * speed * Time.deltaTime);
        }
    }
}
