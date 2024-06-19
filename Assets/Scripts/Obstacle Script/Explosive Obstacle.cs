using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int damage = 20;
    void Update()
    {
        if (transform.position.y < -10f)
        {
            gameObject.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(explosionPrefab,transform.position,Quaternion.identity);
            collision.gameObject.GetComponent<PlayerHealth>().ApplyDamage(damage);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //collision.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }







}//class
