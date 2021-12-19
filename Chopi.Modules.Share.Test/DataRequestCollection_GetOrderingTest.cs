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
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, "");
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_2()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, "w");
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_3()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, "w =>");
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_4()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, "w => w.ToString()");
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_5()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, "w => w.ToString() == string.Empty");
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_6()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, "w => w.OrderBy()");
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_7()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, "w => w.OrderBy(e)");
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNull_WithStringParams_8()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, "w => w.OrderBy(e)");
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNotNull_WithStringParams_1()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, "s => s.OrderBy(e => e.Name)");

            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();

            Assert.IsNotNull(result);
            Assert.IsTrue(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNotNull_WithStringParams_2()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, "s => s.OrderByDescending(e => e.Name)");

            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();

            Console.WriteLine("res: " + result);
            Console.WriteLine("boolResult: " + boolResult);

            Assert.IsNotNull(result);
            Assert.IsTrue(boolResult);
        }

        [TestMethod]
        public void GetOrdering_Ctor_IsNotNull_WithStringParams_3()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, "w => w.OrderBy(e => e)");
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNotNull(result);
            Assert.IsTrue(boolResult);
        }
    }
}
