namespace src.Action
{
    public class ActionTime
    {
        public ActionTime(int activationTime, int completionTime, int cooldownTime)
        {
            ActivationTime = activationTime;
            CompletionTime = completionTime;
            CooldownTime = cooldownTime;
        }

        private int _activationTime;

        public int ActivationTime
        {
            get => _activationTime;
            private set
            {
                if (value < 0)
                {
                    _activationTime = 0;
                }
                else
                {
                    _activationTime = value;
                }
            }
        }

        private int _completionTime;

        public int CompletionTime
        {
            get => _completionTime;
            private set
            {
                if (value < 1)
                {
                    _completionTime = 1;
                }
                else
                {
                    _completionTime = value;
                }
            }
        }

        private int _cooldownTime;

        public int CooldownTime
        {
            get => _cooldownTime;
            private set
            {
                if (value < 0)
                {
                    _cooldownTime = 0;
                }
                else
                {
                    _cooldownTime = value;
                }
            }
        }
    }
}