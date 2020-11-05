using Microsoft.AspNetCore.Mvc.Rendering;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Views.ViewModels
{
    public class PostCreateVM
    {
        public Post Post { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
        public IEnumerable<SelectListItem> TagSelectList { get; set; }
        public IEnumerable<int> SelectListTagIds { get; set; }
    }
}
