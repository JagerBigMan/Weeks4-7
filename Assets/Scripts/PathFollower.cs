using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public float speed = 5f;
    private LineRenderer lineRenderer;
    private List<Vector3> pathPoints = new List<Vector3>();
    private bool isMoving = false;      

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;     //Line will only show the playher's current position
        lineRenderer.SetPosition(0, transform.position);        //https://docs.unity3d.com/ScriptReference/LineRenderer.SetPosition.html
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            pathPoints.Add(mousePosition);      //This adds the clicked position to the path list
            lineRenderer.positionCount = pathPoints.Count + 1;
            for (int i = 0; i < pathPoints.Count; i++)      //Set positions for the line, the first index is the player and the rest are path points
            {
                lineRenderer.SetPosition(i + 1, pathPoints[i]);
            }
            if (!isMoving)      //Start the coroutine if not already moving
            {
                StartCoroutine(FollowPath());
            }
        }
        lineRenderer.SetPosition(0, transform.position);        //Update the first point of the line to match player's current position
    }

    IEnumerator FollowPath()        //This is the coroutine that moves the player through all stored path points
    {
        isMoving = true;
        foreach (Vector3 target in pathPoints)      //This loops through all path points in the path 
        {
            while (Vector3.Distance(transform.position, target) > 0.05f)       //Continuously move to the target point smoothly  
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                lineRenderer.SetPosition(0, transform.position);       //Continouously update line start position
                yield return null;
            }
            transform.position = target;    //Making sure the player is at the target precisely
        }
        pathPoints.Clear();     //Clear the path and reset line after reaching the final point
        lineRenderer.positionCount = 1;     //This will keep only the player position
        isMoving = false;
    }
}
