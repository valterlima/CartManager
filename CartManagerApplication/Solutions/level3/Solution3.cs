using CartManagerApplication.Solutions.level3.src;

namespace CartManagerApplication.Solutions.level3
{
    public class Solution3
    {
        public JSONManager manager;

        public JsonInputObject input { get; set; }
        public JsonOutputObject output { get; set; }

        public Solution3()
        {
            manager = new JSONManager("level3");
            input = manager.LoadJSON();
            output = new JsonOutputObject();
        }

        public void run()
        {
            foreach (Cart cart in input.carts)
            {
                cart.articles = input.articles;
                cart.delivery_fees = input.delivery_fees;
                cart.discounts = input.discounts;

                int total = cart.getItemTotals();

                cart.sub_total = total;

                cart.delivery_fee = cart.getDeliveryFee(cart.sub_total);
                
                output.carts.Add(
                    new CartItemOutput
                    {
                        id = cart.id,
                        total = cart.getTotals()
                    }
                );
            }
        }

        public void save()
        {
            manager.WriteJSON(output);
        }

    }
}
