using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.UI.Models
{
    public class CartItemViewModel
    {
        public GameViewModel Game { get; set; }
        public int Quantity { get; set; }
    }
}