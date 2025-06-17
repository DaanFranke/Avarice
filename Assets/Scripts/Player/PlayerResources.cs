using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    //Health
    public float maxHealth = 100;
    public float currentHealth;

    //Stamina
    public float maxStamina = 100;
    public float currentStamina;
    public float staminaRegenSpeed;
    
    public bool outOfStamina = false;
    public float recoveryTimeOOS;
    private float startOOS;
    private float endOOS;

    private float lastStaminaChange;
    public float StaminaRecoveryCD;

    //references
    private PlayerMovement playerMovementReference;
    private bool isSprinting;
    private GameObject hudReference;
    private Hud hudScriptReference;

    private void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;

        //Gets various refferences
        playerMovementReference = GetComponent<PlayerMovement>();

        hudReference = GameObject.Find("Hud");
        hudScriptReference = hudReference.GetComponentInChildren<Hud>();
    }

    private void Update()
    {
        isSprinting = playerMovementReference.isSprinting;

        if (Time.time >= lastStaminaChange + StaminaRecoveryCD) 
        {
            StaminaRegen();
        }
        
        //Updates hud stamina and health bars
        hudScriptReference.SetStaminaBar(currentStamina);
    }

    private void StaminaRegen() 
    {
        OutOfStaminaCheck();

        if (currentStamina < maxStamina && outOfStamina == false && isSprinting == false) 
        {
            currentStamina = Mathf.Min(currentStamina + staminaRegenSpeed * Time.deltaTime, maxStamina);
        }
    }

    private void OutOfStaminaCheck() 
    {
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
        if (currentStamina == 0 && outOfStamina == false)
        {
            outOfStamina = true;
            startOOS = Time.time;
            endOOS = startOOS + recoveryTimeOOS;
        }
        if (outOfStamina == true && Time.time >= endOOS)
        {
            outOfStamina = false;
        }
    }

    public bool StaminaChange(float changeAmount) 
    { 
        if (outOfStamina == false ) 
        {
            currentStamina += changeAmount;

            lastStaminaChange = Time.time;
        }

        return outOfStamina;
    }

    public void HealthChange(float changeAmount)
    {
        if (currentHealth + changeAmount <= 0) 
        {
            //insert player death and respawn function
            Debug.Log("player died");
        }
        else 
        {
            currentHealth += changeAmount;
        }

        hudScriptReference.SetHealthBar(currentHealth);
    }

}
