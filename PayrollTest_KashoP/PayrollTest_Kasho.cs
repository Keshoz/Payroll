﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll_Kasho;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PayrollTest_KashoP
{
    [TestClass]
    public class PayrollTest_Kasho
    {
        [TestMethod]
        public void TestEmployee()
        {
            int empId = 1;
            Employee e = new Employee(empId, "Bob", "Home");
            Assert.AreEqual("Bob",e.Name);
            Assert.AreEqual("Home",e.Address);
            Assert.AreEqual(empId,e.EmpId);
        }


        [TestMethod]

        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }
        [TestMethod]

        public void TestAddHourlyEmployee()
        {
            int empId = 1;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob", "Home", 24);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification sc = pc as HourlyClassification;
            Assert.AreEqual(24, sc.HourlyRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [TestMethod]

        public void TestAddCommissionedEmployee()
        {
            int empId = 1;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bob", "Home", 1000.00, 0.50);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification sc = pc as CommissionedClassification;
            Assert.AreEqual(1000, sc.Salary, .001);
            Assert.AreEqual(0.50, sc.CommissionRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }
    }
}

