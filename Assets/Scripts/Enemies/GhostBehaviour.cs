using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [Header("Movementation")]
    [SerializeField] float speed;
    [SerializeField] float sense = 1;

    
    [Header("Create a clone")]
    [SerializeField] GameObject ghost;
    [SerializeField] Camera mainCam;
    [SerializeField] float maxBehindDistance;
    [Header("Jump a Row")]
    [SerializeField] float toPoint;
    [SerializeField] float duration;
    [SerializeField] LeanTweenType easeType;

    void Update() {

    }

    private void FixedUpdate() {
        // rb.velocity = Vector2.right * speed * sense * Time.deltaTime;
    }
    
    public void ToUp() {
        this.transform.LeanMoveY(transform.position.y + toPoint, duration).setEase(easeType);
        sense *= -1;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "TilemapBrick") {
            Instantiate(ghost,new Vector2(-this.transform.position.x, this.transform.position.y),
            Quaternion.identity);
        }
    }

    private void OnBecameInvisible() {
        print("haha");
        Destroy(gameObject);
    }
}
