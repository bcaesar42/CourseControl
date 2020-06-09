using System;
using System.Collections;
using System.Collections.Generic;
using src.Model.ModelFramework.TargetableFramework;
using src.Model.ModelFramework.TargetableFramework.Damageable;
using src.Model.ModelFramework.TargetableFramework.Shieldable;
using UnityEngine;

public class targetShip : ITargetable, IDamageable, IShieldable
{

    Guid selfID = Guid.NewGuid();
    int hp = 30;
    int maxHP = 30;
    int maxShields = 4;
    int currentShields = 4;

    public void ActivateShield(int shieldCount)
    {
        currentShields += shieldCount;
        if (shieldCount > maxShields)
            shieldCount = maxShields;
    }

    public int CurrentHP()
    {
        return hp;
    }

    public int CurrentShieldCount()
    {
        return currentShields;
    }

    public int Damage(int damageCount)
    {
        hp -= damageCount;
        if (hp < 0)
            hp = 0;

        return hp;
    }

    public int DamageShield(int damageCount)
    {
        currentShields -= damageCount;

        if (currentShields < 0)
            currentShields = 0;

        return currentShields;
    }

    public int DecreaseMaxHealth(int amountToRemove)
    {
        maxHP -= amountToRemove;
        if (maxHP < 0)
            maxHP = 0;

        return maxHP;
    }

    public Guid GetSelfId()
    {
        return selfID;
    }

    public Guid GetTeamId()
    {
        throw new NotImplementedException();
    }

    public int IncreaseMaxHealth(int amountToAdd)
    {
        maxHP += amountToAdd;
        return maxHP;
    }

    public int MaxShieldCount()
    {
        return maxShields;
    }

    public int TotalHP()
    {
        return maxHP;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
