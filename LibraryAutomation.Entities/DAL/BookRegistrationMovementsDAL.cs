﻿using LibraryAutomation.Entities.Model.Context;
using LibraryAutomation.Entities.Model;
using LibraryAutomation.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.DAL
{
    public class BookRegistrationMovementsDAL : GenericRepository<LibraryContext, BookRegistrationMovements>
    {
    }
}