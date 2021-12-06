using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopeBehaviour : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Vector3 angles;
    [SerializeField] float rotateCoolDown;
    [SerializeField] float shootCooldown;
    [SerializeField] float projectilleForce;
    [SerializeField] float destroyTime;
    void Start() {
        InvokeRepeating("Rotate", 0f, rotateCoolDown);
    }

    private void Update() {
    }

    void Rotate() {
        transform.Rotate(angles, Space.World);
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot() {
        yield return new WaitForSeconds(shootCooldown);
        GameObject bulllet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D rb = bulllet.GetComponent<Rigidbody2D>();
        rb.AddForce(projectilleForce * -transform.up, ForceMode2D.Impulse);
        StartCoroutine(DestroyProjectille(bulllet));
    }

    IEnumerator DestroyProjectille(GameObject obj) {
        yield return new WaitForSeconds(destroyTime);
        Destroy(obj);
    }
}
