using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class DumbEnemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 Direction; 
    private float senseOfDirection = 1;

    [Header("Visual")]
    [SerializeField] SpriteRenderer spr;
    [SerializeField] Animator anim;

    [SerializeField] public bool isWorm = true;

    void Update() {
        if (isWorm) {
            print("é uma minhoca, e está se movendo");
            rb.velocity = senseOfDirection * Direction * speed * Time.deltaTime;
        } else if (!isWorm) {
            rb.velocity = Vector2.zero;
        }
        anim.SetFloat("yVelocity",Mathf.Sign(rb.velocity.y));

        if(rb.velocity.y != 0  && rb.velocity.x == 0) {
            anim.SetBool("hasVerticalSpeed", true);
        } else {
            anim.SetBool("hasVerticalSpeed", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag != null) {
            senseOfDirection *= -1;
            this.transform.localScale *= new Vector2(-1, 1);
        }
    }
}
