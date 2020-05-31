using System;
using System.Collections;
using System.Collections.Generic;
using src.Controller.ActionModelManager;
using src.Model.ModelFramework.ActionFramework;
using src.Model.ModelFramework.ShipFramework;
using src.Model.ModelFramework.TargetableFramework;
using src.Model.ModelFramework.TargetableFramework.Damageable;
using src.Model.ModelFramework.TargetableFramework.Shieldable;
using src.Model.ModelFramework.Targetables;
using src.Model.ModelFramework.Targetables.Crewable;
using src.View.Rooms;
using UnityEngine;

public class BaseShip : ITargetable, IDamageable, IShieldable, IHealable, ICrewable
{
    Guid selfID;
    Guid teamID;
    private int maxHP;
    private int currentHP;

    private int maxShield;
    private int currentShield;

    private int maxCrew; //Overall crew the ship has
    private int currentCrew; //current unallocated crew

    private GameAction[] gameActions;

    List<BaseRoom> roomList;

    public BaseShip(ShipModel model)
    {
        maxHP = model.InitialMaxHealth;
        currentHP = model.InitialMaxHealth;
        
        maxCrew = model.InitialCrewCount;
        currentCrew = model.InitialCrewCount;

        selfID = Guid.NewGuid();

        gameActions = new GameAction[7];
        
        foreach (var gameAction in gameActions)
        {
            //TODO foreach actionModel in model get an instance of its action type e.g. Weapon or Heal and then assign it to the index in gameAction
        }

        //gameAction1 = ActionManager.instance.GetActionModel(model.GameActionId1, 1);
    }

    public BaseShip(ShipModel model, Guid teamId) : this(model)
    {
        this.teamID = teamId;
    }

    public bool AllocateCrew(int crewToAllocate)
    {
        if (currentCrew - crewToAllocate >= 0)
        {
            currentCrew -= crewToAllocate;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool FreeCrew(int crewToFree)
    {
        if (currentCrew + crewToFree <= maxCrew)
        {
            currentCrew += crewToFree;
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
        return currentCrew;
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

        int resShieldState = currentShield;

        if (currentShield < 0) currentShield = 0;
        return resShieldState;
    }

    public void ActivateShield(int shieldCount)
    {
        currentShield = shieldCount;
        
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
