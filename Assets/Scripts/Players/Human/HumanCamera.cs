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
      
        

        Vector3 vec = transform.eulerAngles;
        vec.x = m_rotation.x;
        vec.y = m_rotation.y;

        if (m_rotation.magnitude > 0)
        {
            transform.Rotate(-vec.y * Speed * Time.deltaTime, 0, 0, Space.Self);


           
             transform.Rotate(0, -vec.x * Speed * Time.deltaTime, 0, Space.World);
            
            
        }
    }

    void Clamp()
    {
       
    }
}
