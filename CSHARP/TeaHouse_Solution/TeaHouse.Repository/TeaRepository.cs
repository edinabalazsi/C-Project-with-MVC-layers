// <copyright file="TeaRepository.cs" company="PlaceholderCompany">
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
    /// Handles tea's repository functions.
    /// </summary>
    public class TeaRepository : ITeaRepository
    {
        /// <summary>
        /// Creates a new TEA element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        public void Create(string s)
        {
            string[] data = s.Split(';');
            TEA newtea = new TEA()
            {
                TEA_ID = int.Parse(data[1]),
                TEANAME = data[2],
                QUANTITY = int.Parse(data[3]),
                BASEPRICE = int.Parse(data[4]),
                SALES = int.Parse(data[5]),
                TOTAL = int.Parse(data[6])
            };
            DatabaseHandler.Instance.AddNewTea(newtea);
            DatabaseHandler.Instance.SaveDB();
        }

        /// <summary>
        /// Deletes a TEA element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        public void Delete(string s)
        {
            string[] data = s.Split(';');
            int id = int.Parse(data[1]);
            TEA deltea = this.GetAll().Single(x => x.TEA_ID == id);
            DatabaseHandler.Instance.DeleteTea(deltea);
            DatabaseHandler.Instance.SaveDB();
        }

        /// <summary>
        /// Returns TEA table's values as a query.
        /// </summary>
        /// <returns>TEA table as a query.</returns>
        public IQueryable<TEA> GetAll()
        {
            return DatabaseHandler.Instance.GetAllTeas().AsQueryable();
        }

        /// <summary>
        /// Returns a formatted string containing the TEA table's data.
        /// </summary>
        /// <returns>the TEA table's data as a string.</returns>
        public string Read()
        {
            string readTable = "TEA_ID\tTEANAME\tQUANTITY\tBASEPRICE\tSALES\tTOTAL\n";
            foreach (var item in this.GetAll())
            {
                readTable += $"{item.TEA_ID}\t{item.TEANAME}\t{item.QUANTITY}\t{item.BASEPRICE}\t{item.SALES}\t{item.TOTAL}\n";
            }

            return readTable;
        }

        /// <summary>
        /// Updates a TEA element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        public void Update(string s)
        {
            string[] data = s.Split(';');
            int id = int.Parse(data[1]);
            TEA updatetea = this.GetAll().Single(x => x.TEA_ID == id);
            string typeCase = data[2].ToUpper();
            switch (typeCase)
            {
                case "TEANAME":
                    updatetea.TEANAME = data[3];
                    break;
                case "QUANTITY":
                    updatetea.QUANTITY = int.Parse(data[3]);
                    break;
                case "BASEPRICE":
                    updatetea.BASEPRICE = int.Parse(data[3]);
                    break;
                case "SALES":
                    updatetea.SALES = int.Parse(data[3]);
                    break;
                case "TOTAL":
                    updatetea.TOTAL = int.Parse(data[3]);
                    break;
                default: throw new NotImplementedException();
            }

            DatabaseHandler.Instance.SaveDB();
        }
    }
}
