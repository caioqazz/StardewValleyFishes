using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StardewValleyFishes.Core;
using StardewValleyFishes.Data;

namespace StardewValleyFishes.Pages.Fishes
{
    public class DetailModel : PageModel
    {
        private readonly IFishData fishData;

        public Fish Fish { get; set; }

        public DetailModel(IFishData fishData)
        {
            this.fishData = fishData;
        }

        public IActionResult OnGet(int fishId)
        {
            Fish = fishData.GetById(fishId);
            if (Fish == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}