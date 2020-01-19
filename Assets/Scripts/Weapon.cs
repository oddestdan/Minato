using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public Transform muzzle;
    public Projectile projectile;
    public float msBetweenShots = 100; // rate of fire
    public float muzzleVelocity = 35; // speed of projectile leaving a weapon

    float nextShotTime;

    public void Shoot() {
        if (Time.time > nextShotTime) {
            nextShotTime = Time.time + msBetweenShots / 1000;

            Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
            newProjectile.SetSpeed(muzzleVelocity);
            Destroy(newProjectile.gameObject, 1f);
        }
    }

    public void HitScanShoot() {
        PlayerView fpsCam = GetComponent<PlayerView>();
        float damage = 10f;
        float range = 100f;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            // Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
            }
        }
    }
}