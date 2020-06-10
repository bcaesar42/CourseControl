using System;
using System.Collections.Generic;
using src.Controller;
using src.Controller.TargetManager;
using src.Model.ModelFramework.ShipFramework;
using src.Model.ModelFramework.TargetableFramework;
using src.Model.ModelFramework.TargetableFramework.Damageable;
using src.Model.ModelFramework.TargetableFramework.Shieldable;
using src.Model.ModelFramework.Targetables.Crewable;
using src.View.Rooms;
using src.View.StatusUi.HealthBar;
using src.View.StatusUi.ShieldIndicator;
using UnityEngine;

namespace src.Model.ModelConcrete.Ships
{
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

        private int evasion; //0 to 100 int to represent % chance to evade certain types of attacks

        public List<BaseRoom> roomList = new List<BaseRoom>();
        public TargetManager targetManager;
        PlayerLog eventLog = GameObject.Find("EventLog").GetComponent<PlayerLog>();

        public BaseShip(ShipModel model)
        {
            SceneManager sceneManager = GameObject.Find("SceneManager").transform.GetComponent<SceneManager>();
            targetManager = sceneManager.targetManager;
            maxHP = model.InitialMaxHealth;
            currentHP = model.InitialMaxHealth;

            maxCrew = model.InitialCrewCount;
            currentCrew = model.InitialCrewCount;

            maxShield = model.MaxShield;

            selfID = Guid.NewGuid();
            evasion = 0;
        }

        public void newTurn()
        {
            foreach (BaseRoom b in roomList)
            {
                b.newTurn();
            }
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

        public void setEvadeChance(int e)
        {
            eventLog.AddEvent("Evasion Rate set to " + e + " from " + evasion);
            evasion = e;
        }

        public int getEvadeChance()
        {
            return evasion;
        }

        public bool didEvade()
        {
            System.Random rng = new System.Random();
            if (rng.Next(1, 100) < evasion)
                return true;
            else
                return false;
        }

        public bool FreeCrew(int crewToFree, int room)
        {
            if (currentCrew + crewToFree <= maxCrew && (roomList[room].GetCrewCount() > 0))
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

            eventLog.AddEvent("Adding " + amountToAdd + " crew to ship. Now at " + maxCrew);

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

            eventLog.AddEvent("Took " + damageCount + " damage to ship. Now at " + (currentHP - damageCount));

            currentHP -= damageCount;
            if (currentHP < 0) currentHP = 0;
            GameObject.Find("HealthBar").GetComponent<HealthBar>().StateChanged(currentHP, maxHP);
            return currentHP;
        }

        public int DamageShield(int damageCount)
        {

            eventLog.AddEvent("Shields hit! " + " Now at " + (currentShield - damageCount));

            currentShield -= damageCount;

            int resShieldState = currentShield;

            if (currentShield < 0) currentShield = 0;

            GameObject.Find("ShieldIndicatorManager").GetComponent<ShieldIndicatorManager>()
                .StateChanged(currentShield, maxShield);

            return resShieldState;
        }

    public void ActivateShield(int shieldCount)
        { 

        currentShield += shieldCount;
        if (currentShield > maxShield)
        {
            currentShield = maxShield;
        }

        eventLog.AddEvent("Raised Shields! " + " Now at " + (currentShield));

        GameObject.Find("ShieldIndicatorManager").GetComponent<ShieldIndicatorManager>().StateChanged(currentShield, maxShield);
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
            if (currentHP > maxHP) currentHP = maxHP;

            eventLog.AddEvent("Hull repaired for " + healCount + ". Now at " + (currentHP));

            GameObject.Find("HealthBar").GetComponent<HealthBar>().StateChanged(currentHP, maxHP);
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
}
