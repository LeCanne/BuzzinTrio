using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoskitoCamera : MonoBehaviour
{
    public float speed;
    public float maxDistance;
    public GameObject positionHold;
    private Vector2 m_Position;
    private Vector3 origin;
    private Transform posCam;
    public GameObject moskitoSkin;
    private MoskitoControls m_Controls;
    public MoskitoController m_Controller;
    private InputAction rotationCamera;
    private PlayerIndexCheck _playerInput;
    private int Check;
    private Camera _camera;
    

    public bool checkStung;



    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _playerInput = GameObject.FindWithTag("PlayerManager").GetComponent<PlayerIndexCheck>();
        Check = _playerInput.MoskitoCameraCheck;
        GetPlayer();
        origin = positionHold.transform.localPosition;
       
        
    }
    private void OnEnable()
    {
       
    }
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
       
    }

    
    void Update()
    {
        //We only move the camera holder.
        transform.position = positionHold.transform.position;

        if (checkStung == false)
        {
            ResetCam();
            MouseRotation();
            RotationResetter();
        }
        else
        {
            positionHold.transform.localPosition = Vector3.Lerp(positionHold.transform.localPosition, new Vector3(origin.z, origin.y, origin.z - maxDistance), 3 * Time.deltaTime);
            transform.LookAt(moskitoSkin.transform);
        }
       
      
    }

    public void ValueGet(InputAction.CallbackContext PunchASkito)
    {
        m_Position = PunchASkito.ReadValue<Vector2>();
    }
   void MouseRotation()
    {
        
      
       
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
        if(Vector3.Distance(positionHold.transform.localPosition, origin) > 0.2f)
        {
            positionHold.transform.localPosition = Vector3.Lerp(positionHold.transform.localPosition, origin, 3 * Time.deltaTime);
        }
        else
        {
            positionHold.transform.localPosition = origin;
        }
      
    }

    void GetPlayer()
    {
        if (Check == 0)
        {
            _camera.rect = new Rect(0.5f, 0.67f, 0.5f, 0.33f);
        }

        if (Check == 1)
        {
            _camera.rect = new Rect(0.5f, 0.335f, 0.5f, 0.33f);
        }

        if (Check == 2)
        {
            _camera.rect = new Rect(0.5f, 0f, 0.5f, 0.33f);
        }
    }
}
