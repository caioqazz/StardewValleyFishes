using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValleyFishes.Core;
namespace StardewValleyFishes.Data
{
    public interface IFishData
    {
        IEnumerable<Fish> GetAll();
    }
    public class InMemoryFishData : IFishData
    {
        readonly List<Fish> fishes;

        public InMemoryFishData()
        {
            fishes = new List<Fish>()
            {
                new Fish { Id = 1, Name = "Midnight Carp", Description="This shy fish only feels comfortable at night.", Local=Location.Mountain, Weather = WeatherType.Any, Season = SeasonType.Fall},
                new Fish { Id = 2, Name = "Salmon", Description="Swims upstream to lay its eggs.", Local=Location.Mountain, Weather = WeatherType.Any, Season = SeasonType.Fall},
                new Fish { Id = 3, Name = "Midnight", Description="Maryland", Local=Location.Mountain, Weather = WeatherType.Any, Season = SeasonType.Fall}
              
    };
        }

        public IEnumerable<Fish> GetAll()
        {
            return from r in fishes
                   orderby r.Name
                   select r;
        }
    }
}
