using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed, tilt;
    public float xMin, xMax, zMin, zMax;
    public GameObject lazerShot;
    public Transform laserGun;
    public float shotDelay;
    private Rigidbody ship;
    private float nextShotTime;
    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.instance.isStarted)
            return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float clampedPositionX = Mathf.Clamp(ship.position.x, xMin, xMax);
        float clampedPositionZ = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(clampedPositionX, 0, clampedPositionZ);

        ship.rotation = Quaternion.Euler(0, 0, -moveHorizontal * tilt);

        if (Input.GetButton("Fire1") && Time.time > nextShotTime)
        {
            Instantiate(lazerShot, laserGun.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }
    }
}
