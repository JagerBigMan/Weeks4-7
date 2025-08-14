using System.Collections;
using UnityEngine;

public class LineMover : MonoBehaviour
{
    public float moveSpeed = 5f;    //Sets the speed at which the player moves
    private LineRenderer lineRenderer;      //Physically drawing the line on the screen so that I can check to see if the player is moving towards the end of the line

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();        //I'm getting the LineRenderer component from the GameObject.

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        //This is to get the mouse position in world space
        mousePosition.z = 0f;

        lineRenderer.SetPosition(0, transform.position);        //Update the two endpoints of the line
        lineRenderer.SetPosition(1, mousePosition);             //Start at the player's position and end at the current mouse position

        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();        //This will stop any movement coroutine
            StartCoroutine(MoveToPosition(mousePosition));      //This then starts a new coroutine that move the player toward the clicked position
        }
    }

    IEnumerator MoveToPosition(Vector3 target)      //This moves the player to the clicked position smoothly
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)        //This will keep running/looping until the player has reached the target position
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);       //This moves the player closer to the target each frame
            lineRenderer.SetPosition(0, transform.position);        //This will continuously update the line's start position to the new player position
            yield return null;
        }
        transform.position = target;    //This will make sure the player ends at the target precisely
    }
}
