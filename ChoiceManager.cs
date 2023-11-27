using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChoiceManager : MonoBehaviour
{
    public NavMeshAgent[] agents;
    public NavMeshAgent figToMove;
    private Vector3 pos;
    private bool posBool = false;
    [SerializeField] private LayerMask layerMask;
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000, layerMask))
            {
                pos = hit.point;
                posBool = true;
            }
        }

        if (posBool)
        {
            for (int i = 0; i < agents.Length; i++)
            {
                float x = pos.x - agents[i].transform.position.x;
                float z = pos.z - agents[i].transform.position.z;
                if (-0.7 < x && x < 0.7 && -0.7 < z && z < 0.7)
                {
                    Debug.Log("chosen" + i);
                    figToMove = agents[i];
                }


            }
            posBool = false;
        }
    }
}
