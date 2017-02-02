using Newtonsoft.Json;
using System;
using System.IO;

namespace CartManagerApplication.src.level1
{
    public class Solution1
    {
        public string level = "level1";

        public JsonInputObject input { get; set; }
        public JsonOutputObject output { get; set; }

        public Solution1()
        {
            this.input = this.LoadJSON();
            this.output = new JsonOutputObject();
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
            this.WriteJSON();
        }

        public JsonInputObject LoadJSON()
        {
            string s = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(s, "Exercises/Backend/", this.level, "data.json");

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<JsonInputObject>(json);
            }
        }

        public void WriteJSON()
        {
            JsonSerializer serializer = new JsonSerializer();

            string s = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(s, "results", this.level);
            System.IO.Directory.CreateDirectory(path);
            path = Path.Combine(path, "output.json");

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this.output);
            }

        }

        public JsonOutputObject LoadExpectedOutput()
        {
            JsonOutputObject expectedOutput = new JsonOutputObject();
            string s = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(s, "Exercises","Backend", this.level, "output.json");

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                expectedOutput = JsonConvert.DeserializeObject<JsonOutputObject>(json);
            }
            return expectedOutput;
        }

        public JsonOutputObject LoadActualOutput()
        {
            JsonOutputObject expectedOutput = new JsonOutputObject();
            string s = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(s, "results", this.level, "output.json");

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                expectedOutput = JsonConvert.DeserializeObject<JsonOutputObject>(json);
            }
            return expectedOutput;
        }

    }
}
