using CartManagerApplication.Solutions.level1.src;

namespace CartManagerApplication.Solutions.level1
{
    public class Solution1
    {
        JSONManager manager;

        public JsonInputObject input { get; set; }
        public JsonOutputObject output { get; set; }

        public Solution1()
        {
            manager = new JSONManager();
            input = manager.LoadJSON("level1");
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

                output.carts.Add(
                    new CartItemOutput
                    {
                        id = cart.id,
                        total = total
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
