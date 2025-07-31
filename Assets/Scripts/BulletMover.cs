using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class BulletMover : MonoBehaviour
{
    public float bulletTravelSpeed = 10f;
    public float lifeTime = 3f;     //Added a life time for the bullet so it gets destroyed after 3 secs


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * bulletTravelSpeed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
