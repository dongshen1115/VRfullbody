using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VRmirror_rotation : MonoBehaviour
{
    public float Pos_x, Pos_y, Pos_z;
    public float Rot_x, Rot_y, Rot_z;
    public GameObject _object;
    public GameObject mirror_object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform mirrorRot = mirror_object.GetComponent<Transform>();

        Rot_x = (float)Math.Round(_object.transform.rotation.eulerAngles.x,4);
        Rot_y = (float)Math.Round(_object.transform.rotation.eulerAngles.y, 4);
        Rot_z = (float)Math.Round(_object.transform.rotation.eulerAngles.z, 4);
        if (Rot_x < 0)
        {
            Rot_x = Rot_x + 360;
        }

        if (Rot_y < 0)
        {
            Rot_y = Rot_y + 360;
        }

        if (Rot_z < 0)
        {
            Rot_z = Rot_z + 360;
        }

        Quaternion result = Quaternion.Euler(Rot_x + 180, -Rot_y, Rot_z);
        mirrorRot.rotation = result;
    }
}

