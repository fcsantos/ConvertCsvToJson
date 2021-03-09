using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ConvertCsvToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            try
            {
                List<Concelho> values = File.ReadAllLines(@"E:\outsystems\Samples\todos_cp\concelhos.txt", System.Text.Encoding.UTF7)
                   .Skip(1)
                   .Select(v => Concelho.FromCsv(v))
                   .ToList();

                //open file stream
                using (StreamWriter file = File.CreateText(@"E:\outsystems\Samples\todos_cp\concelhos_json.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, values);
                }

                Console.WriteLine("Ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not Ok " + ex.Message);
            }
        }
    }

    public class TodosCp
    {
        public TodosCp()
        {
            _id = Guid.NewGuid();
        }

        public Guid _id { get; set; }
        public int cod_distrito { get; set; }

        public int cod_concelho { get; set; }

        public int cod_localidade { get; set; }

        public string nome_localidade { get; set; }

        public string cod_arteria { get; set; }

        public string tipo_arteria { get; set; }

        public string prep1 { get; set; }

        public string titulo_arteria { get; set; }

        public string prep2 { get; set; }

        public string nome_arteria { get; set; }

        public string local_arteria { get; set; }

        public string troco { get; set; }

        public string porta { get; set; }

        public string cliente { get; set; }

        public string num_cod_postal { get; set; }

        public string ext_cod_postal { get; set; }

        public string desig_postal { get; set; }

        public static TodosCp FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            TodosCp cp = new TodosCp();
            cp.cod_distrito = Convert.ToInt32(values[0]);
            cp.cod_concelho = Convert.ToInt32(values[1]);
            cp.cod_localidade = Convert.ToInt32(values[2]);
            cp.nome_localidade = Convert.ToString(values[3]);
            cp.cod_arteria = Convert.ToString(values[4]);
            cp.tipo_arteria = Convert.ToString(values[5]);
            cp.prep1 = Convert.ToString(values[6]);
            cp.titulo_arteria = Convert.ToString(values[7]);
            cp.prep2 = Convert.ToString(values[8]);
            cp.nome_arteria = Convert.ToString(values[9]);
            cp.local_arteria = Convert.ToString(values[10]);
            cp.troco = Convert.ToString(values[11]);
            cp.porta = Convert.ToString(values[12]);
            cp.cliente = Convert.ToString(values[13]);
            cp.num_cod_postal = Convert.ToString(values[14]);
            cp.ext_cod_postal = Convert.ToString(values[15]);
            cp.desig_postal = Convert.ToString(values[16]);            

            return cp;
        }
    }

    public class Distrito
    {
        public Distrito()
        {
            _id = Guid.NewGuid();
        }

        public Guid _id { get; set; }

        public int cod_distrito { get; set; }

        public string nome_distrito { get; set; }

        public static Distrito FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Distrito d = new Distrito();
            d.cod_distrito = Convert.ToInt32(values[0]);
            d.nome_distrito = Convert.ToString(values[1]);

            return d;
        }
    }

    public class Concelho
    {
        public Concelho()
        {
            _id = Guid.NewGuid();
        }

        public Guid _id { get; set; }

        public int cod_distrito { get; set; }

        public int cod_concelho { get; set; }
        
        public string nome_concelho { get; set; }

        public static Concelho FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Concelho c = new Concelho();
            c.cod_distrito = Convert.ToInt32(values[0]);
            c.cod_concelho = Convert.ToInt32(values[1]);
            c.nome_concelho = Convert.ToString(values[2]);

            return c;
        }
    }
}
