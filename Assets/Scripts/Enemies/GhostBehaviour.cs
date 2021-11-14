using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [Header("Movementation")]
    [SerializeField] float speed;
    [SerializeField] float sense = 1;
    [SerializeField] float rightLimit, leftLimit;
    
    [Header("Jump a Row")]
    [SerializeField] float toPoint;
    [SerializeField] float duration;
    [SerializeField] LeanTweenType easeType;

    void Update() {
        float x = Mathf.Round(this.transform.position.x);

        if(x == rightLimit || x == leftLimit) {
            ToUp();
            sense *= -1;
        } 
    }

    private void FixedUpdate() {
        rb.velocity = Vector2.right * speed * sense * Time.deltaTime;
    }
    
    public void ToUp() {
        this.transform.LeanMoveY(transform.position.y + toPoint, duration).setEase(easeType);
    }
}
