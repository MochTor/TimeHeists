using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName = "Character/Stats", order = 1)]
public class PlayerStatsSO : ScriptableObject
{

    #region Fields
    public bool setManually = false;
    public bool saveDataOnClose = false;

    public int maxHealth = 0;
    public int currentHealth = 0;

    public int maxShield = 0;
    public int currentShield = 0;

    public int baseDamage = 0;
    public int currentDamage = 0;

    public int characterLevel = 1;
    #endregion

    #region Methods
    public void IncreaseHealth(int increaseValue) {
        if ((currentHealth + increaseValue) > maxHealth) {
            currentHealth = maxHealth;
        } else {
            currentHealth += increaseValue;
        }
    }

    public void DecreaseHealth(int decreaseValue) {
        if ((currentHealth - decreaseValue) <= 0) {
            //death method
        } else {
            currentHealth -= decreaseValue;
        }
    }

    public void IncreaseShield(int increaseValue)
    {
        if ((currentShield + increaseValue) > maxShield)
        {
            currentShield = maxShield;
        }
        else
        {
            currentShield += increaseValue;
        }
    }

    public void DecreaseShield(int decreaseValue)
    {
        if ((currentShield - decreaseValue) <= 0)
        {
            currentShield = 0;
        }
        else
        {
            currentShield -= decreaseValue;
        }
    }



    #endregion
}
