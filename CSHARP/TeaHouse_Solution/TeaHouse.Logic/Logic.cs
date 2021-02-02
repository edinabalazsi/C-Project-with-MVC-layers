// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TeaHouse.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TeaHouse.Repository;

    /// <summary>
    /// Contains the logic database methods.
    /// </summary>
    public class Logic : ILogic
    {
        private readonly RepositoryHelper helper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Creates the logic, and initializes it.
        /// </summary>
        public Logic()
        {
            this.helper = new RepositoryHelper();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// This constructor helps the LogicTester class.
        /// </summary>
        /// <param name="repohelper">Sets the Repositoryhelper from the given parameter.</param>
        public Logic(RepositoryHelper repohelper)
        {
            this.helper = repohelper;
        }

        /// <summary>
        /// Gets the RepositoryHelper instance.
        /// </summary>
        public virtual RepositoryHelper Helper
        {
            get
            {
                return this.helper;
            }
        }

        /// <summary>
        /// Returns all table names from the DB.
        /// </summary>
        /// <returns>True/False.</returns>
        public List<string> GetAllTableNames()
        {
            return this.helper.GetAllTableNames();
        }

        /// <summary>
        /// Creates a new Extra element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        public void CreateExtra(string s)
        {
            this.helper.ExtraRepository.Create(s);
        }

        /// <summary>
        /// Creates a new Supplier element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        public void CreateSupplier(string s)
        {
            this.helper.SupplierRepository.Create(s);
        }

        /// <summary>
        /// Creates a new Tea element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        public void CreateTea(string s)
        {
            this.helper.TeaRepository.Create(s);
        }

        /// <summary>
        /// Creates a new Tealeaf element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        public void CreateTealeaf(string s)
        {
            this.helper.TealeafRepository.Create(s);
        }

        /// <summary>
        /// Deletes a Extra element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        public void DeleteExtra(string s)
        {
            this.helper.ExtraRepository.Delete(s);
        }

        /// <summary>
        /// Deletes a Supplier element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        public void DeleteSupplier(string s)
        {
            this.helper.SupplierRepository.Delete(s);
        }

        /// <summary>
        /// Deletes a Tea element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        public void DeleteTea(string s)
        {
            this.helper.TeaRepository.Delete(s);
        }

        /// <summary>
        /// Deletes a Tealeaf element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        public void DeleteTealeaf(string s)
        {
            this.helper.TealeafRepository.Delete(s);
        }

        /// <summary>
        /// Returns a formatted string containing the Extra table's data.
        /// </summary>
        /// <returns>The table's data as a string.</returns>
        public string ReadExtra()
        {
            return this.helper.ExtraRepository.Read();
        }

        /// <summary>
        /// Returns a formatted string containing the Supplier table's data.
        /// </summary>
        /// <returns>The table's data as a string.</returns>
        public string ReadSupplier()
        {
            return this.helper.SupplierRepository.Read();
        }

        /// <summary>
        /// Returns a formatted string containing the Tea table's data.
        /// </summary>
        /// <returns>The table's data as a string.</returns>
        public string ReadTea()
        {
            return this.helper.TeaRepository.Read();
        }

        /// <summary>
        /// Returns a formatted string containing the Tealeaf table's data.
        /// </summary>
        /// <returns>The table's data as a string.</returns>
        public string ReadTealeaf()
        {
            return this.helper.TealeafRepository.Read();
        }

        /// <summary>
        /// Updates a Extra element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        public void UpdateExtra(string s)
        {
            this.helper.ExtraRepository.Update(s);
        }

        /// <summary>
        /// Updates a Supplier element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        public void UpdateSupplier(string s)
        {
            this.helper.SupplierRepository.Update(s);
        }

        /// <summary>
        /// Updates a Tea element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        public void UpdateTea(string s)
        {
            this.helper.TeaRepository.Update(s);
        }

        /// <summary>
        /// Updates a Tealeaf element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        public void UpdateTealeaf(string s)
        {
            this.helper.TealeafRepository.Update(s);
        }

        /// <summary>
        /// Listing TeaLeaves' brands in order of frequency.
        /// </summary>
        /// <returns>String containing the query's result.</returns>
        public string TealeafBrandsOrdered()
        {
            return this.helper.TealeafRepository.TealeafBrandsOrdered();
        }

        /// <summary>
        /// Makes a query for selecting tealeaves grouped by suppliers.
        /// </summary>
        /// <returns>String containing the query's result.</returns>
        public string TealeavesBySuppliers()
        {
            return this.helper.TealeafRepository.TealeavesBySuppliers();
        }

        /// <summary>
        /// Get how many Extras are available.
        /// </summary>
        /// <returns>String containing the query's result.</returns>
        public string ExtrasAvailability()
        {
            return this.helper.ExtraRepository.ExtrasAvailability();
        }

        /// <summary>
        /// Gets all elements of EXTRA table.
        /// </summary>
        /// <returns>List of Extra objects.</returns>
        public IList<Data.EXTRA> GetAllExtras()
        {
            return this.helper.ExtraRepository.GetAll().ToList();
        }

        /// <summary>
        /// Returns the extras id.
        /// </summary>
        /// <param name="id">The id of the extra.</param>
        /// <returns>The extra object.</returns>
        public Data.EXTRA GetExtraById(int id)
        {
            return this.helper.ExtraRepository.GetExtraById(id);
        }

        public bool RemoveExtra(int id)
        {
           return this.helper.ExtraRepository.RemoveExtra(id);
        }

        public void AddExtra(string category, string extraName, string allergen, bool available, int price)
        {
            this.helper.ExtraRepository.InsertExtra(category, extraName, allergen, available, price);
        }

        public bool ChangeExtra(int id, string category, string extraName, string allergen, bool available, int price)
        {
           return this.helper.ExtraRepository.ChangeExtra(id, category, extraName, allergen, available, price);
        }
    }
}
