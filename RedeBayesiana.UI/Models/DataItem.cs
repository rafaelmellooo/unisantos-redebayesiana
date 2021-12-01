using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeBayesiana.UI.Models
{
    public class DataItem : IComparable<DataItem>
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public int CompareTo(DataItem? other)
        {
            return string.Compare(Name, other!.Name, StringComparison.Ordinal);
        }
    }
}
