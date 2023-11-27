using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject pendingObject;

    private Vector3 pos;
    private Vector3 posCopy;
    private Vector3 agentPos;

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    public float gridSize;
    bool gridOn = true;
    [SerializeField] private Toggle gridToggle;
    public float rotateAmount;

    public ResourceManager script;
    public ChoiceManager scriptTwo;

    private NavMeshAgent agent;

    private List<int> price = new List<int>() { 3, 2, 1 };
    private float x = 0f;
    private float z = 0f;
    private bool goToo = false;
    private bool fixPosition = false;

    void Update()
    {        
        if (pendingObject != null)
        {
            
            for (int i = 0; i < scriptTwo.agents.Length; i++)
            {
                if (scriptTwo.agents[i].CompareTag("Builder"))
                {                    
                    agent = scriptTwo.agents[i];
                    agentPos = agent.transform.position;
                }
            } 
            
            if (gridOn)
            {
                if (fixPosition == false)
                {
                    pendingObject.transform.position = new Vector3(
                        RoundToNearestGrid(pos.x),
                        RoundToNearestGrid(pos.y),
                        RoundToNearestGrid(pos.z)
                        );
                }
            }
            else
            {
                if (fixPosition == false)
                {
                    pendingObject.transform.position = pos;
                }
            }
            
            if(Input.GetMouseButtonDown(0) && goToo == false)
            {
                agent.SetDestination(pos);
                goToo = true;
                fixPosition = true;
                pendingObject.GetComponent<MeshRenderer>().enabled = false;
                posCopy = pos;
            }

            x = agentPos.x - posCopy.x;
            z = agentPos.z - posCopy.z;
            if ( x < 1 && z < 1 && goToo && -1 < x && -1 < z)
            {
                pendingObject.GetComponent<MeshRenderer>().enabled = true;
                goToo = false;
                PlaceObject();
                
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
        }
    }

    public void PlaceObject()
    {    
        script.totalWood--;
        pendingObject = null;
        fixPosition = false;
    }

    public void RotateObject()
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;            
        }
    }

    public void SelectObject(int index)
    {
        
        int clickedValue = price[index];
        if (clickedValue <= script.totalWood)
        {
            pendingObject = Instantiate(objects[index], pos, transform.rotation);
        }
    }

    public void ToggleGrid()
    {
        if(gridToggle.isOn)
        {
            gridOn = true;
        }
        else { gridOn = false; }
    }

    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if(xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}
