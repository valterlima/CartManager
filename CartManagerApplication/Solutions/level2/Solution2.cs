using CartManagerApplication.Solutions.level2.src;
using Newtonsoft.Json;
using System.IO;

namespace CartManagerApplication.Solutions.level2
{
    public class Solution2
    {
        public string level = "level2";

        public JsonInputObject input { get; set; }
        public JsonOutputObject output { get; set; }

        public Solution2()
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
