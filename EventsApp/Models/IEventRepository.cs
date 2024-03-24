namespace EventsApp.Models
{
    public interface IEventRepository
    {
        IQueryable<Event> Events { get; }
        }
    }