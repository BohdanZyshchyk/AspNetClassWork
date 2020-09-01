using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class UserRolesViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public List<RolesViewModel> Roles{ get; set; }
        public UserRolesViewModel(List<UserViewModel> users, List<RolesViewModel> roles)
        {
            Users = users;
            Roles = roles;
        }
    }
}