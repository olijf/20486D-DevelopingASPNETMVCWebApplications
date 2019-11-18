using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActorsRazorPages.Models;

namespace ActorsRazorPages.Pages.Actors
{
    public class IndexModel : PageModel
    {
        private IData _data;
        public IList<Actor> Actors { get; set; }
        public IndexModel(IData data)
        {
            _data = data;
        }
        public void OnGet()
        {
            Actors = _data.ActorsInitializeData();
        }
    }
}