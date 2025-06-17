using UnityEngine;
using UnityEngine.InputSystem;

public class BaseWeapon : MonoBehaviour
{
    public WeaponStats weaponStats;
    public bool outOfStamina;
    public Animator animator;
    public PlayerResources resourcesReference;

    public AttackType currentAttack = AttackType.None;

    public GameObject previousTarget;

    public enum AttackType 
    { 
        None,
        Primary,
        Alternate,
        followUpWindow
    }

    public void Awake()
    {
        resourcesReference = GetComponentInParent<PlayerResources>();
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        outOfStamina = resourcesReference.outOfStamina;
    }

    public virtual void PrimaryAttack(InputAction.CallbackContext context) 
    {
        if (context.performed && currentAttack == AttackType.None && outOfStamina == false)
        {
            currentAttack = AttackType.Primary;

            resourcesReference.StaminaChange(weaponStats.primaryStaminaCost);

            animator.SetTrigger("PrimaryAttack");
        }
        else if (context.performed && currentAttack == AttackType.followUpWindow && outOfStamina == false) 
        {
            resourcesReference.StaminaChange(weaponStats.primaryStaminaCost);

            animator.SetTrigger("PrimaryFollowUpAttack");
        }
    }

    public virtual void AlternateAttack(InputAction.CallbackContext context) 
    {
        if (context.performed && currentAttack == AttackType.None && outOfStamina == false)
        {
            currentAttack = AttackType.Alternate;

            resourcesReference.StaminaChange(weaponStats.alternateStaminaCost);

            animator.SetTrigger("AlternateAttack");
        }
    }

    public virtual void AttackEnd() 
    {
        previousTarget = null;

        if (currentAttack == AttackType.Primary) 
        {
            currentAttack = AttackType.followUpWindow;
        }
        else currentAttack = AttackType.None;
    }

    public virtual void OnTriggerEnter(Collider other) 
    {
        GameObject target = other.gameObject;

        if (target == previousTarget) 
        {
            return;
        }

        if (!target.CompareTag("Enemy") && !target.CompareTag("Hittable")) 
        {
            return;
        }

        BaseEnemy targetScript = target.GetComponent<BaseEnemy>();

        if (currentAttack == AttackType.Primary) 
        {
            targetScript.DamageTaken(weaponStats.primaryDamage);
        }
        else if (currentAttack == AttackType.Alternate) 
        {
            targetScript.DamageTaken(weaponStats.alternateDamage);
        }

        previousTarget = target;
    }

}
