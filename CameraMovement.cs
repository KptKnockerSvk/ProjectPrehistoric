using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 CameraPosition;
    private float CameraRotationX, CameraRotationY, CameraRotationZ;

    private bool lockOldMouse = true;
    private float x = 0;



    [Header("Camera Settings")]
    public float CameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        CameraPosition = this.transform.position;
        CameraRotationX = this.transform.localEulerAngles.x;
        CameraRotationY = this.transform.localEulerAngles.y;
        CameraRotationZ = this.transform.localEulerAngles.z;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            CameraPosition.z += CameraSpeed / 10;
        }
        if (Input.GetKey(KeyCode.S))
        {
            CameraPosition.z -= CameraSpeed / 10;
        }
        if (Input.GetKey(KeyCode.A))
        {
            CameraPosition.x -= CameraSpeed / 10;
        }
        if (Input.GetKey(KeyCode.D))
        {
            CameraPosition.x += CameraSpeed / 10;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            CameraRotationY -= CameraSpeed / 10;
        }
        if (Input.GetKey(KeyCode.E))
        {
            CameraRotationY += CameraSpeed / 10;
        }


        if (Input.GetKey(KeyCode.F))
        {
            CameraPosition.y -= CameraSpeed / 10;
        }
        if (Input.GetKey(KeyCode.V))
        {
            CameraPosition.y += CameraSpeed / 10;
        }


        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().fieldOfView -= CameraSpeed * 3;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().fieldOfView += CameraSpeed * 3;
        }


        if (Input.GetMouseButton(1))
        {
            lockOldMouse = false;
            if ((Input.mousePosition.x - x) > 0)
            {
                CameraRotationY -= CameraSpeed / 10;
            }
            else
            {
                CameraRotationY += CameraSpeed / 10;
            }
        }
        else
        {
            lockOldMouse = true;
        }
        

        if (lockOldMouse)
        {            
            x = Input.mousePosition.x;
        }


        this.transform.position = CameraPosition;
        this.transform.rotation = Quaternion.Euler(CameraRotationX, CameraRotationY, CameraRotationZ);
    }
}
