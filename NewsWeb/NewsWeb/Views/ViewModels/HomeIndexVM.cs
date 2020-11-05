using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Views.ViewModels
{
    public class HomeIndexVM
    {
        public List<Post> Posts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
