using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Chopi.Modules.Share.Test
{
    [TestClass]
    public class DataRequestCollection_SetOrderingTest
    {
        [TestMethod]
        public void SetExpression_Set_Null_Ctor_Null()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, string.Empty);
            request.SetOrdering(null);
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void SetExpression_Check_And_Set_Null_Ctor_Null()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, string.Empty);
            var boolResult = request.IsSetOrdering();
            request.SetOrdering(null);
            var result = request.GetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void SetExpression_Set_Null_Ctor_Params_Express()
        {
            var request = new DataRequestCollection<Poco>(0, 20, null, e => e.OrderBy(z => z.Name));
            request.SetOrdering(null);
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void SetExpression_Set_Null_Ctor_Params_String()
        {
            var request = new DataRequestCollection<Poco>(0, 20, null, "e => e.OrderBy(z => z.Name)");
            request.SetOrdering(null);
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void SetExpression_Set_NormalExpress()
        {
            var request = new DataRequestCollection<Poco>(0, 20, string.Empty, string.Empty);
            request.SetOrdering(e => e.OrderBy(s => s.Name));
            var result = request.GetOrdering();
            var boolResult = request.IsSetOrdering();
            Assert.IsNotNull(result);
            Assert.IsTrue(boolResult);
        }
    }
}
