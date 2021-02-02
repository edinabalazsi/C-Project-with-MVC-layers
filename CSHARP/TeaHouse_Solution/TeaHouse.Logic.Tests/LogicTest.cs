// <copyright file="LogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TeaHouse.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using TeaHouse.Data;
    using TeaHouse.Repository;

    /// <summary>
    /// LogicTest is the main class which handles Tests for the Logic class.
    /// </summary>
    [TestFixture]
    public class LogicTest
    {
        private Mock<IExtraRepository> extrarepo;
        private Mock<ISupplierRepository> supplierrepo;
        private Mock<ITeaRepository> tearepo;
        private Mock<ITealeafRepository> tealeafrepo;
        private RepositoryHelper repohelper;
        private Logic logic;

        /// <summary>
        /// Initializes the helper and the logic before tests.
        /// </summary>
        [SetUp]
        public void Init()
        {
            this.extrarepo = new Mock<IExtraRepository>();
            this.supplierrepo = new Mock<ISupplierRepository>();
            this.tearepo = new Mock<ITeaRepository>();
            this.tealeafrepo = new Mock<ITealeafRepository>();

            List<EXTRA> mockedextras = new List<EXTRA>();
            mockedextras.Add(new EXTRA() { EXT_ID = 311, ENAME = "CowMilk", CATEGORY = "MILKTYPE", ALLERGEN = "ALLERGY", AVAILABLE = true, PRICE = 200 });
            mockedextras.Add(new EXTRA() { EXT_ID = 312, ENAME = "Sugar", CATEGORY = "SWEETENER", ALLERGEN = "NONE", AVAILABLE = false, PRICE = 80 });
            mockedextras.Add(new EXTRA() { EXT_ID = 313, ENAME = "CoconutMilk", CATEGORY = "MILKTYPE", ALLERGEN = "ALLERGY", AVAILABLE = false, PRICE = 100 });
            mockedextras.Add(new EXTRA() { EXT_ID = 314, ENAME = "RiceMilk", CATEGORY = "MILKTYPE", ALLERGEN = "NONE", AVAILABLE = true, PRICE = 120 });
            mockedextras.Add(new EXTRA() { EXT_ID = 315, ENAME = "E-Extra", CATEGORY = "OTHER", ALLERGEN = "ALLERGY", AVAILABLE = true, PRICE = 60 });

            List<SUPPLIER> mockedsuppliers = new List<SUPPLIER>();
            mockedsuppliers.Add(new SUPPLIER() { SUP_ID = 411, SNAME = "Supplier Sam", STREET = "Some street", CITY = "Springfield", ORDER_STATUS = "Pending", ORDERSTOTAL = 20 });
            mockedsuppliers.Add(new SUPPLIER() { SUP_ID = 412, SNAME = "Supplier Sandy", STREET = "Other street", CITY = "Cleveland", ORDER_STATUS = "Completed", ORDERSTOTAL = 13 });
            mockedsuppliers.Add(new SUPPLIER() { SUP_ID = 413, SNAME = "Supplier Susan", STREET = "Elm street", CITY = "Quahog", ORDER_STATUS = "Pending", ORDERSTOTAL = 5 });

            List<TEA> mockedteas = new List<TEA>();
            mockedteas.Add(new TEA() { TEA_ID = 111, TEANAME = "Earl Grey", QUANTITY = 300, BASEPRICE = 360, SALES = 5, TOTAL = 12 });
            mockedteas.Add(new TEA() { TEA_ID = 112, TEANAME = "Pickwick", QUANTITY = 250, BASEPRICE = 300, SALES = 3, TOTAL = 20 });
            mockedteas.Add(new TEA() { TEA_ID = 113, TEANAME = "Lipton", QUANTITY = 400, BASEPRICE = 600, SALES = 11, TOTAL = 22 });
            mockedteas.Add(new TEA() { TEA_ID = 114, TEANAME = "Loyd", QUANTITY = 450, BASEPRICE = 550, SALES = 9, TOTAL = 16 });
            mockedteas.Add(new TEA() { TEA_ID = 115, TEANAME = "Xixo", QUANTITY = 300, BASEPRICE = 300, SALES = 7, TOTAL = 18 });

            List<TEALEAF> mockedtealeaves = new List<TEALEAF>();
            mockedtealeaves.Add(new TEALEAF() { TL_ID = 211, TLNAME = "Greentea", VARIETY = "GREEN", BRAND = "LOOSE", ACIDITY = "MEDIUM", FLAVOUR = "None", REGION = "Russian"});
            mockedtealeaves.Add(new TEALEAF() { TL_ID = 212, TLNAME = "Blacktea", VARIETY = "BLACK", BRAND = "FAIR TRADE", ACIDITY = "HIGH", FLAVOUR = "Rose", REGION = "Chinese" });
            mockedtealeaves.Add(new TEALEAF() { TL_ID = 213, TLNAME = "Lavender", VARIETY = "OOLONG", BRAND = "ORGANIC", ACIDITY = "LOW", FLAVOUR = "Herbs", REGION = "Hungarian" });
            mockedtealeaves.Add(new TEALEAF() { TL_ID = 214, TLNAME = "Camomile", VARIETY = "GREEN", BRAND = "ORGANIC", ACIDITY = "LOW", FLAVOUR = "Herbs", REGION = "Hungarian" });
            mockedtealeaves.Add(new TEALEAF() { TL_ID = 215, TLNAME = "Whitetea", VARIETY = "WHITE", BRAND = "LOOSE", ACIDITY = "MEDIUM", FLAVOUR = "Fruit", REGION = "Taiwanese" });

            this.extrarepo.Setup(r => r.GetAll()).Returns(mockedextras.AsQueryable<EXTRA>());
            this.supplierrepo.Setup(r => r.GetAll()).Returns(mockedsuppliers.AsQueryable<SUPPLIER>());
            this.tearepo.Setup(r => r.GetAll()).Returns(mockedteas.AsQueryable<TEA>());
            this.tealeafrepo.Setup(r => r.GetAll()).Returns(mockedtealeaves.AsQueryable<TEALEAF>());

            this.repohelper = new RepositoryHelper(this.extrarepo.Object, this.supplierrepo.Object, this.tealeafrepo.Object, this.tearepo.Object);
            this.logic = new Logic(this.repohelper);
        }

        /// <summary>
        /// Tester method for GetAllTableNames method.
        /// </summary>
        [Test]
        public void GetAllTableNamesTest()
        {
            var data = this.logic.GetAllTableNames();
            Assert.That(data.Count == 5);
            Assert.That(data.Contains("EXTRA") && data.Contains("SUPPLIER") && data.Contains("TEA") && data.Contains("TEALEAF"));
        }

        /// <summary>
        /// Tester method for CreateExtra method.
        /// </summary>
        [Test]
        public void CreateExtraTest()
        {
            string data = "EXTRA;316;PlusExtra;Other;None;true;65";
            this.logic.CreateExtra(data);
            this.extrarepo.Verify(e => e.Create(data), It.IsAny<string>());
        }

        /// <summary>
        /// Tester method for CreateSupplier method.
        /// </summary>
        [Test]
        public void CreateSupplierTest()
        {
            string data = "SUPPLIER;414;Supplier Boyz;Back street;Alabama;Pending;65";
            this.logic.CreateSupplier(data);
            this.supplierrepo.Verify(s => s.Create(data), It.IsAny<string>());
        }

        /// <summary>
        /// Tester method for CreateTea method.
        /// </summary>
        [Test]
        public void CreateTeaTest()
        {
            string data = "TEA;116;Mockedtea;250;399;3;13";
            this.logic.CreateTea(data);
            this.tearepo.Verify(t => t.Create(data), It.IsAny<string>());
        }

        /// <summary>
        /// Tester method for CreateTealeaf method.
        /// </summary>
        [Test]
        public void CreateTealeafTest()
        {
            string data = "TEALEAF;216;Mockedleaf;Black;Loose;Medium;Fake;Neverland";
            this.logic.CreateTealeaf(data);
            this.tealeafrepo.Verify(tl => tl.Create(data), It.IsAny<string>());
        }

        /// <summary>
        /// Tester method for ReadExtra method.
        /// </summary>
        [Test]
        public void ReadExtraTest()
        {
            this.logic.ReadExtra();
            this.extrarepo.Verify(e => e.Read(), Times.Once);
        }

        /// <summary>
        /// Tester method for ReadSupplier method.
        /// </summary>
        [Test]
        public void ReadSupplierTest()
        {
            this.logic.ReadSupplier();
            this.supplierrepo.Verify(s => s.Read(), Times.Once);
        }

        /// <summary>
        /// Tester method for ReadTea method.
        /// </summary>
        [Test]
        public void ReadTeaTest()
        {
            this.logic.ReadTea();
            this.tearepo.Verify(t => t.Read(), Times.Once);
        }

        /// <summary>
        /// Tester method for ReadTealeaf method.
        /// </summary>
        [Test]
        public void ReadTealeafTest()
        {
            this.logic.ReadTealeaf();
            this.tealeafrepo.Verify(tl => tl.Read(), Times.Once);
        }

        /// <summary>
        /// Tester method for UpdateExtra method.
        /// </summary>
        [Test]
        public void UpdateExtraTest()
        {
            string data = "EXTRA;311;ALLERGEN;lactose";
            this.logic.UpdateExtra(data);
            this.extrarepo.Verify(e => e.Update(data), Times.Once);
        }

        /// <summary>
        /// Tester method for UpdateSupplier method.
        /// </summary>
        [Test]
        public void UpdateSupplierTest()
        {
            string data = "SUPPLIER;411;STREET;Any street";
            this.logic.UpdateSupplier(data);
            this.supplierrepo.Verify(s => s.Update(data), Times.Once);
        }

        /// <summary>
        /// Tester method for UpdateTea method.
        /// </summary>
        [Test]
        public void UpdateTeaTest()
        {
            string data = "TEA;115;SALES;10";
            this.logic.UpdateTea(data);
            this.tearepo.Verify(t => t.Update(data), Times.Once);
        }

        /// <summary>
        /// Tester method for UpdateTealeaf method.
        /// </summary>
        [Test]
        public void UpdateTealeafTest()
        {
            string data = "TEALEAF;215;REGION;English";
            this.logic.UpdateTealeaf(data);
            this.tealeafrepo.Verify(tl => tl.Update(data), Times.Once);
        }

        /// <summary>
        /// Tester method for DeleteExtra method.
        /// </summary>
        [Test]
        public void DeleteExtraTest()
        {
            string data = "EXTRA;311";
            this.logic.DeleteExtra(data);
            this.extrarepo.Verify(e => e.Delete(data), Times.Once);
        }

        /// <summary>
        /// Tester method for DeleteSupplier method.
        /// </summary>
        [Test]
        public void DeleteSupplierTest()
        {
            string data = "SUPPLIER;412";
            this.logic.DeleteSupplier(data);
            this.supplierrepo.Verify(s => s.Delete(data), Times.Once);
        }

        /// <summary>
        /// Tester method for DeleteTea method.
        /// </summary>
        [Test]
        public void DeleteTeaTest()
        {
            string data = "TEA;113";
            this.logic.DeleteTea(data);
            this.tearepo.Verify(t => t.Delete(data), Times.Once);
        }

        /// <summary>
        /// Tester method for DeleteTealeaf method.
        /// </summary>
        [Test]
        public void DeleteTealeafTest()
        {
            string data = "TEALEAF;214";
            this.logic.DeleteTealeaf(data);
            this.tealeafrepo.Verify(tl => tl.Delete(data), Times.Once);
        }

        /// <summary>
        /// Tester method for TealeafBrandsOrdered method.
        /// </summary>
        [Test]
        public void TealeafBrandsOrderedTest()
        {
            this.logic.TealeafBrandsOrdered();
            this.tealeafrepo.Verify(tl => tl.TealeafBrandsOrdered(), Times.Once);
        }

        /// <summary>
        /// Tester method for TealeavesBySuppliers method.
        /// </summary>
        [Test]
        public void TealeavesBySuppliersTest()
        {
            this.logic.TealeavesBySuppliers();
            this.tealeafrepo.Verify(tl => tl.TealeavesBySuppliers(), Times.Once);
        }

        /// <summary>
        /// Tester method for ExtrasAvailability method.
        /// </summary>
        [Test]
        public void ExtrasAvailability()
        {
            this.logic.ExtrasAvailability();
            this.extrarepo.Verify(e => e.ExtrasAvailability(), Times.Once);
        }
    }
}
