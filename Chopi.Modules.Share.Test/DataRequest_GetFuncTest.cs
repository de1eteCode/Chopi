using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace Chopi.Modules.Share.Test
{
    [TestClass]
    public class DataRequest_GetFuncTest
    {
        #region IsNull

        [TestMethod]
        public void GetFunc_Ctor_IsNull_NoParams()
        {
            var request = new DataRequest<Poco>(0, 20);
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        #region String

        [TestMethod]
        public void GetFunc_Ctor_IsNull_WithStringParams_1()
        {
            var request = new DataRequest<Poco>(0, 20, string.Empty);
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetFunc_Ctor_IsNull_WithStringParams_2()
        {
            var request = new DataRequest<Poco>(0, 20, (string)null);
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetFunc_Ctor_IsNull_WithStringParams_3()
        {
            var request = new DataRequest<Poco>(0, 20, "e");
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetFunc_Ctor_IsNull_WithStringParams_4()
        {
            var request = new DataRequest<Poco>(0, 20, "e =>");
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetFunc_Ctor_IsNull_WithStringParams_5()
        {
            var request = new DataRequest<Poco>(0, 20, "e => e");
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetFunc_Ctor_IsNull_WithStringParams_6()
        {
            var request = new DataRequest<Poco>(0, 20, "e => e.ToString()");
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetFunc_Ctor_IsNull_WithStringParams_7()
        {
            var request = new DataRequest<Poco>(0, 20, "e => e.ToString() == string.Empty 1");
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetFunc_Ctor_IsNull_WithStringParams_8()
        {
            var request = new DataRequest<Poco>(0, 20, "e => e.ToString() == string.Empt");
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetFunc_Ctor_IsNull_WithStringParams_9()
        {
            var request = new DataRequest<Poco>(0, 20, "e => e.SomeMethod() == string.Empt");
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        #endregion

        #region Expression

        [TestMethod]
        public void GetFunc_Ctor_IsNull_WithExpressionParams_1()
        {
            var request = new DataRequest<Poco>(0, 20, (Expression<Func<Poco, bool>>)null);
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void GetFunc_Ctor_IsNull_WithExpressionParams_2()
        {
            Expression<Func<NotPoco, bool>> expression = e => true;
            object obj = expression;
            var request = new DataRequest<Poco>(0, 20, (Expression<Func<Poco, bool>>)obj);
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        #endregion

        #endregion

        #region IsNotNull

        #region String

        [TestMethod]
        public void GetFunc_Ctor_IsNotNull_WithStringParams_1()
        {
            var request = new DataRequest<Poco>(0, 20, "e => e.Name == string.Empty");
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNotNull(result);
            Assert.IsTrue(boolResult);
        }

        #endregion
        #region Expressions

        [TestMethod]
        public void GetFunc_Ctor_IsNotNull_WithExpressionParams_1()
        {
            var request = new DataRequest<Poco>(0, 20, e => e.Name == "123");
            var result = request.GetFunc();
            var boolResult = request.IsSetExpression();
            Assert.IsNotNull(result);
            Assert.IsTrue(boolResult);
        }

        #endregion

        #endregion
    }
}
