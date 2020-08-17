using QuestRoom.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuestRoom.DataAccess.Initializer
{
    public class QuestRoomsInitializer : DropCreateDatabaseAlways<QuestRoomModel>
    {
        protected override void Seed(QuestRoomModel context)
        {
            List<QRoom> rooms = new List<QRoom> {
            new QRoom {Name="DIAMOND HEIST",Description="Being a person of (devious) action, you’ve pulled together a team of the best thieves around. You have a plan, and it’s time to pull off the biggest diamond heist in history in this heist escape room! Working with your team of 2 - 10 crooks, you have 60 heart-pumping minutes to get the diamond before the police arrive.",
            Address="St. Louis, 63102", Company="Escape Room St. Louis",
            Age=18,
            Difficulty=5,
            Horror=5,
            NumbPlayers=4,
            Phone="314-690-3356",
            TimeMinutes=60,
            Rating=3},
            new QRoom {Name="CURSED CASTLE",Description="You all are loyal knights of a benevolent kingdom returning from a faraway journey. As you approach your town, you see dark, ominous clouds. You arrive to find your castle eerily dark, quiet and sealed shut. Local villagers have told you that no one has been seen going in or out for days. Recognizing the classic signs of an evil curse, you decide it is your duty to do whatever you can to lift it, but you won’t be able to survive inside the curse for more than an hour so you must move quickly. If you can lift the curse, you will save your kingdom, BUT if your kingdom will be plunged into darkness and you will be sealed inside the castle forever. You have 60 minutes – Good luck!",
            Address="New York, 546565", Company="Escape Room New York",
            Age=21,
            Difficulty=4,
            Horror=2,
            NumbPlayers=2,
            Phone="314-690-76878",
            TimeMinutes=60,
            Rating=5},
            new QRoom {Name="SECRET SOCIETY",Description="You and your friends have been researching an ancient secret society, only to make the startling discovery that they’ve been researching YOU! Soon after making your discovery, you find yourself kidnapped and locked in a room deep within the walls of a medieval castle in this suspenseful escape room. Your only chance for escape is to complete the Initiation Trial successfully. Work together with your group of 2 - 8 initiates to find the clues and solve the puzzles. You’ve got 60 minutes to escape the room.This challenging escape room is full of twists and turns to keep your adrenaline pumping the entire time. Escape and everyone gains membership in the secret society. Can’t complete the Initiation Trial? Face elimination.",
            Address="Rivme, Soborna 555 ", Company="Escape Room Rivme",
            Age=10,
            Difficulty=1,
            Horror=1,
            NumbPlayers=4,
            Phone="12312378231",
            TimeMinutes=30,
            Rating=4},
            };

            var images = new List<Image> {
                new Image{ ImageUrl="https://krd.mir-kvestov.ru/uploads/quests/6878/large/questroom_proklyatie_sary_photo1.jpg?1544771030", QRoom=rooms.FirstOrDefault(x=> x.Name=="SECRET SOCIETY") },
                new Image{ ImageUrl="https://escaperoommap.lv/media/rooms/img_9592-2_R2fCrf1.jpg.500x372_q85_crop-smart_upscale.jpg", QRoom=rooms.FirstOrDefault(x=> x.Name=="SECRET SOCIETY")},
                new Image{ ImageUrl="https://escaperoommap.lv/media/rooms/laba.jpg", QRoom=rooms.FirstOrDefault(x=> x.Name=="SECRET SOCIETY")},
                new Image{ ImageUrl="https://i.redd.it/ew2afcl3sdm31.png", QRoom=rooms.FirstOrDefault(x=> x.Name=="CURSED CASTLE")},
                new Image{ ImageUrl="https://questroom.com.ua/dist/pict_rooms/zxRCSlg6.jpg", QRoom=rooms.FirstOrDefault(x=> x.Name=="CURSED CASTLE")},
                new Image{ ImageUrl="https://questroom.com.ua/dist/pict_rooms/TrYR9duS.jpg", QRoom=rooms.FirstOrDefault(x=> x.Name=="DIAMOND HEIST")}

            };
            context.QRooms.AddRange(rooms);
            context.Images.AddRange(images);
            base.Seed(context);
        }
    }
}