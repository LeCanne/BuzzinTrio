using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class HumanCamera : MonoBehaviour
{
   
    private InputAction camVec;
    public float Speed;
    private Vector2 m_rotation;
    public GameObject followTransform;
    private Vector2 variableCam;

    [Header("CameraSettings")]
    public float max;
    public float min;
    
     
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followTransform.transform.position;
        MouseRotate();
        Clamp();

    }

    public void CameraMovement(InputAction.CallbackContext valuecam)
    {
        m_rotation = valuecam.ReadValue<Vector2>();
    }
    void MouseRotate()
    {
      
        

      
        variableCam.x += m_rotation.x * Speed * Time.deltaTime;
        variableCam.y -= m_rotation.y * Speed * Time.deltaTime;

        variableCam.y = Mathf.Clamp(variableCam.y, max, min);

        if (m_rotation.magnitude > 0)
        {
           transform.eulerAngles = new Vector3(variableCam.y, variableCam.x, 0);


           
          
            
            
        }
    }

    void Clamp()
    {
       
    }
}
