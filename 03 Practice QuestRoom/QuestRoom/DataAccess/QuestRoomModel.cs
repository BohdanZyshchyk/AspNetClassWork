namespace QuestRoom.DataAccess
{
    using QuestRoom.DataAccess.Initializer;
    using QuestRoom.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class QuestRoomModel : DbContext
    {
        public DbSet<Image> Images{ get; set; }
        public DbSet<QRoom> QRooms { get; set; }
        public QuestRoomModel()
            : base("name=QuestRoomConnectionString")
        {
            Database.SetInitializer(new QuestRoomsInitializer());
        }

       
    }

   
}