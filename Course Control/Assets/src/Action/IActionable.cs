namespace src.Action
{
    public interface IActionable
    {
        Action GetAction();
        void Do();
    }
}