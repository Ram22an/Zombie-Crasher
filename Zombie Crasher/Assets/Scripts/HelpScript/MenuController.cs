using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator anim;
    public void PlayeGame()
    {
        anim.Play("Cameramove");
    }

    public void goingToAboutME()
    {
        anim.Play("GoingToAboutMe");
    }
    public void GoingBackToMain()
    {
        anim.Play("GoingBackTOMain");
    }
    public void GoingToSetting()
    {
        anim.Play("SettingGoing");
    }
    public void BackToSetting()
    {
        anim.Play("SettingOut");
    }


}//class
