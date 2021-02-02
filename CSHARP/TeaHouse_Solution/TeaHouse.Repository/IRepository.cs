// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TeaHouse.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Initialization interface for the Repositories.
    /// </summary>
    /// <typeparam name="TEntity">Any type of repository.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Returns all the elements of the repository.
        /// </summary>
        /// <returns>T type query.</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Creates a new T element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        void Create(string s);

        /// <summary>
        /// Returns a formatted string containing the table's data.
        /// </summary>
        /// <returns>The table's data as a string.</returns>
        string Read();

        /// <summary>
        /// Updates a T element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        void Update(string s);

        /// <summary>
        /// Deletes a T element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        void Delete(string s);
    }
}
