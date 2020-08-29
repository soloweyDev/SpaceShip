using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float ratation;
    public float minSpeed, maxSpeed;
    public GameObject asteriodExplosion;
    public GameObject playerExplosion;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * ratation;
        float speed = Random.Range(minSpeed, maxSpeed);
        asteroid.velocity = new Vector3(0, 0, -speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.tag != "asteroid")
        {
            GameControllerScript.instance.score += 50;
        }

        Destroy(gameObject);
        Destroy(other.gameObject);

        Instantiate(asteriodExplosion, transform.position, Quaternion.identity);

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }
    }
}
