using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CircleOutput : MonoBehaviour
{
    public float moveOutSpeed = 1.0f;
    public SpriteRenderer output;
    // Start is called before the first frame update
    void Start()
    {
        output.color = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * moveOutSpeed * Time.deltaTime;
    }
}
