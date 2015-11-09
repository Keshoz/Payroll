using System;
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
        public void TestEmployeeToString()
        {
            int empId = 1;
            Employee e = new Employee(empId, "Bob", "Home");

            StringBuilder builder = new StringBuilder();
            builder.Append("Emp#: ").Append(empId).Append(" ");
            builder.Append("Bob").Append(" ");
            builder.Append("Home").Append(" ");
            builder.Append("Paid ").Append(e.Classification).Append(" ");
            builder.Append(e.Schedule);
            builder.Append(" by ").Append(e.Method);

            Assert.AreEqual(e.ToString(), builder.ToString());
        }
        //[TestMethod]
        //public void TestAddSalariedEmployee()
        //{
        //    //int empId = 1;
        //    //AddSalariedEmployee t = new AddSalariedEmployee(empId,"Bob","Home",1000.00)
        //    //Employee e = new Employee(empId, "Bob", "Home");
        //    //Assert.AreEqual("Bob", e.Name);
        //    //Assert.AreEqual("Home", e.Address);
        //    //Assert.AreEqual(empId, e.EmpId);
        //}
    }
}
