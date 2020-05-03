using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace BQ_QuestsReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BQ_QuestsReader");
            var json = JObject.Parse(File.ReadAllText("QuestProgress.json"));
            foreach (var quest in json["questProgress"])
            {
                var completed = quest["completed"].Count(user => user.Value<bool>("claimed"));
                var questid = quest.Value<int>("questID");
                Console.WriteLine("QuestID: " + questid + " completed: " + completed);
            }

            Console.ReadKey();
        }
    }
}
