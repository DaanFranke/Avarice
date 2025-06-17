using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public GameObject staminaBar;
    public GameObject healthBar;

    private Slider staminaSlider;
    private Slider healthSlider;

    private void Start()
    {
        staminaSlider = staminaBar.GetComponent<Slider>();
        healthSlider = healthBar.GetComponent<Slider>();
    }

    public void SetMaxStamina(float maxStamina) 
    { 
        staminaSlider.maxValue = maxStamina;
    }

    public void setMaxHealth(float maxHealth) 
    { 
        healthSlider.maxValue = maxHealth;
    }

    public void SetStaminaBar(float stamina) 
    { 
        staminaSlider.value = stamina;
    }

    public void SetHealthBar(float health) 
    { 
        healthSlider.value = health;
    }

}
