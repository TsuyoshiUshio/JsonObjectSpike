using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;



namespace JsonParseSample
{
    class Program
    {
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
           }
    }
}
