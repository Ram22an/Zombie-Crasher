using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float timer = 3f;
    void Start()
    {
        Invoke("DeactivateGameObject",timer);   
    }
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }








}//class
