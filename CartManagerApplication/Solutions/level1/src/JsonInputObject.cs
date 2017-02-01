using System.Collections.Generic;

namespace CartManagerApplication.Solutions.level1.src
{
    public class JsonInputObject
    {
        public List<Article> articles { get; set; }
        public List<Cart> carts { get; set; }

        public Article getArticleById (int id)
        {
            return this.articles.Find(x => x.id == id);
        }
    }
}
