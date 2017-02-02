
using CartManagerApplication.Solutions.level2.src;
using Newtonsoft.Json;
using System.IO;

namespace CartManagerApplication.Solutions.level2
{
    public class JSONManager
    {
        private JsonInputObject input;
        private string level;

        public JSONManager(string level)
        {
            this.level = level;
        }

        public JsonInputObject LoadJSON()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(),string.Format("Exercises/Backend/{0}/data.json",this.level));

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                input = JsonConvert.DeserializeObject<JsonInputObject>(json);
            }
            return input;
        }

        public void WriteJSON(JsonOutputObject output)
        {
            System.IO.Directory.CreateDirectory(string.Format("results/{0}", this.level));
            JsonSerializer serializer = new JsonSerializer();
            var path = Path.Combine(Directory.GetCurrentDirectory(), string.Format("results/{0}/output.json", this.level));

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, output);
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
