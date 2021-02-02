// <copyright file="RepositoryHelper.cs" company="PlaceholderCompany">
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
    /// This helper supports getting the specific repositories.
    /// </summary>
    public class RepositoryHelper
    {
        private readonly IExtraRepository extraRepo;
        private readonly ISupplierRepository supplierRepo;
        private readonly ITealeafRepository tealeafRepo;
        private readonly ITeaRepository teaRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryHelper"/> class.
        /// This constructor creates each instance for the repositories.
        /// </summary>
        public RepositoryHelper()
        {
            this.extraRepo = new ExtraRepository();
            this.supplierRepo = new SupplierRepository();
            this.tealeafRepo = new TealeafRepository();
            this.teaRepo = new TeaRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryHelper"/> class.
        /// This constructor sets the given parameters to repositories for testing.
        /// </summary>
        /// <param name="extrarepo">sets the extraRepo.</param>
        /// <param name="suprepo">sets the supplierRepo.</param>
        /// <param name="tealeafrepo">sets the tealeafRepo.</param>
        /// <param name="tearepo">sets the teaRepo.</param>
        public RepositoryHelper(IExtraRepository extrarepo, ISupplierRepository suprepo, ITealeafRepository tealeafrepo, ITeaRepository tearepo)
        {
            this.extraRepo = extrarepo;
            this.supplierRepo = suprepo;
            this.tealeafRepo = tealeafrepo;
            this.teaRepo = tearepo;
        }

        /// <summary>
        /// Gets the extra repository.
        /// </summary>
        public virtual IExtraRepository ExtraRepository
        {
            get { return this.extraRepo; }
        }

        /// <summary>
        /// Gets the supplier repository.
        /// </summary>
        public virtual ISupplierRepository SupplierRepository
        {
            get { return this.supplierRepo; }
        }

        /// <summary>
        /// Gets the tealeaf repository.
        /// </summary>
        public virtual ITealeafRepository TealeafRepository
        {
            get { return this.tealeafRepo; }
        }

        /// <summary>
        /// Gets the tea repository.
        /// </summary>
        public virtual ITeaRepository TeaRepository
        {
            get { return this.teaRepo; }
        }

        /// <summary>
        /// Returns all the table names.
        /// </summary>
        /// <returns>List of strings.</returns>
        public List<string> GetAllTableNames()
        {
            return DatabaseHandler.Instance.TablesNames;
        }
    }
}
