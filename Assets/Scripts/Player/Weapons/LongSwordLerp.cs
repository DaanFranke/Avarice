using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

//public class LongSwordlerp : BaseWeapon
//{
//    public WeaponStats LongSwordStats;
//
//    //If attack is being performed
//    private bool primaryAttacking = false;
//    private bool alternateAttacking = false;
//
//    //Attack stages
//    private int attackStage = 0;
//
//    //Weapon positions
//    [SerializeField] private Vector3 weaponIdlePosition;
//
//    [SerializeField] private Vector3 weaponPrimaryStartAttackPosition;
//    [SerializeField] private Vector3 weaponPrimaryEndAttackPosition;
//
//    [SerializeField] private Vector3 weaponAlternateStartAttackPosition;
//    [SerializeField] private Vector3 weaponAlternateEndAttackPosition;
//
//    //Weapon rotation
//    private Quaternion weaponIdleRotation = new Quaternion(0.482799232f, -0.516628444f, 0.482799232f, -0.516628444f);
//
//    private Quaternion weaponPrimaryStartAttackRotation = new Quaternion(0.370338947f, 0.602369606f, -0.602369606f, 0.370338947f);
//    private Quaternion weaponPrimaryEndAttackRotation = new Quaternion(0.630969763f, 0.319182068f, -0.319182068f, 0.630969763f);
//
//    private quaternion weaponAlternateStartAttackRotation = new Quaternion(-0.0865637809f, 0.647577047f, -0.100307487f, 0.750392675f);
//    private quaternion weaponAlternateEndAttackRotation = new Quaternion(-0.06990356f, 0.649586678f, -0.0810021237f, 0.75272131f);
//
//    //time since movement started
//    private float elapsedTime;
//
//    private void Update()
//    {
//        //primary attack
//        if (primaryAttacking == true) 
//        {
//            elapsedTime += Time.deltaTime;
//            float percentageComplete = elapsedTime / LongSwordStats.primaryDuration;
//
//
//            if (attackStage == 0)
//            {
//                transform.localPosition = Vector3.Lerp(weaponIdlePosition, weaponPrimaryStartAttackPosition, percentageComplete);
//                transform.localRotation = Quaternion.Lerp(weaponIdleRotation, weaponPrimaryStartAttackRotation, percentageComplete);
//
//                ResetTimer();
//            }
//            else if (attackStage == 1)
//            {
//                transform.localPosition = Vector3.Lerp(weaponPrimaryStartAttackPosition, weaponPrimaryEndAttackPosition, percentageComplete);
//                transform.localRotation = Quaternion.Lerp(weaponPrimaryStartAttackRotation, weaponPrimaryEndAttackRotation, percentageComplete);
//
//                ResetTimer();
//            }
//            else if (attackStage == 2)
//            {
//                transform.localPosition = Vector3.Lerp(weaponPrimaryEndAttackPosition, weaponIdlePosition, percentageComplete);
//                transform.localRotation = Quaternion.Lerp(weaponPrimaryEndAttackRotation, weaponIdleRotation, percentageComplete);
//
//                ResetTimer();
//            }
//            else if (attackStage == 3) 
//            { 
//                primaryAttacking = false;
//                elapsedTime = 0;
//                attackStage = 0;
//            }
//        }
//
//        //Alternate attack
//        if (alternateAttacking == true)
//        {
//            elapsedTime += Time.deltaTime;
//            float percentageComplete = elapsedTime / LongSwordStats.primaryDuration;
//
//
//            if (attackStage == 0)
//            {
//                transform.localPosition = Vector3.Lerp(weaponIdlePosition, weaponAlternateStartAttackPosition, percentageComplete);
//                transform.localRotation = Quaternion.Lerp(weaponIdleRotation, weaponAlternateStartAttackRotation, percentageComplete);
//
//                ResetTimer();
//            }
//            else if (attackStage == 1)
//            {
//                transform.localPosition = Vector3.Lerp(weaponAlternateStartAttackPosition, weaponAlternateEndAttackPosition, percentageComplete);
//                transform.localRotation = Quaternion.Lerp(weaponAlternateStartAttackRotation, weaponAlternateEndAttackRotation, percentageComplete);
//
//                ResetTimer();
//            }
//            else if (attackStage == 2)
//            {
//                transform.localPosition = Vector3.Lerp(weaponAlternateEndAttackPosition, weaponIdlePosition, percentageComplete);
//                transform.localRotation = Quaternion.Lerp(weaponAlternateEndAttackRotation, weaponIdleRotation, percentageComplete);
//
//                ResetTimer();
//            }
//            else if (attackStage == 3)
//            {
//                alternateAttacking = false;
//                elapsedTime = 0;
//                attackStage = 0;
//            }
//        }
//    }
//
//    private void ResetTimer() 
//    {
//        if (elapsedTime >= LongSwordStats.primaryDuration)
//        {
//            attackStage++;
//            elapsedTime = 0;
//
//            Debug.Log("Attack stage: " + attackStage);
//        }
//    }
//
//    public override void PrimaryAttack(InputAction.CallbackContext context)
//    {
//        if (context.performed && primaryAttacking == false && alternateAttacking == false) primaryAttacking = true;
//    }
//
//    public override void AlternateAttack(InputAction.CallbackContext context)
//    {
//        if (context.performed && alternateAttacking == false && primaryAttacking == false) alternateAttacking = true;
//    }
//}
