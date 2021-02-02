// <copyright file="ITealeafRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TeaHouse.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TeaHouse.Data;

    /// <summary>
    /// Interface for Tealeaf repository.
    /// </summary>
    public interface ITealeafRepository : IRepository<TEALEAF>
    {
        string TealeafBrandsOrdered();
        string TealeavesBySuppliers();
    }
}
