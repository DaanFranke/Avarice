using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public GameObject equippedWeapon;
    private BaseWeapon weaponScript;

    private void Awake()
    {
        Transform camera = transform.Find("Main Camera");

        foreach (Transform child in camera) 
        { 
            GameObject childObject = child.gameObject;

            if (childObject.CompareTag("Weapon"))
            { 
                ChangeWeapon(childObject);
            }
        }
    }

    public void ChangeWeapon(GameObject newWeapon) 
    { 
        equippedWeapon = newWeapon;
        weaponScript = newWeapon.GetComponent<BaseWeapon>();
    }

    public void OnPrimaryAttack(InputAction.CallbackContext context) 
    {
        weaponScript.PrimaryAttack(context);
    }

    public void OnAlternateAttack(InputAction.CallbackContext context) 
    { 
        weaponScript.AlternateAttack(context);
    }
}
