﻿using Book.Naergaga.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Naergaga.Models.AdminView
{
    public class BookEditViewModel
    {
        public EBook Book { get; set; }
        public bool IsCreate { get; set; }
    }
}
