namespace EventsApp.Models
{
    public interface IPlayerRepository
    {
        IQueryable<Player> Players { get; }
        public void AddPlayer(string playerName, string playerLongName, long events);
    }
}
