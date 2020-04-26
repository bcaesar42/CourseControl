using System;
using System.Collections;
using System.Collections.Generic;
using src.Model.ModelFramework.Targetables;
using src.Model.ModelFramework.Targetables.Crewable;
using src.Model.ModelFramework.Targetables.Damageable;
using src.Model.ModelFramework.Targetables.Shieldable;
using src.View.Rooms;
using UnityEngine;

public class BaseShip : ITargetable, IDamageable, IShieldHealable, IShieldDamagable, IHealable, ICrewable
{
    Guid selfID;
    Guid teamID;
    private int maxHP;
    private int currentHP;

    private int maxShield;
    private int currentShield;

    private int crewCount; //current unallocated crew
    private int maxCrew; //Overall crew the ship has

    List<BaseRoom> roomList;

    public bool AllocateCrew(int crewToAllocate)
    {
        if (crewCount - crewToAllocate >= 0)
        {
            crewCount -= crewToAllocate;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool FreeCrew(int crewToFree)
    {
        if (crewCount + crewToFree <= maxCrew)
        {
            crewCount += crewToFree;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int MaxCrewCount()
    {
        return maxCrew;
    }

    public int CurrentCrewCount()
    {
        return crewCount;
    }


    public int IncreaseCrewCount(int amountToAdd)
    {
        if (amountToAdd < 1)
        {
            return maxCrew;
        }

        maxCrew += amountToAdd;
        FreeCrew(amountToAdd);
        return maxCrew;
    }

    public int DecreaseCrewCount(int amountToRemove)
    {
        if (amountToRemove < 1)
        {
            return maxCrew;
        }

        maxCrew -= amountToRemove;
        AllocateCrew(amountToRemove);
        return maxCrew;
    }

    public int CurrentHP()
    {
        return currentHP;
    }

    public int CurrentShieldCount()
    {
        return currentShield;
    }

    public int Damage(int damageCount)
    {
        currentHP -= damageCount;
        if (currentHP < 0) currentHP = 0;
        return currentHP;
    }

    public int DamageShield(int damageCount)
    {
        currentShield -= damageCount;

        if (currentShield < 0) currentShield = 0;
        return currentShield;
    }

    public int HealShield(int healCount)
    {
        currentShield += healCount;
        if (currentShield > maxShield) { currentShield = maxShield; }

        return currentShield;
    }

    public Guid GetSelfId()
    {
        return selfID;
    }

    public Guid GetTeamId()
    {
        return teamID;
    }

    public int Heal(int healCount)
    {
        currentHP += healCount;
        if (currentShield > maxShield) { currentShield = maxShield; }

        return currentHP;
    }

    public int MaxShieldCount()
    {
        return maxShield;
    }

    public int TotalHP()
    {
        return maxHP;
    }


    public int IncreaseMaxHealth(int amountToAdd)
    {
        if (amountToAdd < 1)
        {
            return maxHP;
        }

        maxHP += amountToAdd;
        Heal(amountToAdd);
        return maxHP;
    }

    public int DecreaseMaxHealth(int amountToRemove)
    {
        if (amountToRemove < 1)
        {
            return maxHP;
        }

        maxHP -= amountToRemove;

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        
        return maxHP;
    }
}
