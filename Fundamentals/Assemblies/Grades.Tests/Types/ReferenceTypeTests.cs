using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class ReferenceTypeTests
    {

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;

        }

        //immutability example
        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2017, 02, 02);
            date.AddDays(1);

            Assert.AreEqual(3, date.Day);
        }

        //immutability example
        [TestMethod]
        public void UppercaseString()
        {
            string name = "scott";
            name.ToUpper();
            Assert.AreEqual("SCOTT", name);
        }

        //ref example
        [TestMethod]
        public void refExample()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookANameforRef(ref book2);
            Assert.AreEqual("Kumar Book", book2.Name);
        }

        private void GiveBookANameforRef(ref GradeBook book)
        {
            book.Name = "Kumar Book";
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(x);

            Assert.AreEqual(x, 46);
        }

        private void IncrementNumber(int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual(book1.Name, book2.Name);

        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "Kumar Book";
        }


        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Kumar";
            string name2 = "kumar";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            
            g1.Name = "Kumar's grade book";
            Assert.AreEqual(g1.Name, g2.Name);
        }

        [TestMethod]
        public void IntVariablesHoldeValue()
        {
            int x1 = 100;
            int x2 = x1;
            x1 = 4;
            Assert.AreEqual(x1, x2);
        }
       
        
    }
}
