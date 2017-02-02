using CartManagerApplication.Solutions.level1.src;
using Newtonsoft.Json;
using System.IO;

namespace CartManagerApplication.Solutions.level1
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
            var path = Path.Combine(Directory.GetCurrentDirectory(), string.Format("Exercises/Backend/{0}/data.json", this.level));

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<JsonInputObject>(json);
            }
        }

        public void WriteJSON()
        {
            System.IO.Directory.CreateDirectory(string.Format("results/{0}", this.level));
            JsonSerializer serializer = new JsonSerializer();
            var path = Path.Combine(Directory.GetCurrentDirectory(), string.Format("results/{0}/output.json", this.level));

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this.output);
            }

        }

        public JsonOutputObject LoadExpectedOutput()
        {
            JsonOutputObject expectedOutput = new JsonOutputObject();
            var path = Path.Combine(Directory.GetCurrentDirectory(), string.Format("Exercises/Backend/{0}/output.json", this.level));

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
            var path = Path.Combine(Directory.GetCurrentDirectory(), string.Format("results/{0}/output.json", this.level));

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                expectedOutput = JsonConvert.DeserializeObject<JsonOutputObject>(json);
            }
            return expectedOutput;
        }

    }
}
