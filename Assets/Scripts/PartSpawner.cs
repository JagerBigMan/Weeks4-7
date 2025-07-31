using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSpawner : MonoBehaviour
{
    public GameObject squarePartPrefab;     
    public GameObject circlePartPrefab;
    public GameObject trianglePartPrefab;
    public List<GameObject> spawnedParts;


    // Start is called before the first frame update
    void Start()
    {
        spawnedParts = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called by button click
    public void SpawnSquarePart()
    {
        SpawnPart(squarePartPrefab);
    }

    public void SpawnCirclePart()
    {
        SpawnPart(circlePartPrefab);
    }

    public void SpawnTrianglePart()
    {
        SpawnPart(trianglePartPrefab);
    }
    private void SpawnPart(GameObject partPrefab)
    {
        Vector3 spawnPosition = transform.position;     //Spawn at the origin of the spawner
        GameObject spawnedpart = Instantiate(partPrefab, spawnPosition, Quaternion.identity);
        spawnedParts.Add(spawnedpart);

        SpriteRenderer sr = spawnedpart.GetComponent<SpriteRenderer>();         //To colour the part through SpriteRenderer
        if(sr != null )
        {
            sr.color = GetColorForParts(partPrefab);
        }
    }

    private Color GetColorForParts(GameObject partPrefab)
    {
        if (partPrefab == squarePartPrefab)
            return Color.blue;
        else if (partPrefab == circlePartPrefab)
            return Color.yellow;
        else if (partPrefab == trianglePartPrefab)
            return Color.green;

        return Color.white;                                     // Default fallback if nothing matches the listed above
    }
}
