using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimationEvents : MonoBehaviour
{
    private PlayerControler playercontroler;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        playercontroler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        anim = GetComponent<Animator>();
    }

    void ResetShooting()
    {
        playercontroler.CanShoot = true;
        anim.Play("Ideal");
    }

    void CameraStartGame()
    {
        SceneManager.LoadScene("MainGamePlay");
    }
    void AboutMe()
    {
        SceneManager.LoadScene("AboutMESection");
    }
    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoingToSetting()
    {
        SceneManager.LoadScene("SettingUI");
    }
    public void BackFromSetting()
    {
        SceneManager.LoadScene("MainMenu");
    }

}//class
