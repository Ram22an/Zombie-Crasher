using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : MonoBehaviour
{
    public Vector3 Speed;
    public float x_speed = 16f, z_speed = 15f;
    public float accelerated = 15f, deccelarated = 10f;
    protected float rotationSpeed = 10f;
    protected float maxAngle = 10f;
    public float low_Sound_Pitch, normal_Sound_Pitch, high_Sound_Pitch;
    public AudioClip Engin_on_Sound,Engin_off_Sound;
    private bool is_Slow;
    public AudioSource SoundManager;
    private void Awake()
    {
        //SoundManager = GetComponent<AudioSource>();
        Speed = new Vector3(0f, 0f, z_speed);
    }
    protected void MoveLeft()
    {
        Speed=new Vector3(-x_speed/2f,0f, Speed.z);
    }
    protected void MoveRight()
    {
        Speed = new Vector3(x_speed / 2f, 0f, Speed.z);
    }
    protected void MoveStraight()
    {
        Speed = new Vector3(0f, 0f, Speed.z);
    }
    protected void MoveNormal()
    {
        if (is_Slow)
        {
            is_Slow = false;
            SoundManager.Stop();
            SoundManager.clip = Engin_on_Sound;
            SoundManager.volume = 0.3f;
            SoundManager.Play();
        }
        Speed = new Vector3(Speed.x, 0f, z_speed);

    }
    protected void MoveSlow()
    {
        if (!is_Slow)
        {
            is_Slow = true;
            SoundManager.Stop();
            SoundManager.clip= Engin_off_Sound;
            SoundManager.volume = 0.5f;
            SoundManager.Play();
        }
        Speed = new Vector3(Speed.x, 0f, deccelarated);
    }
    protected void MoveFast()
    {
        Speed = new Vector3(Speed.x, 0f, accelerated);
    }









}//class
