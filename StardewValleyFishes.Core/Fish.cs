using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StardewValleyFishes.Core
{
    public class Fish
    {

        public int Id { get; set; }
        
        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(80)]
        public string Description { get; set; }

        public SeasonType Season { get; set; }
        public Location Local { get; set; }
        public WeatherType Weather { get; set; }
    }
}
