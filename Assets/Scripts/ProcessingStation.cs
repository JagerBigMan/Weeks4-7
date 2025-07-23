using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ProcessingStation : MonoBehaviour
{
    public float activationDistance = 0.5f;
    public GameObject partToProcess;
    public GameObject circleOutput;
    public PartSpawner partsSpawner;
    public float moveOutSpeed = 1f;

    public List<GameObject> outputs;

    //New Logic for clickable station
    private bool isInAssemblyMode = false;
    public List<GameObject> assemblyParts;  //This is the stuff inside the assembly mode, I will use this to check for if player clicked them in the right order.
    public List<GameObject> clickedParts;  //This is to check the clicked parts
    public List<string> correctOrder;       //This is for the names of the parts clicked ("Red", "Blue", "Green", etc.)

    public GameObject assemblyUI;

    // Start is called before the first frame update
    void Start()
    {
        outputs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInAssemblyMode && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            if (Vector3.Distance(transform.position, mousePosition) <= activationDistance)
            {
                EnterAssemblyMode();
            }


        }



    }

    void EnterAssemblyMode()
    {
        isInAssemblyMode = true;

        //Show the Assembling Mode UI elements
        if (assemblyUI != null)
        {
            assemblyUI.SetActive(true);
        }
    }

}
    

