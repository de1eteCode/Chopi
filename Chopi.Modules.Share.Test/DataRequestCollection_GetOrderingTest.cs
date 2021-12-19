using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Chopi.Modules.Share.Test
{
    [TestClass]
    public class DataRequestCollection_GetOrderingTest
    {
        #region Ctor IsNull

        [TestMethod]
        public void GetOrdering_Ctor_TestParams_IsNull_1()
        {
            var request = new DataRequestCollection<Poco>(0, 20);
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_TestParams_IsNull_2()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, string.Empty);
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_TestParams_IsNull_3()
        {
            var request = new DataRequestCollection<Poco>(0, 20, (string)null, (string)null);
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_TestParams_IsNull_4()
        {
            var request = new DataRequestCollection<Poco>(0, 20, (Expression<Func<Poco, bool>>)null, (Expression<Func<IQueryable<Poco>, IOrderedQueryable<Poco>>>)null);
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        #endregion

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_1()
        {
            Test_Ctor_IsNull_WithStringParams("");
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_2()
        {
            Test_Ctor_IsNull_WithStringParams("w");
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_3()
        {
            Test_Ctor_IsNull_WithStringParams("w =>");
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_4()
        {
            Test_Ctor_IsNull_WithStringParams("w => w.ToString()");
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_5()
        {
            Test_Ctor_IsNull_WithStringParams("w => w.ToString() == string.Empty");
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_6()
        {
            Test_Ctor_IsNull_WithStringParams("w => w.OrderBy()");
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_7()
        {
            Test_Ctor_IsNull_WithStringParams("w => w.OrderBy(e)");
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_8()
        {
            Test_Ctor_IsNull_WithStringParams("w => w.OrderBy(\"e\")");
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_9()
        {
            Test_Ctor_IsNull_WithStringParams("w => w.OrderBy(\"e => e\")");
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNotNull_WithStringParams_1()
        {
            Test_Ctor_IsNotNull_WithStringParams("w => w.OrderBy(\"e => e.Name\")");
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNotNull_WithStringParams_2()
        {
            Test_Ctor_IsNotNull_WithStringParams("w => w.OrderByDescending(\"e => e.Name\")");
        }

        private void Test_Ctor_IsNull_WithStringParams(string expr)
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, expr);
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }
        private void Test_Ctor_IsNotNull_WithStringParams(string expr)
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, expr);
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNotNull(result);
            Assert.IsTrue(boolResult);
        }
    }
}
