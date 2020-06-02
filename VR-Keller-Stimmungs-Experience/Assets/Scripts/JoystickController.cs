using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using Valve.VR;

public class JoystickController : MonoBehaviour
{
    public Transform cam_transform;
    public SteamVR_Action_Vector2 input;
    public SteamVR_Action_Vector2 turn_input;
    public float speed = 1;
    public float turn_speed = 1;
    private Quaternion rot;
    private float euler_X;
    private float euler_Y;
    private float euler_Z;
    private Vector3 tmp_fix;

    void Start() 
    {
        rot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //transformation
        tmp_fix = cam_transform.forward;
        tmp_fix.y = 0;
        this.transform.position += speed * Time.deltaTime * tmp_fix * input.axis.y;
        tmp_fix = cam_transform.right;
        tmp_fix.y = 0;
        this.transform.position += speed * Time.deltaTime * tmp_fix * input.axis.x; 

         //Rotation mit dem Joystick
         euler_X = this.transform.rotation.eulerAngles.x;
        euler_Y = this.transform.rotation.eulerAngles.y + turn_input.axis.x;
        euler_Z = this.transform.rotation.eulerAngles.z;
        this.transform.rotation = Quaternion.Euler(euler_X, euler_Y, euler_Z);

    }
}
