using System;

namespace src.Model.ModelFramework.ActionFramework
{
    public abstract class ActionTurnModel
    {

        //Shared by all actions
        public readonly int RoundNumber;

        protected ActionTurnModel(int roundNumber)
        {
            RoundNumber = roundNumber;
        }
        
        //health related
        public int? HealAmount = null;
        public int? DecreaseMaxHealthAmount = null;
        public int? IncreaseMaxHealthAmount = null;
        
        //Weapon related
        public int? DamagePerShot = null;
        public int? DamagePerShotIgnoreShield = null;
        public int? ShotsFired = null;
        public int? ChanceToHit = null;
        public bool? GuaranteedHit = null;
        public int? ChanceToDisableRoom = null;
        
        //Projectile related
        
        
        //Drone related
        
        
        //Navigation related
        public int? ChanceToDodge = null;
        
        //Shield related
        public int? ShieldCount = null;
        
        //Crew related
        public int? IncreaseTotalCrewCount = null;
        public int? ChanceToIncreaseTotalCrewCount = null;
        public int? DecreasedTotalCrewCount = null;
        public int? ChanceToDecreasedTotalCrewCount = null;
        
        //Research related
        
        
        //Scavenging related
    }
}
