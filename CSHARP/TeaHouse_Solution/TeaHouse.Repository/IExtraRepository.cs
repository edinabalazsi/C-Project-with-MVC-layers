// <copyright file="IExtraRepository.cs" company="PlaceholderCompany">
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
    /// Interface for Extra Repository.
    /// </summary>
    public interface IExtraRepository : IRepository<EXTRA>
    {
        string ExtrasAvailability();
        EXTRA GetExtraById(int id);
        bool RemoveExtra(int id);
        void InsertExtra(string category, string extraName, string allergen, bool available, int price);
        bool ChangeExtra(int id, string category, string extraName, string allergen, bool available, int price);
    }
}
