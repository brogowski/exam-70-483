using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"marvel-wikia-data.csv");
            var parsed = input.Skip(1).Select(ParseCsvLine).Take(25);

            var result = Parallel.ForEach(parsed, (x, state) => 
            {
                Console.WriteLine(x.Name);
                if (x.Name.Contains("Spider"))
                {
                    state.Stop();
                }
            });

            Console.WriteLine("Has completed: " + result.IsCompleted);
            Console.ReadKey();
        }

        private static ComicCharacter ParseCsvLine(string line)
        {
            var fields = line.Split(',');
            return new ComicCharacter
            {
                PageId = int.Parse(fields[0]),
                Name = fields[1],
                Urlslug = fields[2],
                Id = fields[3],
                Align = fields[4],
                Eye = fields[5],
                Hair = fields[6],
                Sex = fields[7],
                Gsm = fields[8],
                Alive = fields[9],
                Apperances = fields[10],
                FirstApperance = fields[11],
                Year = int.TryParse(fields[12], out int result) ? (int?)result : null
            };
        }
    }
}
