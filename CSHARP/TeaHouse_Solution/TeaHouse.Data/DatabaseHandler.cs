// <copyright file="DatabaseHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TeaHouse.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Handles the projects inner read-write method calls for the database.
    /// </summary>
    public class DatabaseHandler
    {
        /// <summary>
        /// Holds the instance of the class.
        /// </summary>
        private static DatabaseHandler instance;

        /// <summary>
        /// Holds the database model.
        /// </summary>
        private readonly TeaHouseDatabaseEntities teahouseDatabaseEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseHandler"/> class.
        /// Creates an instance for the DatabaseHandler.
        /// </summary>
        private DatabaseHandler()
        {
            this.teahouseDatabaseEntities = new TeaHouseDatabaseEntities();
        }

        /// <summary>
        /// Gets the instance of the DataBaseHandler.
        /// </summary>
        public static DatabaseHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseHandler();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the TeaHouseDatabase instance.
        /// </summary>
        public virtual TeaHouseDatabaseEntities TeaHouseDatabase
        {
            get { return this.teahouseDatabaseEntities; }
        }

        /// <summary>
        /// Gets all Table's names from the db.
        /// </summary>
        public virtual List<string> TablesNames
        {
            get
            {
                return this.teahouseDatabaseEntities.Database.SqlQuery<string>("SELECT name FROM sys.tables ORDER BY name")
                    .ToList();
            }
        }

        /// <summary>
        /// Adds a new extra to the database.
        /// </summary>
        /// <param name="extra">extra.</param>
        public virtual void AddNewExtra(EXTRA extra)
        {
            this.teahouseDatabaseEntities.EXTRA.Add(extra);
        }

        /// <summary>
        /// Adds a new supplier to the database.
        /// </summary>
        /// <param name="supplier">supplier.</param>
        public virtual void AddNewSupplier(SUPPLIER supplier)
        {
            this.teahouseDatabaseEntities.SUPPLIER.Add(supplier);
        }

        /// <summary>
        /// Adds a new tea to the database.
        /// </summary>
        /// <param name="tea">tea.</param>
        public virtual void AddNewTea(TEA tea)
        {
            this.teahouseDatabaseEntities.TEA.Add(tea);
        }

        /// <summary>
        /// Adds a new tealeaf to the database.
        /// </summary>
        /// <param name="tealeaf">tealeaf.</param>
        public virtual void AddNewTeaLeaf(TEALEAF tealeaf)
        {
            this.teahouseDatabaseEntities.TEALEAF.Add(tealeaf);
        }

        /// <summary>
        /// Deletes an extra from the database.
        /// </summary>
        /// <param name="extra">extra.</param>
        public virtual void DeleteExtra(EXTRA extra)
        {
            if (this.teahouseDatabaseEntities.EXTRA.Any(x => x.EXT_ID == extra.EXT_ID))
            {
                this.teahouseDatabaseEntities.EXTRA.Remove(extra);
            }
        }

        /// <summary>
        /// Deletes a supplier from the database.
        /// </summary>
        /// <param name="supplier">supplier.</param>
        public virtual void DeleteSupplier(SUPPLIER supplier)
        {
            if (this.teahouseDatabaseEntities.SUPPLIER.Any(x => x.SUP_ID == supplier.SUP_ID))
            {
                var junction = this.teahouseDatabaseEntities.SUP_TLEAF_JUNCTION.FirstOrDefault(y => y.SUP_ID == supplier.SUP_ID);
                this.teahouseDatabaseEntities.SUP_TLEAF_JUNCTION.Remove(junction);
                this.teahouseDatabaseEntities.SUPPLIER.Remove(supplier);
            }
        }

        /// <summary>
        /// Deletes a tea from the database.
        /// </summary>
        /// <param name="tea">tea.</param>
        public virtual void DeleteTea(TEA tea)
        {
            if (this.teahouseDatabaseEntities.TEA.Any(x => x.TEA_ID == tea.TEA_ID))
            {
                this.teahouseDatabaseEntities.TEA.Remove(tea);
            }
        }

        /// <summary>
        /// Deletes a tealeaf from the database.
        /// </summary>
        /// <param name="tealeaf">tealeaf.</param>
        public virtual void DeleteTeaLeaf(TEALEAF tealeaf)
        {
            if (this.teahouseDatabaseEntities.TEALEAF.Any(x => x.TL_ID == tealeaf.TL_ID))
            {
                var junction = this.teahouseDatabaseEntities.SUP_TLEAF_JUNCTION.FirstOrDefault(y => y.TL_ID == tealeaf.TL_ID);
                this.teahouseDatabaseEntities.SUP_TLEAF_JUNCTION.Remove(junction);
                this.teahouseDatabaseEntities.TEALEAF.Remove(tealeaf);
            }
        }

        /// <summary>
        /// Returns all current extras from the database.
        /// </summary>
        /// <returns>List of extras.</returns>
        public virtual List<EXTRA> GetAllExtras()
        {
            var bquery = this.teahouseDatabaseEntities.EXTRA.Select(o => o);
            return bquery.ToList();
        }

        /// <summary>
        /// Returns all current suppliers from the database.
        /// </summary>
        /// <returns>List of suppliers.</returns>
        public virtual List<SUPPLIER> GetAllSuppliers()
        {
            var bquery = this.teahouseDatabaseEntities.SUPPLIER.Select(o => o);
            return bquery.ToList();
        }

        /// <summary>
        /// Returns all current teas from the database.
        /// </summary>
        /// <returns>List of teas.</returns>
        public virtual List<TEA> GetAllTeas()
        {
            var bquery = this.teahouseDatabaseEntities.TEA.Select(o => o);
            return bquery.ToList();
        }

        /// <summary>
        /// Returns all current tealeaves from the database.
        /// </summary>
        /// <returns>List of tealeaves.</returns>
        public virtual List<TEALEAF> GetAllTeaLeaves()
        {
            var bquery = this.teahouseDatabaseEntities.TEALEAF.Select(o => o);
            return bquery.ToList();
        }

        /// <summary>
        /// Returns all current supplier-tealeaf connection from the database.
        /// </summary>
        /// <returns>List of tealeaves.</returns>
        public virtual List<SUP_TLEAF_JUNCTION> GetAllSupplierTealeafKeys()
        {
            var bquery = this.teahouseDatabaseEntities.SUP_TLEAF_JUNCTION.Select(o => o);
            return bquery.ToList();
        }

        /// <summary>
        /// Saves the database.
        /// </summary>
        public virtual void SaveDB()
        {
            this.teahouseDatabaseEntities.SaveChanges();
        }
    }
}
