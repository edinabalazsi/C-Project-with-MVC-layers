// <copyright file="Operator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TeaHouse.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using TeaHouse.Logic;

    /// <summary>
    /// This is the class which handles the display and base functions of the menu.
    /// </summary>
    internal class Operator
    {
        private static ILogic consoleLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Operator"/> class.
        /// </summary>
        public Operator()
        {
            this.ESCbutton += this.Operator_ESCbutton;
        }

        /// <summary>
        /// Delegate for pressing ESC button in SubMenus.
        /// </summary>
        /// <param name="sender">The object which sends the event.</param>
        /// <param name="e">Event parameter.</param>
        public delegate void ESCEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Pressing ESC button eventHandler
        /// </summary>
        public event ESCEventHandler ESCbutton;

        /// <summary>
        /// Generates a singleton of ConsoleLogic.
        /// </summary>
        /// <returns>Logic instance.</returns>
        public static Logic GetConsoleLogic()
        {
            if (consoleLogic == null)
            {
                consoleLogic = new Logic();
            }

            return (Logic)consoleLogic;
        }

        /// <summary>
        /// MainMenu method.
        /// </summary>
        public void MainMenu()
        {
            Console.Clear();
            Console.Write("Welcome! Choose one of the following options:\n" +
                           "[1] Create\n" +
                           "[2] Read\n" +
                           "[3] Update\n" +
                           "[4] Delete\n" +
                           "[5] Listing TeaLeaves' brands in order of frequency\n" +
                           "[6] Get how many Extras are available\n" +
                           "[7] Listing which TeaLeaf supply belongs to which supplier\n" +
                           "[8] Java/web interaction\n");
            string s = Console.ReadLine();
            int.TryParse(s, out int button);
            switch (button)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Please give the table name in which you want to create a new record:\n" +
                                      "(TEA, TEALEAF, EXTRA, SUPPLIER)");
                    this.SupportCreateOption(Console.ReadLine().ToUpper());
                    Console.WriteLine("Press ESC for main menu");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        this.OnESCbutton(null);
                    }

                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Please give the table name you want to view:\n" +
                                      "(TEA, TEALEAF, EXTRA, SUPPLIER)");
                    this.SupportReadOption(Console.ReadLine().ToUpper());
                    Console.WriteLine("Press ESC for main menu");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        this.OnESCbutton(null);
                    }

                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Please give the table name in which you want to update a record:\n" +
                                      "(TEA, TEALEAF, EXTRA, SUPPLIER)");
                    string viewUpdateTable = Console.ReadLine().ToUpper();
                    this.SupportReadOption(viewUpdateTable);
                    Console.WriteLine("Enter the ID of the record you want to update, the type and the new value separated by a semicolon:\n" +
                                       "(ID;TYPE;VALUE)");
                    string updateData = viewUpdateTable + ";" + Console.ReadLine();
                    this.SupportUpdateOption(updateData);
                    Console.WriteLine("Press ESC for main menu");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        this.OnESCbutton(null);
                    }

                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Please give the table name in which you want to delete a record:\n" +
                                      "(TEA, TEALEAF, EXTRA, SUPPLIER)");
                    string viewDeleteTable = Console.ReadLine().ToUpper();
                    this.SupportReadOption(viewDeleteTable);
                    Console.WriteLine("Give the ID of the record you want to delete:");
                    string deleteData = viewDeleteTable + ";" + Console.ReadLine();
                    this.SupportDeleteOption(deleteData);
                    Console.WriteLine("Press ESC for main menu");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        this.OnESCbutton(null);
                    }

                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Tealeaves’ brands in order of frequency:\n");
                    Console.WriteLine(GetConsoleLogic().TealeafBrandsOrdered());
                    Console.WriteLine("Press ESC for main menu");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        this.OnESCbutton(null);
                    }

                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Availability of the extras:\n");
                    Console.WriteLine(GetConsoleLogic().ExtrasAvailability());
                    Console.WriteLine("Press ESC for main menu");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        this.OnESCbutton(null);
                    }

                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Tealeaves grouped by Suppliers");
                    Console.WriteLine(GetConsoleLogic().TealeavesBySuppliers());
                    Console.WriteLine("Press ESC for main menu");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        this.OnESCbutton(null);
                    }

                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Java/web interaction");
                    XDocument xdoc = XDocument.Load(@"http://localhost:8080/TeaHouse_Solution/AllTeaServlet");
                    Console.WriteLine(xdoc);

                    Console.WriteLine("Press ESC for main menu");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        this.OnESCbutton(null);
                    }

                    break;
                default:
                    Console.WriteLine("Only numbers between 1-8 are allowed!");
                    Console.ReadKey();
                    this.MainMenu();

                    break;
            }
        }

        /// <summary>
        /// Method for calling event.
        /// </summary>
        /// <param name="e">Event parameter.</param>
        protected virtual void OnESCbutton(EventArgs e)
        {
            this.ESCbutton?.Invoke(this, e);
        }

        /// <summary>
        /// ManMenu method on ESC event.
        /// </summary>
        /// <param name="sender">The object which sends the event.</param>
        /// <param name="e">Event parameter.</param>
        private void Operator_ESCbutton(object sender, EventArgs e)
        {
            this.MainMenu();
        }

        /// <summary>
        /// Supports Create option with different cases depending on which table is selected.
        /// </summary>
        /// <param name="tableName">String containing the selected table name.</param>
        private void SupportCreateOption(string tableName)
        {
            string s = tableName + ";";
            switch (tableName)
            {
                case "TEA":
                    GetConsoleLogic().ReadTea();
                    Console.WriteLine("Add new tea's data separated by semicolons like the following example:\n" +
                                      "TeaID;TeaName;Quantity;BasePrice;Sales;Total\n");
                    s += Console.ReadLine();
                    GetConsoleLogic().CreateTea(s);
                    break;

                case "TEALEAF":
                    Console.WriteLine("Add new tealeaf's data separated by semicolons like the following example:\n" +
                                      "TealeafID;TealeafName;Variety;Brand;Acidity;Flavour;Region\n");
                    s += Console.ReadLine();
                    GetConsoleLogic().CreateTealeaf(s);
                    break;

                case "EXTRA":
                    Console.WriteLine("Add new extra's data separated by semicolons like the following example:\n" +
                                      "ExtraID;ExtraName;Category;Allergen;Availability;Price\n");
                    s += Console.ReadLine();
                    GetConsoleLogic().CreateExtra(s);
                    break;
                case "SUPPLIER":
                    Console.WriteLine("Add new supplier's data separated by semicolons like the following example:\n" +
                                      "SupplierID;SupplierName;Street;City;OrderStatus;TotalOrders\n");
                    s += Console.ReadLine();
                    GetConsoleLogic().CreateSupplier(s);
                    break;
                default: Console.WriteLine("Invalid table name!\n Tables: TEA, TEALEAF, EXTRA, SUPPLIER");
                    break;
            }
        }

        /// <summary>
        /// Supports Read option with different cases depending on which table is selected.
        /// </summary>
        /// <param name="tableName">String containing the selected table name.</param>
        private void SupportReadOption(string tableName)
        {
            switch (tableName)
            {
                case "TEA":
                    Console.WriteLine(GetConsoleLogic().ReadTea());
                    break;

                case "TEALEAF":
                    Console.WriteLine(GetConsoleLogic().ReadTealeaf());
                    break;

                case "EXTRA":
                    Console.WriteLine(GetConsoleLogic().ReadExtra());
                    break;

                case "SUPPLIER":
                    Console.WriteLine(GetConsoleLogic().ReadSupplier());

                    break;
                default: Console.WriteLine("Invalid table name!\n Tables: TEA, TEALEAF, EXTRA, SUPPLIER");
                    break;
            }
        }

        /// <summary>
        /// Supports Update option with different cases depending on which table is selected.
        /// </summary>
        /// <param name="updateValues">String containing the table name and the ID, Type and Value of the updated record.</param>
        private void SupportUpdateOption(string updateValues)
        {
            string[] s = updateValues.Split(';');
            switch (s[0])
            {
                case "TEA":
                    GetConsoleLogic().UpdateTea(updateValues);
                    Console.WriteLine($"The {s[0]} table has been updated!");
                    break;

                case "TEALEAF":
                    GetConsoleLogic().UpdateTealeaf(updateValues);
                    Console.WriteLine($"The {s[0]} table has been updated!");
                    break;

                case "EXTRA":
                    GetConsoleLogic().UpdateExtra(updateValues);
                    Console.WriteLine($"The {s[0]} table has been updated!");
                    break;
                case "SUPPLIER":
                    GetConsoleLogic().UpdateSupplier(updateValues);
                    Console.WriteLine($"The {s[0]} table has been updated!");
                    break;
                default:
                    Console.WriteLine("Invalid table name!\n Tables: TEA, TEALEAF, EXTRA, SUPPLIER");
                    break;
            }
        }

        /// <summary>
        /// Supports Delete option with different cases depending on which table is selected.
        /// </summary>
        /// <param name="deleteValues">String containing the table and ID of the deleted record.</param>
        private void SupportDeleteOption(string deleteValues)
        {
            string[] s = deleteValues.Split(';');
            switch (s[0])
            {
                case "TEA":
                    GetConsoleLogic().DeleteTea(deleteValues);
                    Console.WriteLine($"The [{s[1]}] record has been deleted from {s[0]} table!");
                    break;

                case "TEALEAF":
                    GetConsoleLogic().DeleteTealeaf(deleteValues);
                    Console.WriteLine($"The [{s[1]}] record has been deleted from {s[0]} table!");
                    break;

                case "EXTRA":
                    GetConsoleLogic().DeleteExtra(deleteValues);
                    Console.WriteLine($"The [{s[1]}] record has been deleted from {s[0]} table!");
                    break;
                case "SUPPLIER":
                    GetConsoleLogic().DeleteSupplier(deleteValues);
                    Console.WriteLine($"The [{s[1]}] record has been deleted from {s[0]} table!");
                    break;
                default:
                    Console.WriteLine("Invalid table name!\n Tables: TEA, TEALEAF, EXTRA, SUPPLIER");
                    break;
            }
        }
    }
}
