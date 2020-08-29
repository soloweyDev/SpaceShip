using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject Asteroid;
    public float minDelay, maxDelay;
    private float nextLaunchTime;
    
    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.instance.isStarted)
            return;

        if (Time.time > nextLaunchTime)
        {
            float posX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            float posY = 0;
            float posZ = transform.position.z;

            Instantiate(Asteroid, new Vector3(posX, posY, posZ), Quaternion.identity);

            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
