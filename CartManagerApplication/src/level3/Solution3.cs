using Newtonsoft.Json;
using System;
using System.IO;

namespace CartManagerApplication.src.level3
{
    public class Solution3
    {
        public string level = "level3";

        public JsonInputObject input { get; set; }
        public JsonOutputObject output { get; set; }

        public Solution3()
        {
            this.input = this.LoadJSON();
            this.output = new JsonOutputObject();
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
            string path = Path.Combine(s, "Exercises", "Backend", this.level, "output.json");

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
