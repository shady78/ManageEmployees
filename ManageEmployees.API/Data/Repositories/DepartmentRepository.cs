﻿using ManageEmployees.API.Data.Base;
using ManageEmployees.API.Data.Interface;
using ManageEmployees.API.Models.Entities;

namespace ManageEmployees.API.Data.Repositories
{
    public class DepartmentRepository : EntityBaseRepository<Department> , IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
