using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMover : MonoBehaviour
{
    private bool Moving = false;
    public float speed = 1f;
    public float direction = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Moving == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime * direction;
        }
    }

    public void OnMoveClick()
    {
        Moving = true;

    }

    public void OnStopClick()
    {
        Moving = false;
    }

    public void OnFlipClick()
    {
        speed *= -1;
    }
}
