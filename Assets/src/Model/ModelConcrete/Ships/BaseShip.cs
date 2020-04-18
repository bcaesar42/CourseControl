using System;
using System.Collections;
using System.Collections.Generic;
using src.Model.ModelFramework.Targetables;
using src.Model.ModelFramework.Targetables.Damageable;
using src.Model.ModelFramework.Targetables.Shieldable;
using src.View.Rooms;
using UnityEngine;

<<<<<<< HEAD
public class BaseShip : ITargetable, IDamageable, IShieldHealable, IShieldDamagable, IHealable
=======
public class BaseShip : MonoBehaviour, ITargetable, IDamageable, IShieldable, IHealable
>>>>>>> ShipBranch
{
    Guid selfID;
    Guid teamID;
    private int maxHP;
    private int currentHP;

    private int maxShield;
    private int currentShield;

    private int crewCount;     //current unallocated crew
    private int maxCrew; //Overall crew the ship has

<<<<<<< HEAD
    List<BaseRoom> roomList;

    public int allocateCrew()
    {
        crewCount--;
        return crewCount;
    }

    public int freeCrew()
    {
        crewCount++;
        return crewCount;
    }
    
=======

    List<BaseRoom> roomList;

>>>>>>> ShipBranch
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

<<<<<<< HEAD
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
=======
    public void Damage(int damageCount)
    {
        currentHP -= damageCount;
    }

    public void DamageShield(int damageCount)
    {
        currentShield -= damageCount;
>>>>>>> ShipBranch
    }

    public Guid GetSelfId()
    {
        return selfID;
    }

    public Guid GetTeamId()
    {
        return teamID;
    }

<<<<<<< HEAD
    public int Heal(int healCount)
    {
        currentHP += healCount;
        if (currentShield > maxShield) { currentShield = maxShield; }
        return currentHP;
=======
    public void Heal(int healCount)
    {
        currentHP += healCount;
>>>>>>> ShipBranch
    }

    public int MaxShieldCount()
    {
        return maxShield;
    }

    public int TotalHP()
    {
        return maxHP;
    }

<<<<<<< HEAD
=======
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
>>>>>>> ShipBranch
}
