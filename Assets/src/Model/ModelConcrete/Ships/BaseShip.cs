using System;
using System.Collections;
using System.Collections.Generic;
using src.Model.ModelFramework.Targetables;
using src.Model.ModelFramework.Targetables.Damageable;
using src.Model.ModelFramework.Targetables.Shieldable;
using src.View.Rooms;
using UnityEngine;

public class BaseShip : MonoBehaviour, ITargetable, IDamageable, IShieldable, IHealable
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

    public void Damage(int damageCount)
    {
        currentHP -= damageCount;
    }

    public void DamageShield(int damageCount)
    {
        currentShield -= damageCount;
    }

    public Guid GetSelfId()
    {
        return selfID;
    }

    public Guid GetTeamId()
    {
        return teamID;
    }

    public void Heal(int healCount)
    {
        currentHP += healCount;
    }

    public int MaxShieldCount()
    {
        return maxShield;
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
