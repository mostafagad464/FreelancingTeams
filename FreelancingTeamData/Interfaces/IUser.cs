﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Interfaces
{
    public interface IUser<T>
    {
        public void CompleteProfile(int UserId, Task _object);
    }
}
