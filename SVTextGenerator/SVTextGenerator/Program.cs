using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommandLine;

namespace SVTextGenerator
{

    public class Options
    {
        [Option('i', "input", Required = true, HelpText = "Specify the path of the input file.")]
        public string Input { get; set; }

        [Option('o', "output", Required = true, HelpText = "Specify the output file name.")]
        public string Output { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o =>
            {
                if (o.Input.Length > 0 && o.Output.Length > 0)
                {
                    string path = o.Input; //@"C:\Users\ChristopherTang\Documents\Coding\sv_all.json";
                    List<SVCardReduced> cardsReduced = new List<SVCardReduced>();
                    List<SVCard> cards = new List<SVCard>();
                    using (StreamReader r = new StreamReader(path))
                    {
                        string jsonString = r.ReadToEnd();
                        dynamic stuff = JsonConvert.DeserializeObject(jsonString);
                        dynamic stuffData = stuff.data;
                        string stuffDataCards = stuffData.cards.ToString();
                        cards = JsonConvert.DeserializeObject<List<SVCard>>(stuffDataCards);



                    }

                    foreach (SVCard svc in cards)
                    {
                        if (!String.IsNullOrEmpty(svc.card_name))
                        {
                            //SVCardReduced reduc = 
                            cardsReduced.Add(new SVCardReduced(svc.card_name, svc.description, svc.evo_description, svc.skill_disc, svc.evo_skill_disc));
                        }
                    }
                    //string json = "";
                    //var jsonRaw;
                    string json = "";
                    //string opath = "C:\\Users\\ChristopherTang\\Documents\\sv_reduced.json";
                    if (cardsReduced.Count > 0)
                    {
                        var jsonRaw = JsonConvert.SerializeObject(cardsReduced);
                        JToken jt = JToken.Parse(jsonRaw);
                        json = jt.ToString(Newtonsoft.Json.Formatting.Indented);
                    }

                    /*
                    if (!File.Exists(o.Output))
                    {
                        File.Create(o.Output);
                    }*/

                    using (StreamWriter sw = new StreamWriter(o.Output, false))
                    {
                        sw.WriteLine(json);
                    }
                }
                else
                {
                    Console.WriteLine("Error! Either input or output argument was not specified.");
                    System.Environment.Exit(0);
                }
            });
        }
    }
}
