using CartManagerApplication.Solutions.level1.src;

namespace CartManagerApplication.Solutions.level1
{
    class Solution1
    {
        public static void run()
        {
            JSONManager manager = new JSONManager();
            JsonInputObject input = manager.LoadJSON("level1");

            JsonOutputObject output = new JsonOutputObject();

            foreach (Cart cart in input.carts)
            {
                int total = 0;
                foreach (CartItem item in cart.items)
                {
                    total += input.getArticleById(item.article_id).price * item.quantity;
                }

                output.carts.Add(
                    new
                    {
                        id = cart.id,
                        total = total
                    }
                );
            }

            manager.WriteJSON(output);
        }

    }
}
