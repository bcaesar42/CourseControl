namespace src.Model.ModelFramework.ActionFramework
{
    public class ActionTime
    {
        private int _activationTime;

        private int _completionTime;

        private int _cooldownTime;

        public ActionTime(int activationTime, int completionTime, int cooldownTime)
        {
            ActivationTime = activationTime;
            CompletionTime = completionTime;
            CooldownTime = cooldownTime;
        }

        public int ActivationTime
        {
            get => _activationTime;
            private set
            {
                if (value < 0)
                    _activationTime = 0;
                else
                    _activationTime = value;
            }
        }

        public int CompletionTime
        {
            get => _completionTime;
            private set
            {
                if (value < 1)
                    _completionTime = 1;
                else
                    _completionTime = value;
            }
        }

        public int CooldownTime
        {
            get => _cooldownTime;
            private set
            {
                if (value < 0)
                    _cooldownTime = 0;
                else
                    _cooldownTime = value;
            }
        }
    }
}