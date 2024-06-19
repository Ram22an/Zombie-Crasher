using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingMenuController : MonoBehaviour
{
    public Animator anim;

    void Awake()
    {
        anim.Play("LoadingAnimation");
    }
}
    