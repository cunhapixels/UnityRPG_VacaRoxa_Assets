namespace Interfaces
{
    public interface ICurable<T>
    {
        void ApplyCure(T cureTaken);
        bool CheckHealthIsFull();
    }
}