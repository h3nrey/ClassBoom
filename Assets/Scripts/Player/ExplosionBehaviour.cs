using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExplosionBehaviour : MonoBehaviour
{
    [SerializeField] private float rayRange = 2f;
    [SerializeField] RaycastHit2D[] rays = new RaycastHit2D[4];
    [SerializeField] Vector2[] raysDirection;
    private void FixedUpdate() {
        for (int i = 0; i < rays.Length; i++) {
            rays[i] = Physics2D.Raycast(transform.position, raysDirection[i], rayRange);
            if (rays[i].collider != null)
                print(rays[i].collider.gameObject);
                explosionOfCreatures(rays[i].collider.gameObject);
        }
    }

    private void explosionOfCreatures(GameObject obj) {
        if(obj.layer == 6) {
            obj.GetComponent<LifeController>().TakeDamage(1);
        }
    }

    private void OnDrawGizmos() {
        for (int i = 0; i < rays.Length; i++) {
            Vector3 debugDirection = transform.TransformDirection(raysDirection[i]) * rayRange;
            Debug.DrawRay(transform.position, debugDirection, Color.red);
        }
    }
}
