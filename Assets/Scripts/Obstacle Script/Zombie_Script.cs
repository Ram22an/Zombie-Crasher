using System;
using UnityEngine;

public class Zombie_Script : MonoBehaviour
{
    public GameObject bloodFXPrefab;
    private float speed = 1f;
    private Rigidbody myBody;
    private bool isAlive;
    private System.Random random = new System.Random();
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        isAlive = true;
        speed = random.Next(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            myBody.velocity = new Vector3(0f, 0f, -speed);
        }
        if (transform.position.y < -10f)
        {
            gameObject.SetActive(false);
        }
    }
    void Die()
    {
        isAlive = false;
        myBody.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Animator>().Play("Idle");
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        transform.localScale = new Vector3(1f, 1f, 0.2f);
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            Instantiate(bloodFXPrefab, transform.position,Quaternion.identity);
            Invoke("Deactivate",3f);
            GamePlayeController.Instance.IncreaseScore();
            Die();
        }
        if (collision.gameObject.tag == "Bullet")
        {
            collision.gameObject.SetActive(false);
            Instantiate(bloodFXPrefab, transform.position, Quaternion.identity);
            Invoke("Deactivate", 3f);
            GamePlayeController.Instance.IncreaseScore();
            Die();
        }

    }



}//class
