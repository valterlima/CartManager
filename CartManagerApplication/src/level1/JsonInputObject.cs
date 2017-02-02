using System.Collections.Generic;

namespace CartManagerApplication.src.level1
{
    public class JsonInputObject
    {
        public List<Article> articles { get; set; }
        public List<Cart> carts { get; set; }

        public Article getArticleById(int id)
        {
            return this.articles.Find(x => x.id == id);
        }
    }
    public class Cart
    {
        public int id { get; set; }
        public List<CartItem> items { get; set; }
    }

    public class CartItem
    {
        public int article_id { get; set; }
        public int quantity { get; set; }
    }
    public class Article
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }
}
