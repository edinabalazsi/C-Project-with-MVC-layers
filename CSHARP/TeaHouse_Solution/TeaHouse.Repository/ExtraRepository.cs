// <copyright file="ExtraRepository.cs" company="PlaceholderCompany">
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
    /// Handles the extra's repository functions.
    /// </summary>
    public class ExtraRepository : IExtraRepository
    {

        /// <summary>
        /// Creates a new EXTRA element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to create a new row separated by semicolons.</param>
        public void Create(string s)
        {
            string[] data = s.Split(';');
            EXTRA newextra = new EXTRA()
            {
                EXT_ID = int.Parse(data[1]),
                ENAME = data[2],
                CATEGORY = data[3],
                ALLERGEN = data[4],
                AVAILABLE = bool.Parse(data[5]),
                PRICE = int.Parse(data[6])
            };
            DatabaseHandler.Instance.AddNewExtra(newextra);
            DatabaseHandler.Instance.SaveDB();
        }

        /// <summary>
        /// Deletes an EXTRA element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the ID of the deleted element.</param>
        public void Delete(string s)
        {
            string[] data = s.Split(';');
            int id = int.Parse(data[1]);
            EXTRA delextra = this.GetAll().Single(x => x.EXT_ID == id);
            DatabaseHandler.Instance.DeleteExtra(delextra);
            DatabaseHandler.Instance.SaveDB();
        }

        /// <summary>
        /// Returns EXTRA table's values as a query.
        /// </summary>
        /// <returns>EXTRA table as a query.</returns>
        public IQueryable<EXTRA> GetAll()
        {
            return DatabaseHandler.Instance.GetAllExtras().AsQueryable();
        }

        /// <summary>
        /// Returns a formatted string containing the EXTRA table's data.
        /// </summary>
        /// <returns>the EXTRA table's data as a string.</returns>
        public string Read()
        {
            string readTable = "EXT_ID\tENAME\tCATEGORY\tALLERGEN\tAVAILABLE\tPRICE\n";
            foreach (var item in this.GetAll())
            {
                readTable += $"{item.EXT_ID}\t{item.ENAME}\t{item.CATEGORY}\t{item.ALLERGEN}\t{item.AVAILABLE}\t{item.PRICE}\n";
            }

            return readTable;
        }

        /// <summary>
        /// Updates an EXTRA element with the given parameter.
        /// </summary>
        /// <param name="s">String containing the required values to update a row separated by semicolons.</param>
        public void Update(string s)
        {
            string[] data = s.Split(';');
            int id = int.Parse(data[1]);
            EXTRA updateExtra = this.GetAll().Single(x => x.EXT_ID == id);
            string typeCase = data[2].ToUpper();
            switch (typeCase)
            {
                case "ENAME":
                    updateExtra.ENAME = data[3];
                    break;
                case "CATEGORY":
                    updateExtra.CATEGORY = data[3];
                    break;
                case "ALLERGEN":
                    updateExtra.ALLERGEN = data[3];
                    break;
                case "AVAILABLE":
                    updateExtra.AVAILABLE = bool.Parse(data[3]);
                    break;
                case "PRICE":
                    updateExtra.PRICE = int.Parse(data[3]);
                    break;
                default: throw new NotImplementedException();
            }

            DatabaseHandler.Instance.SaveDB();
        }

        /// <summary>
        /// Get how many Extras are available.
        /// </summary>
        /// <returns>String containing the query's result.</returns>
        public string ExtrasAvailability()
        {
            string extrasavailability = string.Format("{0,-20} {1,-5}", "Extra's name", "Availability\n");
            var q1 = from x in this.GetAll()
                     select new { x.ENAME, x.AVAILABLE };
            foreach (var item in q1)
            {
                extrasavailability += $"{item.ENAME,-25}{item.AVAILABLE,-10}\n";
            }

            var q2 = from extra in this.GetAll()
                    group extra by extra.AVAILABLE into g
                    select new
                    {
                        Name = g.Key,
                        Count = g.Count()
                    };
            extrasavailability += "\n\n";
            foreach (var item in q2)
            {
                extrasavailability += $"{item.Name}: {item.Count}\n";
            }

            return extrasavailability;
        }

        /// <summary>
        /// Returns the selected extra by its id.
        /// </summary>
        /// <param name="id">The extra's id.</param>
        /// <returns>The extra object.</returns>
        public EXTRA GetExtraById(int id)
        {
            EXTRA selectedExtra = this.GetAll().Single(x => x.EXT_ID == id);
            return selectedExtra;
        }

        public bool RemoveExtra(int id)
        {
            EXTRA entity = this.GetExtraById(id);
            if (entity == null)
            {
                return false;
            }
            else
            {
                DatabaseHandler.Instance.DeleteExtra(entity);
                DatabaseHandler.Instance.SaveDB();
                return true;
            }
        }

        public void InsertExtra(string category, string extraName, string allergen, bool available, int price)
        {
            EXTRA newextra = new EXTRA()
            {
                ENAME =extraName,
                CATEGORY = category,
                ALLERGEN = allergen,
                AVAILABLE = available,
                PRICE = price,
            };
            DatabaseHandler.Instance.AddNewExtra(newextra);
            DatabaseHandler.Instance.SaveDB();
        }

        public bool ChangeExtra(int id, string category, string extraName, string allergen, bool available, int price)
        {
            EXTRA updateExtra = this.GetExtraById(id);
            if (updateExtra == null)
            {
                return false;
            }
            else
            {
                updateExtra.ENAME = extraName;
                updateExtra.CATEGORY = category;
                updateExtra.ALLERGEN = allergen;
                updateExtra.AVAILABLE = available;
                updateExtra.PRICE = price;

                DatabaseHandler.Instance.SaveDB();
                return true;
            }
        }
    }
}
