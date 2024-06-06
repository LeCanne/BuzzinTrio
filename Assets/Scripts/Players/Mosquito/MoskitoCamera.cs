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
    private Vector3 cameraOffset;
    public Transform posCam;
    public LayerMask layerMask;
    public GameObject moskitoSkin;
    private MoskitoControls m_Controls;
    public MoskitoController m_Controller;
    private InputAction rotationCamera;
    private RaycastHit hit;
   
    private int Check;
    private Camera _camera;
    

    public bool checkStung;



    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
        cameraOffset = posCam.localPosition;
        origin = transform.localPosition;
        Check = PlayerIndexCheck.instance.MoskitoCameraCheck;
        GetPlayer();
       
       
        
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
        transform.position = positionHold.transform.position;

        MouseRotation();
       
       
        if (checkStung == false)
        {
            cameraOffset = new Vector3(0, 0, 0);
            RotationResetter();
            ResetCam();


        }
        else
        {
            cameraOffset = new Vector3(0, 0, -0.5f);
            CollisionDetection();
           
            //transform.LookAt(moskitoSkin.transform);
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

            if (m_Position.magnitude > 0)
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

    void CollisionDetection()
    {
      
        Debug.DrawLine(transform.position, (transform.position + transform.localRotation * cameraOffset) - posCam.transform.forward, Color.red);
        if (Physics.Linecast(transform.position, (transform.position + transform.localRotation * cameraOffset) - posCam.transform.forward, out hit))
        {
            Debug.Log(hit.collider.name);
                posCam.localPosition = new Vector3(0, 0, Vector3.Distance(transform.position, hit.point + posCam.transform.forward));
            
           



        }
        else
        {
            posCam.localPosition = Vector3.Lerp(posCam.localPosition, cameraOffset, Time.deltaTime);
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
        if(Vector3.Distance(posCam.localPosition, origin) > 0.2f)
        {
            posCam.localPosition = Vector3.Lerp(posCam.localPosition, origin, 3 * Time.deltaTime);
        }
        else
        {
           posCam.localPosition = origin;
        }
      
    }

    void GetPlayer()
    {
        if (PlayerIndexCheck.instance._inputManager.playerCount == 2)
        {
            if (Check == 0)
            {
                _camera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
            }


        }
        if (PlayerIndexCheck.instance._inputManager.playerCount == 3)
        {
            if (Check == 0)
            {
                _camera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            }

            if (Check == 1)
            {
                
                _camera.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
            }

        }
        if (PlayerIndexCheck.instance._inputManager.playerCount == 4)
        {
            if (Check == 0)
            {
                _camera.rect = new Rect(0.5f, 0f, 0.5f, 0.325f);
            }

            if (Check == 1)
            {
                _camera.rect = new Rect(0.5f, 0.337f, 0.5f, 0.325f);
            }

            if (Check == 2)
            {
                _camera.rect = new Rect(0.5f, 0.675f, 0.5f, 0.325f);
            }
        }
        
    }
}
