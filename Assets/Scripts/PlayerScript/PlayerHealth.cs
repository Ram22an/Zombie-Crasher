using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int healthValue = 100;
    private Slider health_Slider;
    private GameObject UI_holder;


    // Start is called before the first frame update
    void Awake()
    {
        health_Slider = GameObject.Find("healthBar").GetComponent<Slider>();
        health_Slider.value = healthValue;
        UI_holder = GameObject.Find("uiHolder");
    }
    public void ApplyDamage(int DamageAmount)
    {
        healthValue -= DamageAmount;
        if(healthValue < 0)
        {
            healthValue = 0;
        }
        health_Slider.value=healthValue;
        if(healthValue == 0)
        {
            UI_holder.SetActive(false);
            GamePlayeController.Instance.GameOver();
        }
    }




}//class
