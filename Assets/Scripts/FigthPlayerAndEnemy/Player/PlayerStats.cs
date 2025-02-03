using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    /** later all these variables will be not SerializeField 
     * and there will be method wich set all variables, from registery 
     * (just text file, where we will save player stats in json format)
    **/

    // nikakoj inkopsulacii, podumatj mozet ispavitj mozno.
    [SerializeField] public double MaxHealth;
    [SerializeField] public double DemageMelee;
    [SerializeField] public LongRangeWepon LongRangeWepon;
    [SerializeField] public bool IsPlayerImmortal = false;

    // health regeneration variables.
    public float TimeToStartRegeneration = 5f, RegenerationInterval = 1f; // TimeToStartRegeneration is the time in seconds that the player must hold out and not be wounded in order to start recover
    public double XpOfHealthRegenerationPerInterval = 1;
}
