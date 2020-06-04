using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using src.Controller.ActionModelManager;
using src.Controller.TargetManager;
using src.Model.ModelConcrete.GameActions;
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

    public List<BaseRoom> roomList = new List<BaseRoom>();



    public BaseShip(ShipModel model)
    {
        SceneManager sceneManager = GameObject.Find("SceneManager").transform.GetComponent<SceneManager>();
        TargetManager targetManager = sceneManager.targetManager;
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
        //Hardcoding for now

        //gameActions[0] = new Weapon(sceneManager.actionManager.GetActionModel(new Guid("49b68f9f-45b7-4444-993d-0441b8cb14d9"), 0).FirstOrDefault(), new Guid("49b68f9f-45b7-4444-993d-0441b8cb14d9"), new Guid("49b95jbv-8dac-4204-997d-0441b8c87239"), new Guid("49b95jbv-8dac-4204-993d-0441b8cb14d9"));

    }

    public BaseShip(ShipModel model, Guid teamId) : this(model)
    {
        this.teamID = teamId;
    }

    public void addRoom(BaseRoom b)
    {
        roomList.Add(b);
    }

    public bool AllocateCrew(int crewToAllocate, int room)
    {
        if (currentCrew - crewToAllocate >= 0)
        {
            currentCrew -= crewToAllocate;
            roomList[room].AddCrew();
            return true;
        }
        else
        {
            return false;
        }
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

    public bool FreeCrew(int crewToFree, int room)
    {
        if (currentCrew + crewToFree <= maxCrew)
        {
            currentCrew += crewToFree;
            roomList[room].RemoveCrew();
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
