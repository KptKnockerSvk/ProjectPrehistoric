using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public ResourceManager script;
    public ChoiceManager scriptTwo;

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetMouseButtonDown(1))
        {
            Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(movePosition, out var hitInfo))
            {
                Debug.Log("Moving");
                scriptTwo.figToMove.SetDestination(hitInfo.point);
            }
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wood"))
        {
            Destroy(collision.gameObject);
            script.totalWood++;
        }
    }
}
