using System;
using System.Linq;

namespace Sandbox
{
    internal class ComicCharacter
    {
        public int PageId { get; set; }
        public string Name { get; set; }
        public string Urlslug { get; set; }
        public string Id { get; set; }
        public string Align { get; set; }
        public string Eye { get; set; }
        public string Hair { get; set; }
        public string Sex { get; set; }
        public string Gsm { get; set; }
        public string Alive { get; set; }
        public string Apperances { get; set; }
        public string FirstApperance { get; set; }
        public int? Year { get; set; }

        public override string ToString()
        {
            return GetType()
                .GetProperties()
                .Select(x => (name: x.Name, value: x.GetValue(this)))
                .Aggregate("", (acc, x) => string.Join(Environment.NewLine, acc, $"{x.name}: {x.value}"));
        }
    }
}