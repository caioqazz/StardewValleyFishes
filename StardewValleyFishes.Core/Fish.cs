using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardewValleyFishes.Core
{
    public class Fish
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SeasonType Season { get; set; }
        public Location Local { get; set; }
        public WeatherType Weather { get; set; }
    }
}
