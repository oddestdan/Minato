using UnityEngine;

public class Gun : MonoBehaviour {
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    // Update is called once per frame
    void Update() {
        // Debug
        Debug.DrawLine(fpsCam.transform.position, fpsCam.transform.forward * range, Color.red);

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit hit;
        // If anything is hit by the raycast
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            // Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
            }
        }
    }
}
