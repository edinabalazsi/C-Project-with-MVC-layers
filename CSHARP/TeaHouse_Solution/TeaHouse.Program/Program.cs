// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TeaHouse.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Program starts here.
    /// </summary>
    internal class Program
    {
        private static Operator op;

        /// <summary>
        /// This is where the program launches.
        /// </summary>
        /// <param name="args">arguments.</param>
        public static void Main(string[] args)
        {
            op = new Operator();
            op.MainMenu();
        }
    }
}
