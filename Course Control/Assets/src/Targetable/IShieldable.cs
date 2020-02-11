namespace src.Targetable
{
    public interface IShieldable
    {
        int maxShieldCount();
        int currentShieldCount();
        int setShieldCount(int newShieldCount);
    }
}