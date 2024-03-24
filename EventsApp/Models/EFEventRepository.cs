namespace EventsApp.Models
{
    public class EFEventRepository:IEventRepository
    {
        private EventsAppDBContext context;

        public EFEventRepository(EventsAppDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Event> Events => context.Events;
    }
}
