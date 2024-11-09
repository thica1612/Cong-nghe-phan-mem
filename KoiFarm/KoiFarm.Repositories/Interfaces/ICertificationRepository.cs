﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarm.Repositories.Entities;

namespace KoiFarm.Repositories.Interfaces
{
    public interface ICertificationRepository
    {
        Task<List<Certification>> GetAllCertification();
    }
}
