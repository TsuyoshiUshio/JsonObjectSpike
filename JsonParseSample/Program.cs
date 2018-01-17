using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;



namespace JsonParseSample
{
    class Program
    {
        // reference
        // https://www.newtonsoft.com/json/help/html/linqtojson.htm
        // https://netweblog.wordpress.com/2016/10/24/json-net-newtonsoft-json-usage/
        static void Main(string[] args)
        {

            Console.WriteLine("Serialize------");
            var list = new List<JObject>();
            for(var i = 0; i < 10; i++)
            {
                list.Add(JObject.Parse("{" + $"'counter-{i.ToString("00")}': '{Guid.NewGuid()}'" + "}"));
            }
            var serialized = JsonConvert.SerializeObject(list);
            Console.WriteLine(serialized);
            Console.ReadLine();

            Console.WriteLine("DeSerialize-------");

            var restored = JsonConvert.DeserializeObject<List<JObject>>(serialized);

            foreach (var obj in restored)
            {
                foreach (var value in obj.Values())
                {
                    Console.WriteLine(value.Value<string>());
                }
            }

            Console.ReadLine();

            Console.WriteLine("Simple Serialize------");
            var result = JsonConvert.SerializeObject(new JObject { ["instanceId"] = "abc" });
            Console.WriteLine(result);
            Console.WriteLine("Simple Deserialize -----");
            var newresult = JsonConvert.DeserializeObject<JObject>(result);
            Console.WriteLine(newresult["instanceId"]);
            Console.ReadLine();
           }
    }
}
