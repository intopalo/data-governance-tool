﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntopaloApi.System_for_data_governance
{
    public class Collection : Structured
    {
        public Database Database { get; set; }
        public int DatabaseId { get; set; }
    }
}