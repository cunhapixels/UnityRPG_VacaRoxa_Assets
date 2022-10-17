namespace Interfaces
{
    public interface IShieldable<T>
    {
        void RemoveShield(T shieldAmount);
        void AddShield(T shieldAmount);
    }
}