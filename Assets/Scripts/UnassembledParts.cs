using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnassembledParts : MonoBehaviour
{
    public float dropSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * dropSpeed * Time.deltaTime;
    }
}
