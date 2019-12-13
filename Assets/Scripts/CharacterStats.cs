using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public PlayerStatsSO characterDefinition;

    // Use this for initialization
    void Start()
    {
        if (!characterDefinition.setManually)
        {
            characterDefinition.maxHealth = 200;
            characterDefinition.currentHealth = characterDefinition.maxHealth;
            characterDefinition.maxShield = 10;
            characterDefinition.baseDamage = 30;
            characterDefinition.currentDamage = characterDefinition.baseDamage;
            characterDefinition.characterLevel = 1;
        }
    }

    #region Increasers

    public void IncreaseHealth(int increaseValue)
    {
        characterDefinition.IncreaseHealth(increaseValue);
    }

    public void IncreaseShield(int increaseValue)
    {
        characterDefinition.IncreaseShield(increaseValue);
    }

    #endregion

    #region Decreasers

    public void DecreaseHealth(int decreaseValue)
    {
        characterDefinition.DecreaseHealth(decreaseValue);
    }

    public void DecreaseShield(int decreaseValue)
    {
        characterDefinition.DecreaseShield(decreaseValue);
    }
    #endregion

    #region Reporters

    public int GetHealth() {
        return characterDefinition.currentHealth;
    }

    public int GetMaxHealth() {
        return characterDefinition.maxHealth;
    }

    public int GetShield()
    {
        return characterDefinition.currentShield;
    }

    #endregion
}
