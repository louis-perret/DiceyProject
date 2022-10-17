﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ProfileFolder
{
    public class SimpleProfile : Profile
    {
        public SimpleProfile(string name, string surname) : base(name, surname)
        {
        }

        public SimpleProfile(Guid id, string name, string surname) : base(id, name, surname)
        {
        }
    }
}
