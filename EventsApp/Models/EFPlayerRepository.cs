using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventsApp.Models
{
    public class EFPlayerRepository:IPlayerRepository
    {
        private EventsAppDBContext context;

        public EFPlayerRepository(EventsAppDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Player> Players => context.Players;
                            
        public void AddPlayer(string playerName,string playerLongName, long events) 
        { 
        Player player=new Player{PlayerName=playerName,PlayerLongName=playerLongName,EventId=events};
        context.Players.Add(player);
        context.SaveChanges();
        }         

       
    }
}
