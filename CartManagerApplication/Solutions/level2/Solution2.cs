using CartManagerApplication.Solutions.level2.src;

namespace CartManagerApplication.Solutions.level2
{
    public class Solution2
    {
        public JSONManager manager;

        public JsonInputObject input { get; set; }
        public JsonOutputObject output { get; set; }

        public Solution2()
        {
            manager = new JSONManager("level2");
            input = manager.LoadJSON();
            output = new JsonOutputObject();
        }

        public void run()
        {
            foreach (Cart cart in input.carts)
            {
                int total = 0;
                foreach (CartItem item in cart.items)
                {
                    total += input.getArticleById(item.article_id).price * item.quantity;
                }
                cart.sub_total = total;

                int delivery_fee = 0;
                foreach (DeliveryFee fee in input.delivery_fees)
                {
                    if (total >= fee.eligible_transaction_volume.min_price 
                        && (total < fee.eligible_transaction_volume.max_price || fee.eligible_transaction_volume.max_price == null))
                    {
                        delivery_fee = fee.price;
                    }
                }
                cart.delivery_fee = delivery_fee;

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
