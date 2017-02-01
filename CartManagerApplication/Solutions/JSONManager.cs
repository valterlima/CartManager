
using CartManagerApplication.Solutions.level1.src;
using Newtonsoft.Json;
using System.IO;

namespace CartManagerApplication.Solutions
{
    class JSONManager
    {
        private JsonInputObject input;

        public JsonInputObject LoadJSON(string level = "level1")
        {
            using (StreamReader r = new StreamReader(
                string.Format(
                    @"C:\Users\Valter\documents\visual studio 2015\Projects\CartManagerApplication\CartManagerApplication\Exercices\Backend\{0}\data.json", 
                    level)))
            {
                string json = r.ReadToEnd();
                input = JsonConvert.DeserializeObject<JsonInputObject>(json);
            }
            return input;
        }

        public void WriteJSON (JsonOutputObject output)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter("level1.output.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, output);
            }

        }
    }
}
