using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class HumanCamera : MonoBehaviour
{
    private MoskitoControls m_controls;
    private InputAction camVec;
    public float Speed;
    private Vector2 m_rotation;
    // Start is called before the first frame update
    private void Awake()
    {
        m_controls = new MoskitoControls();
        camVec = m_controls.Human.Camera;
    }

    private void OnEnable()
    {
        camVec.Enable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseRotate();
        Clamp();
    }

    void MouseRotate()
    {
        m_rotation = camVec.ReadValue<Vector2>();
        Debug.Log(camVec.ReadValue<Vector2>());

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
        transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, -90, 90), transform.eulerAngles.y, 0);
    }
}
