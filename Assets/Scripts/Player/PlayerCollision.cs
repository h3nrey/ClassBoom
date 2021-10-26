using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    private LifeController _lifeController;

    private void Awake() {
        _lifeController = GetComponent<LifeController>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Explosion") {
            _lifeController.TakeDamage(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy") {
            _lifeController.TakeDamage(1);
        }
    }
}
