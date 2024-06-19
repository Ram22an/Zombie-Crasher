using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody myBody;
    
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    public void Move(float Speed)
    {
        myBody.AddForce(transform.forward.normalized * Speed);
        Invoke("Deactivate", 5f);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "Obstacle") 
        { 
            gameObject.SetActive(false);
        }
    }




}//class
