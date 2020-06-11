using System;
using System.Collections;
using System.Collections.Generic;
using src.Model.ModelFramework.TargetableFramework;
using src.Model.ModelFramework.TargetableFramework.Damageable;
using src.Model.ModelFramework.TargetableFramework.Shieldable;
using src.Controller.TargetManager;
using UnityEngine;
using src.Controller;
using src.Model.ModelConcrete.Ships;
using Random = System.Random;

public class targetShip : ITargetable, IDamageable, IShieldable, IHealable
{

    Guid selfID = Guid.NewGuid();
    int hp = 30;
    int maxHP = 30;
    int maxShields = 4;
    int currentShields = 4;
    PlayerLog eventLog = GameObject.Find("EventLog").GetComponent<PlayerLog>();

    


    public void newRound(BaseShip ship)
    {
        int randEvent;
        Random rng = new Random();
        randEvent = rng.Next(1, 4);


        switch (randEvent)
        {
            case 1:
                if (ship.didEvade())
                    eventLog.AddEvent("Evaded attack by hostile ship! No damage taken.");
                else
                {
                    if (ship.CurrentShieldCount() > 0)
                    {
                        ship.DamageShield(1);
                        eventLog.AddEvent("Taking fire! Shields hit.");
                    }
                    else
                    {
                        ship.Damage(5);
                        eventLog.AddEvent("Taking fire! Impacts on the hull, but she's holding.");
                    }
                }
                break;

            case 2:
                this.ActivateShield(1);
                eventLog.AddEvent("Enemy ship powered their shields! They're at " + this.CurrentShieldCount() + " shields!");
                break;
            case 3:
                this.Heal(2);
                eventLog.AddEvent("Enemy ship repaired their hull! They're at " + this.CurrentHP() + " health!");
                break;
        }

    }

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

    public int Heal(int healCount)
    {
        this.hp += healCount;
        if (this.hp > this.maxHP)
            hp = maxHP;

        return hp;
    }
}
