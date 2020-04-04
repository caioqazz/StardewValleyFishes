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
        IEnumerable<Fish> GetFishesByName( string name);
        Fish GetById(int id);
        Fish Update(Fish updatedFish);
        Fish Add(Fish newFish);
        int Commit();
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

        public Fish GetById(int id)
        {
            return fishes.SingleOrDefault(r => r.Id == id);
        }
        public Fish Add(Fish newFish)
        {
            fishes.Add(newFish);
            newFish.Id = fishes.Max(r => r.Id) + 1;
            return newFish;
        }

        public Fish Update(Fish updatedFish)
        {
            var fish = fishes.SingleOrDefault(r => r.Id == updatedFish.Id);
            if (fish != null)
            {
                fish.Name = updatedFish.Name;
                fish.Local = updatedFish.Local;
            }
            return fish;
        }

        public int Commit()
        {
            return 0;
        }


        public IEnumerable<Fish> GetFishesByName(string name = null)
        {
            return from r in fishes
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
