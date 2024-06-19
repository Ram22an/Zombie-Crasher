using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform Target;

    public float Distance = 6.3f;
    public float Height = 3.5f;

    public float HeightDamping=3.25f;
    public float RotationDamping = 0.27f;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;   
    }
    void LateUpdate()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        float Wanted_Rotation_Angle=Target.rotation.eulerAngles.y;
        float Wanted_height = Target.position.y+Height;
        float Current_Rotation_Angle=transform.rotation.eulerAngles.y;
        float Current_Height=transform.position.y;

        //Moving from angle A° to angle B° in time T  
        Current_Rotation_Angle = Mathf.LerpAngle(Current_Rotation_Angle,
            Wanted_Rotation_Angle,RotationDamping*Time.deltaTime);

        //Moving from point A to point B in time T
        Current_Height = Mathf.Lerp(Current_Height, Wanted_height, HeightDamping * Time.deltaTime);

        Quaternion Current_Rotation = Quaternion.Euler(0f, Current_Rotation_Angle, 0f);
       

        transform.position = Target.position;
        transform.position -= Current_Rotation * Vector3.forward * Distance;
        transform.position=new Vector3(transform.position.x,Current_Height,transform.position.z);

    }










}//class
