using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorBelt : MonoBehaviour
{
    public float conveyorBeltSpeed = 2f;
    public GameObject partToMove; //This is where I will put the prefab so that it will detect it and move it
    public float activationDistance = 1f; //how close an object must be to get on the conveyor belt
    public Vector3 moveDirection = Vector3.right; //direction to push 
    public PartSpawner partsSpawner;

    public Slider speedController;
    public float minBeltSpeed;
    public float maxBeltSpeed;
    private float currentBeltSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if( speedController != null )
        {
            speedController.minValue = minBeltSpeed;
            speedController.maxValue = maxBeltSpeed;
            speedController.value = conveyorBeltSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (speedController != null)
        {
            {
                conveyorBeltSpeed = speedController.value;
            }
        }
        if (partsSpawner.spawnedParts.Count > 0)
        {
            for (int index = 0; index < partsSpawner.spawnedParts.Count; index++)
            {
                float distance = Mathf.Abs(transform.position.y - partsSpawner.spawnedParts[index].transform.position.y);

                if (distance <= activationDistance)
                {
                    partsSpawner.spawnedParts[index].GetComponent<UnassembledParts>().dropSpeed = 0f;

                    partsSpawner.spawnedParts[index].transform.position += moveDirection * conveyorBeltSpeed * Time.deltaTime;
                }



            }
        }

    }
}
