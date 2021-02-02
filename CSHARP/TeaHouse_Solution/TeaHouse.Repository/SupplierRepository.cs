// <copyright file="SupplierRepository.cs" company="PlaceholderCompany">
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
    /// Handles the supplier's repository functions.
    /// </summary>
    public class SupplierRepository : ISupplierRepository
    {
        /// <summary>
        /// Creates a new SUPPLIER element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        public void Create(string s)
        {
            string[] data = s.Split(';');
            SUPPLIER newsupplier = new SUPPLIER()
            {
                SUP_ID = int.Parse(data[1]),
                SNAME = data[2],
                STREET = data[3],
                CITY = data[4],
                ORDER_STATUS = data[5],
                ORDERSTOTAL = int.Parse(data[6])
            };
            DatabaseHandler.Instance.AddNewSupplier(newsupplier);
            DatabaseHandler.Instance.SaveDB();
        }

        /// <summary>
        /// Deletes a SUPPLIER element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        public void Delete(string s)
        {
            string[] data = s.Split(';');
            int id = int.Parse(data[1]);
            SUPPLIER delsupplier = this.GetAll().Single(x => x.SUP_ID == id);
            DatabaseHandler.Instance.DeleteSupplier(delsupplier);
            DatabaseHandler.Instance.SaveDB();
        }

        /// <summary>
        /// Returns SUPPLIER table's values as a query.
        /// </summary>
        /// <returns>SUPPLIER table as a query.</returns>
        public IQueryable<SUPPLIER> GetAll()
        {
            return DatabaseHandler.Instance.GetAllSuppliers().AsQueryable();
        }

        /// <summary>
        /// Returns a formatted string containing the SUPPLIER table's data.
        /// </summary>
        /// <returns>the SUPPLIER table's data as a string.</returns>
        public string Read()
        {
            string readTable = "SUP_ID\tSNAME\tSTREET\tCITY\tORDER_STATUS\tORDERSTOTAL\n";
            foreach (var item in this.GetAll())
            {
                readTable += $"{item.SUP_ID}\t{item.SNAME}\t{item.STREET}\t{item.CITY}\t{item.ORDER_STATUS}\t{item.ORDERSTOTAL}\n";
            }

            return readTable;
        }

        /// <summary>
        /// Updates a SUPPLIER element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        public void Update(string s)
        {
            string[] data = s.Split(';');
            int id = int.Parse(data[1]);
            SUPPLIER updatesupplier = this.GetAll().Single(x => x.SUP_ID == id);
            string typeCase = data[2].ToUpper();
            switch (typeCase)
            {
                case "SNAME":
                    updatesupplier.SNAME = data[3];
                    break;
                case "STREET":
                    updatesupplier.STREET = data[3];
                    break;
                case "CITY":
                    updatesupplier.CITY = data[3];
                    break;
                case "ORDER_STATUS":
                    updatesupplier.ORDER_STATUS = data[3];
                    break;
                case "ORDERSTOTAL":
                    updatesupplier.ORDERSTOTAL = int.Parse(data[3]);
                    break;
                default: throw new NotImplementedException();
            }

            DatabaseHandler.Instance.SaveDB();
        }
    }
}
