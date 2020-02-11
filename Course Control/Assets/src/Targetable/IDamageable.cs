namespace src.Targetable
{
    public interface IDamageable
    {
        int TotalHp();
        int CurrentHp();
        int SetHp(int newHp);
    }
}