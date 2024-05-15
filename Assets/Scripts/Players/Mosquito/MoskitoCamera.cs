using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoskitoCamera : MonoBehaviour
{
    public float speed;
    public GameObject positionHold;
    private Vector2 m_Position;
    private Vector3 origin;
    private MoskitoControls m_Controls;
    private InputAction rotationCamera;

    public bool checkStung;



    private void Awake()
    {
        m_Controls = new MoskitoControls();
        origin = positionHold.transform.position;
    }
    private void OnEnable()
    {
        rotationCamera = m_Controls.Moskito.Camera;

        rotationCamera.Enable();
    }
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    
    void Update()
    {
        if(checkStung == false)
        {
            ResetCam();
            MouseRotation();
            RotationResetter();
        }

        else
        {
            positionHold.transform.position = new Vector3(origin.z, origin.y, origin.z - 2);
        }
        transform.position = positionHold.transform.position;
    }

   void MouseRotation()
    {
        
        m_Position = rotationCamera.ReadValue<Vector2>();
       
        Vector3 vec = transform.eulerAngles;
        vec.x = m_Position.x;
        vec.y = m_Position.y;

        if(m_Position.magnitude > 0)
        {
            transform.Rotate(-vec.y * speed * Time.deltaTime, 0, 0, Space.Self);
          

            if (Vector3.Dot(transform.up, Vector3.down) > 0)
            {
                transform.Rotate(0, -vec.x * speed * Time.deltaTime, 0, Space.World);
            }
            else
            {
                transform.Rotate(0, vec.x * speed * Time.deltaTime, 0, Space.World);
            }
               


        }
        
        
    }

    void RotationResetter()
    {
        if(transform.eulerAngles.x <= -90)
        {
            transform.eulerAngles = new Vector3(359.9f, transform.eulerAngles.y, 0);
        }

        if(transform.eulerAngles.x >= 360)
        {
            transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);
        }
    }

    void ResetCam()
    {
       // positionHold.transform.position = origin;
    }
}
