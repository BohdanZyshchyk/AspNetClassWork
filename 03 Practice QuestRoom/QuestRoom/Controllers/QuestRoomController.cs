using QuestRoom.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestRoom.Controllers
{
    public class QuestRoomController : Controller
    {
        // GET: QuestRoom
        QuestRoomModel context = new QuestRoomModel();
        public ActionResult Index()
        {
            var quests = context.QRooms.ToList();
            ViewBag.Quests = quests;
            return View();
        }
    }
}