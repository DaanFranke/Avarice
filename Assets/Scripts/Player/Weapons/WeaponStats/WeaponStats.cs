using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponStats", menuName = "WeaponStats")]
public class WeaponStats : ScriptableObject
{
    //Damage
    public float primaryDamage;
    public float alternateDamage;

    //Head strike modifier
    public float primaryHeadstrike;
    public float alternateHeadstrike;

    //Stamina costs
    public float primaryStaminaCost;
    public float alternateStaminaCost;
    public float specialStaminaCost;

}
