using System;
using System.Collections;
using System.Collections.Generic;
using src.Model.ModelFramework.Targetables;
using src.Model.ModelFramework.Targetables.Damageable;
using src.Model.ModelFramework.Targetables.Shieldable;
using src.View.Rooms;
using UnityEngine;

public class BaseShip : ITargetable, IDamageable, IShieldHealable, IShieldDamagable, IHealable
{
    Guid selfID;
    Guid teamID;
    private int maxHP;
    private int currentHP;

    private int maxShield;
    private int currentShield;

    private int crewCount;     //current unallocated crew
    private int maxCrew; //Overall crew the ship has

    List<BaseRoom> roomList;

    public Boolean allocateCrew(int crewAllocated)
    {
        if(crewCount - crewAllocated >= 0)
        {
            crewCount -= crewAllocated;
            return true;
        }
        else
        {
            return false;
        }
    }

    public Boolean freeCrew(int crewFreed)
    {
        if (crewCount + crewFreed <= maxCrew)
        {
            crewCount += crewFreed;
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public int getMaxCrew()
    {
        return maxCrew;
    }

    public int getCrewCount()
    {
        return crewCount;
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

}
