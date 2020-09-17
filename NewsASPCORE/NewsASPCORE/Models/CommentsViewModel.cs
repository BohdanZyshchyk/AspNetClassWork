using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsASPCORE.Models
{
    public class CommentsViewModel
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string CommentAuthor { get; set; }
    }
}
