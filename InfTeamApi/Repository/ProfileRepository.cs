﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Interface;
using Repository.Persistence;

namespace Repository
{
    public class ProfileRepository : Repository<Profile>, IProfile
    {
        public ProfileRepository(InfTeamApiDBContext context) :base(context)
        {
        }
    }
}