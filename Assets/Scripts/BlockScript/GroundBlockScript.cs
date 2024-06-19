using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlockScript : MonoBehaviour
{
    public Transform OtherBlock;
    public float HalfLenght = 100f;
    private Transform Player;
    private float EndoffSet = 10f;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();
    }

    void MoveGround()
    {
        if (transform.position.z+HalfLenght<Player.transform.position.z - EndoffSet)
        {
            transform.position=new Vector3(OtherBlock.position.x,OtherBlock.position.y,OtherBlock.position.z+HalfLenght*2-7);
        }
    }






}//class
