using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponController))]
public class PlayerView : MonoBehaviour {
    public float mouseSensitivity = 200f;
    public Transform playerBody;

    WeaponController weaponController;
    float xRotation = 0;

    // Start is called before the first frame update
    void Start() {
        // Hide and lock cursor in center
        Cursor.lockState = CursorLockMode.Locked;

        weaponController = GetComponent<WeaponController>();
    }

    // Update is called once per frame
    void Update() {
        // Look input
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        // Look debug
        Debug.DrawLine(transform.position, transform.forward * 100f, Color.red);

        // Weapon input
        if (Input.GetButtonDown("Fire1")) {
            // single tap Input.GetButtonDown("Fire1")
            // continuous Input.GetMouseButton(0)
            weaponController.Shoot();
        }
    }
}
