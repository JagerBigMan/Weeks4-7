using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessingStation : MonoBehaviour
{
    public float activationDistance = 0.5f;
    public GameObject partToProcess;
    public GameObject circleOutput;
    public PartSpawner partsSpawner;
    public float moveOutSpeed = 1f;

    public List<GameObject> outputs;

    // Start is called before the first frame update
    void Start()
    {
        outputs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (partsSpawner.spawnedParts.Count > 0)
        {
            for (int index = 0; index < partsSpawner.spawnedParts.Count; index++)
            {
                float activationRange = (transform.position.x - partsSpawner.spawnedParts[index].transform.position.x);

                if (activationRange <= activationDistance)
                {
                    Vector3 spawnPosition = partsSpawner.spawnedParts[index].transform.position;

                    Destroy(partsSpawner.spawnedParts[index]);

                    partsSpawner.spawnedParts.RemoveAt(index); //searched online for solution to remove the first index of a list  https://discussions.unity.com/t/lists-and-removeat/651500 

                    GameObject output = Instantiate(circleOutput, spawnPosition, Quaternion.identity);
                    output.transform.position += Vector3.right * moveOutSpeed * Time.deltaTime;

                }
            }
        }
    }
}


