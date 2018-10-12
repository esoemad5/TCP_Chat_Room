
namespace Custom_Interfaces
{
    public interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(int userKey);
        void NotifyObservers();
    }
}