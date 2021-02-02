// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TeaHouse.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ILogic interface with the base methods for the logic class.
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Creates a new Extra element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        void CreateExtra(string s);

        /// <summary>
        /// Creates a new Supplier element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        void CreateSupplier(string s);

        /// <summary>
        /// Creates a new Tealeaf element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        void CreateTealeaf(string s);

        /// <summary>
        /// Creates a new Tea element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        void CreateTea(string s);

        /// <summary>
        /// Returns a formatted string containing the Extra table's data.
        /// </summary>
        /// <returns>The table's data as a string.</returns>
        string ReadExtra();

        /// <summary>
        /// Returns a formatted string containing the Supplier table's data.
        /// </summary>
        /// <returns>The table's data as a string.</returns>
        string ReadSupplier();

        /// <summary>
        /// Returns a formatted string containing the Tealeaf table's data.
        /// </summary>
        /// <returns>The table's data as a string.</returns>
        string ReadTealeaf();

        /// <summary>
        /// Returns a formatted string containing the Tea table's data.
        /// </summary>
        /// <returns>The table's data as a string.</returns>
        string ReadTea();

        /// <summary>
        /// Updates a Extra element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        void UpdateExtra(string s);

        /// <summary>
        /// Updates a Supplier element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        void UpdateSupplier(string s);

        /// <summary>
        /// Updates a Tealeaf element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        void UpdateTealeaf(string s);

        /// <summary>
        /// Updates a Tea element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        void UpdateTea(string s);

        /// <summary>
        /// Deletes a Extra element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        void DeleteExtra(string s);

        /// <summary>
        /// Deletes a Supplier element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        void DeleteSupplier(string s);

        /// <summary>
        /// Deletes a Tealeaf element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        void DeleteTealeaf(string s);

        /// <summary>
        /// Deletes a Tea element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        void DeleteTea(string s);

        /// <summary>
        /// Returns all elements of EXTRA table.
        /// </summary>
        /// <returns>A list of extra objects.</returns>
        IList<Data.EXTRA> GetAllExtras();

        /// <summary>
        /// Returns the extras id.
        /// </summary>
        /// <param name="id">The id of the extra.</param>
        /// <returns>The extra object.</returns>
        Data.EXTRA GetExtraById(int id);

        bool RemoveExtra(int id);

        void AddExtra(string category, string extraName, string allergen, bool available, int price);

        bool ChangeExtra(int id, string category, string extraName, string allergen, bool available, int price);

    }
}
