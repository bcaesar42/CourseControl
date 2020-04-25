namespace src.Model.ModelFramework.ActionFramework
{
    public abstract class ActionTurnModel
    {
        public const int UNASSIGNED_FIELD = -78079921;

        //Shared by all actions
        public readonly int RoundNumber;

        protected ActionTurnModel(int roundNumber)
        {
            RoundNumber = roundNumber;
        }
        
        //health related
        public int HealAmount = UNASSIGNED_FIELD;
        public int DecreaseMaxHealthAmount = UNASSIGNED_FIELD;
        public int IncreaseMaxHealthAmount = UNASSIGNED_FIELD;
        
        //Weapon related
        public int DamagePerShot = UNASSIGNED_FIELD;
        public int DamagePerShotIgnoreShield = UNASSIGNED_FIELD;
        public int ShotsFired = UNASSIGNED_FIELD;
        public int ChanceToHit = UNASSIGNED_FIELD;
        public bool GuaranteedHit = false;
        public int ChanceToDisableRoom = UNASSIGNED_FIELD;
        
        //Projectile related
        
        
        //Drone related
        
        
        //Navigation related
        public int ChanceToDodge = UNASSIGNED_FIELD;
        
        //Shield related
        public int ShieldCount = UNASSIGNED_FIELD;
        
        //Crew related
        public int IncreaseTotalCrewCount = UNASSIGNED_FIELD;
        public int ChanceToIncreaseTotalCrewCount = UNASSIGNED_FIELD;
        public int DecreasedTotalCrewCount = UNASSIGNED_FIELD;
        public int ChanceToDecreasedTotalCrewCount = UNASSIGNED_FIELD;
        
        //Research related
        
        
        //Scavenging related
    }
}
