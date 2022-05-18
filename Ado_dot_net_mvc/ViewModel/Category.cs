using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ado_dot_net_mvc.ViewModel
{
    public class Category
    {
        public int id { get; set; }


        [Required(ErrorMessage ="dena hi padega") ]
        [MinLength(3,ErrorMessage ="bhai pura to likh")]
       

        public string name { get; set; }

    }
}