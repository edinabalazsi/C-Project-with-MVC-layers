// <copyright file="TealeafRepository.cs" company="PlaceholderCompany">
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
    /// Handles tealeaf's repository functions.
    /// </summary>
    public class TealeafRepository : ITealeafRepository
    {
        /// <summary>
        /// Creates a new TEALEAF element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        public void Create(string s)
        {
            string[] data = s.Split(';');
            TEALEAF newtealeaf = new TEALEAF()
            {
                TL_ID = int.Parse(data[1]),
                TLNAME = data[2],
                VARIETY = data[3],
                BRAND = data[4],
                ACIDITY = data[5],
                FLAVOUR = data[6],
                REGION = data[7]
            };
            DatabaseHandler.Instance.AddNewTeaLeaf(newtealeaf);
            DatabaseHandler.Instance.SaveDB();
        }

        /// <summary>
        /// Deletes a TEALEAF element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        public void Delete(string s)
        {
            string[] data = s.Split(';');
            int id = int.Parse(data[1]);
            TEALEAF deltealeaf = this.GetAll().Single(x => x.TL_ID == id);
            DatabaseHandler.Instance.DeleteTeaLeaf(deltealeaf);
            DatabaseHandler.Instance.SaveDB();
        }

        /// <summary>
        /// Returns TEALEAF table's values as a query.
        /// </summary>
        /// <returns>TEALEAF table as a query.</returns>
        public IQueryable<TEALEAF> GetAll()
        {
            return DatabaseHandler.Instance.GetAllTeaLeaves().AsQueryable();
        }

        /// <summary>
        /// Returns a formatted string containing the TEALEAF table's data.
        /// </summary>
        /// <returns>the TEALEAF table's data as a string.</returns>
        public string Read()
        {
            string readTable = "TL_ID\tTLNAME\tVARIETY\tBRAND\tACIDITY\tFLAVOUR\tREGION\n";
            foreach (var item in this.GetAll())
            {
                readTable += $"{item.TL_ID}\t{item.TLNAME}\t{item.VARIETY}\t{item.BRAND}\t{item.ACIDITY}\t{item.FLAVOUR}\t{item.REGION}\n";
            }

            return readTable;
        }

        /// <summary>
        /// Updates a TEALEAF element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        public void Update(string s)
        {
            string[] data = s.Split(';');
            int id = int.Parse(data[1]);
            TEALEAF updatetealeaf = this.GetAll().Single(x => x.TL_ID == id);
            string typeCase = data[2].ToUpper();
            switch (typeCase)
            {
                case "TLNAME":
                    updatetealeaf.TLNAME = data[3];
                    break;
                case "VARIETY":
                    updatetealeaf.VARIETY = data[3];
                    break;
                case "BRAND":
                    updatetealeaf.BRAND = data[3];
                    break;
                case "ACIDITY":
                    updatetealeaf.ACIDITY = data[3];
                    break;
                case "FLAVOURED":
                    updatetealeaf.FLAVOUR = data[3];
                    break;
                case "REGION":
                    updatetealeaf.REGION = data[3];
                    break;
                default: throw new NotImplementedException();
            }

            DatabaseHandler.Instance.SaveDB();
        }

        /// <summary>
        /// Listing TeaLeaves' brands in order of frequency.
        /// </summary>
        /// <returns>String containing the query's result.</returns>
        public string TealeafBrandsOrdered()
        {
            string tealeafbrands = string.Format("{0,-15} {1,2}", "Tealeaf brand", "Count\n");
            var q = from leaf in this.GetAll()
                    group leaf by leaf.BRAND into g
                    let countbr = g.Count()
                    orderby countbr descending
                    select new
                    {
                        Brand = g.Key,
                        Count = countbr
                    };
            foreach (var item in q)
            {
                tealeafbrands += $"{item.Brand,-15} {item.Count,2}\n";
            }

            return tealeafbrands;
        }

        /// <summary>
        /// Makes a query for selecting tealeaves grouped by suppliers.
        /// </summary>
        /// <returns>The query as a string.</returns>
        public string TealeavesBySuppliers()
        {
            string result = string.Format("{0,-25} {1,20}", "Suppliers", "Tealeaves\n");
            var q = from leaves in this.GetAll()
                    join junction in DatabaseHandler.Instance.GetAllSupplierTealeafKeys().AsQueryable() on leaves.TL_ID equals junction.TL_ID
                    join supplier in DatabaseHandler.Instance.GetAllSuppliers().AsQueryable() on junction.SUP_ID equals supplier.SUP_ID
                    orderby supplier.SNAME
                    select new
                    {
                        supplier.SNAME,
                        leaves.TLNAME
                    };

            foreach (var item in q)
            {
                result += $"{item.SNAME,-25}{item.TLNAME,20}\n";
            }

            return result;
        }
    }
}
