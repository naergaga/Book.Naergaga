﻿using Book.Naergaga.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.AdminView
{
    public class CategoryEditViewModel
    {
        public Category Category { get; set; }
        public bool IsCreate { get; set; }
    }
}
