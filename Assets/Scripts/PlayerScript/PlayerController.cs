using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : PlayerBasic
{
    public Transform Bullet_Startpoint;
    public GameObject BulletPrefab;
    public ParticleSystem ShootFx;
    private Rigidbody myBody;
    public AudioSource SoundManagerPlayer;
    private Animator ShootSliderAnim;
    [HideInInspector]
    public bool CanShoot;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        GameObject.Find("ShootingButton").GetComponent<Button>().onClick.AddListener(ShootControl);
        CanShoot = true;
        ShootSliderAnim=GameObject.Find("FireBar").GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundManagerPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        ControlMovementWithKeyboard();
        ChangeRotation();
       
    }

    void FixedUpdate()
    {
        MoveTank();
    }
    void MoveTank()
    {
        myBody.MovePosition(myBody.position+Speed*Time.deltaTime);
    }

    void ControlMovementWithKeyboard()
    {
        //here we are changing direction
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveFast();
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveSlow();
        }



        //Here moveing straight after pressing button
        if (Input.GetKeyUp(KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.A)) 
        {
            MoveStraight();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            MoveStraight();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            MoveNormal();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            MoveNormal();
        }
    }

    void ChangeRotation()
    {
        if (Speed.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f,maxAngle,0f),Time.deltaTime*rotationSpeed);
        }
        else if (Speed.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f, -maxAngle, 0f), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f, 0f,0f), Time.deltaTime * rotationSpeed);
        }
    }
    

    public void ShootControl()
    {
        if (Time.timeScale!=0) 
        {
            if (CanShoot)
            {
                GameObject Bullet = Instantiate(BulletPrefab, Bullet_Startpoint.position, Quaternion.identity);
                Bullet.GetComponent<BulletScript>().Move(2000f);
                ShootFx.Play();
                CanShoot = false;
                ShootSliderAnim.Play("Fill");
            }
        }
    }








}//class
