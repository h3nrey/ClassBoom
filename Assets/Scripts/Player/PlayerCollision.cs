using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    private LifeController _lifeController;
    private SceneCaller _sceneCaller;

    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float respawnSpeed;
    [SerializeField] private float disableCooldown;
    
    private void Awake() {
        _lifeController = GetComponent<LifeController>();
        _sceneCaller = FindObjectOfType<SceneCaller>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.gameObject.tag) {
            case "Explosion": _lifeController.TakeDamage(1); break;
            case "Enemy": _lifeController.TakeDamage(1); break;
            case "WinDoor": _sceneCaller.CallCoroutine("WinGame"); break;
            default: break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy") {
            _lifeController.TakeDamage(1);
        }
    }

    public void Respawn() {
        PlayerBehaviour.instance.GetComponent<PlayerInput>().enabled = false;
        PlayerBehaviour.instance.GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = respawnPoint.position;
        Invoke("EnableInput", disableCooldown);
    }

    private void EnableInput() {
        GetComponent<Collider2D>().enabled = true;
        PlayerBehaviour.instance.GetComponent<PlayerInput>().enabled = true;
        PlayerBehaviour.instance.GetComponent<PlayerMovement>().enabled = true;
    }

    
}
