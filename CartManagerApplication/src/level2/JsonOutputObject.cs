using System.Collections.Generic;

namespace CartManagerApplication.src.level2
{
    public class JsonOutputObject
    {
        public List<CartItemOutput> carts = new List<CartItemOutput>();
    }
    public class CartItemOutput
    {
        public int id { get; set; }
        public int total { get; set; }
    }
}
