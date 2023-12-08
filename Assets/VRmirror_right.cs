using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VRmirror_right : MonoBehaviour
{


    public GameObject leftHand;
    public GameObject rightHand;
    public float Pos_x, Pos_y, Pos_z;
    public float Rot_x, Rot_y, Rot_z;
    public GameObject leftHandAnchor;
    public GameObject rightHandAnchor;

    public Transform playerTransform;

    Vector3 currentPosition;



    public void ResetMirror()
    {
        leftHand.transform.position = leftHandAnchor.transform.position;
        leftHand.transform.rotation = leftHandAnchor.transform.rotation;
        rightHand.transform.position = rightHandAnchor.transform.position;
        rightHand.transform.rotation = rightHandAnchor.transform.rotation;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform left = leftHand.GetComponent<Transform>();
        Transform right = rightHand.GetComponent<Transform>();

        EnableMirror();

        //MirrorFromTo(left, right);
        MirrorFromTo(right, left);



    }
    public void EnableMirror()
    {

        rightHand.SetActive(true);
        leftHand.GetComponent<OVRHand>().HandType = OVRHand.Hand.HandRight;

    }
    public void SetCurrentTransform()
    {
        currentPosition = playerTransform.right;
    }

    public void MirrorFromTo(Transform sourceTransform, Transform destTransform)
    {

        //Vector3 playerToSourceHand = sourceTransform.position - playerTransform.position;
        // Vector3 playerToDestHand = ReflectRelativeVector(playerToSourceHand);
        //destTransform.position = playerTransform.position + playerToDestHand;


        Pos_x = sourceTransform.GetComponent<Transform>().position.x;
        Pos_y = sourceTransform.GetComponent<Transform>().position.y;
        Pos_z = sourceTransform.GetComponent<Transform>().position.z;
        Vector3 objposition = new Vector3(-Pos_x, Pos_y, Pos_z);
        destTransform.position = objposition;





        /*Vector3 forwardVec = sourceTransform.forward;//z�b
        
        Vector3 rightVec = sourceTransform.right;//x�b
        Vector3 upVec = sourceTransform.up;//y�b
        Vector3 rightup = -rightVec + upVec;
        destTransform.rotation = Quaternion.LookRotation(-forwardVec, rightup);*/



        /*Rot_x = sourceTransform.GetComponent<Transform>().rotation.x;
        Rot_y = sourceTransform.GetComponent<Transform>().rotation.y;
        Rot_z = sourceTransform.GetComponent<Transform>().rotation.z;
        //destTransform.localEulerAngles = new Vector3(-Rot_x, -Rot_y, -Rot_z);
        destTransform.rotation = Quaternion.Euler(-Rot_x, Rot_y, Rot_z);*/




    }

    Vector3 ReflectRelativeVector(Vector3 relativeVec)
    {
        return -relativeVec + Vector3.Dot(relativeVec, currentPosition) * currentPosition * -2f;
    }
}
