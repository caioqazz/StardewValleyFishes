using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using StardewValleyFishes.Core;
using StardewValleyFishes.Data;

namespace StardewValleyFishes.Pages.Fishes
{
    public class ListModel : PageModel
    {
      
            private readonly IConfiguration config;
            private readonly IFishData fishData;

            public string Message { get; set; }
            public IEnumerable<Fish> Fishes { get; set; }

            public ListModel(IConfiguration config,
                             IFishData fishData)
            {
                this.config = config;
                this.fishData = fishData;
            }

            public void OnGet()
            {
                Message = config["Message"];
                 Fishes = fishData.GetAll();
            }
        
    }
}