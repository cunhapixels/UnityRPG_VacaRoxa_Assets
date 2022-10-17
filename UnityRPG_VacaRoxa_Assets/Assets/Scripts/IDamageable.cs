namespace Interfaces
{
    public interface IDamageable<T>
    {
        void ApplyDamage(T damageTaken);
    }
}