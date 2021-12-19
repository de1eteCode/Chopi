using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Chopi.Modules.Share.Test
{
    [TestClass]
    public class DataRequest_GetExpressionTest
    {
        #region IsNull

        #region String

        [TestMethod]
        public void GetExpression_Ctor_IsNull_WithStringParams_1()
        {
            var request = new DataRequest<Poco>(string.Empty);
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetExpression_Ctor_IsNull_WithStringParams_2()
        {
            var request = new DataRequest<Poco>((string)null);
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetExpression_Ctor_IsNull_WithStringParams_3()
        {
            var request = new DataRequest<Poco>("e");
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetExpression_Ctor_IsNull_WithStringParams_4()
        {
            var request = new DataRequest<Poco>("e =>");
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetExpression_Ctor_IsNull_WithStringParams_5()
        {
            var request = new DataRequest<Poco>("e => e");
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetExpression_Ctor_IsNull_WithStringParams_6()
        {
            var request = new DataRequest<Poco>("e => e.ToString()");
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetExpression_Ctor_IsNull_WithStringParams_7()
        {
            var request = new DataRequest<Poco>("e => e.ToString() == string.Empty 1");
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetExpression_Ctor_IsNull_WithStringParams_8()
        {
            var request = new DataRequest<Poco>("e => e.ToString() == string.Empt");
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void GetExpression_Ctor_IsNull_WithStringParams_9()
        {
            var request = new DataRequest<Poco>("e => e.SomeMethod() == string.Empt");
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        #endregion

        #region Expression

        [TestMethod]
        public void GetExpression_Ctor_IsNull_WithExpressionParams_1()
        {
            var request = new DataRequest<Poco>((Expression<Func<Poco, bool>>)null);
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void GetExpression_Ctor_IsNull_WithExpressionParams_2()
        {
            Expression<Func<NotPoco, bool>> expression = e => true;
            object obj = expression;
            var request = new DataRequest<Poco>((Expression<Func<Poco, bool>>)obj);
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        #endregion

        #endregion

        #region IsNotNull

        #region String

        [TestMethod]
        public void GetExpression_Ctor_IsNotNull_WithStringParams_1()
        {
            var request = new DataRequest<Poco>("e => e.Name == string.Empty");
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNotNull(result);
            Assert.IsTrue(boolResult);
        }

        [TestMethod]
        public void GetExpression_Ctor_IsNotNull_WithStringParams_2()
        {
            var request = new DataRequest<Poco>("e => e.NotPocos.Where(ns => ns.NotName == \"123\").Count() > 1");
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();

            Console.WriteLine("result: " + result);
            Console.WriteLine("boolResult: " + boolResult);

            Assert.IsNotNull(result);
            Assert.IsTrue(boolResult);
        }

        #endregion

        #region Expressions

        [TestMethod]
        public void GetExpression_Ctor_IsNotNull_WithExpressionParams_1()
        {
            var request = new DataRequest<Poco>(e => e.Name == "123");
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNotNull(result);
            Assert.IsTrue(boolResult);
        }


        [TestMethod]
        public void GetExpression_Ctor_IsNotNull_WithExpressionParams_2()
        {
            var request = new DataRequest<Poco>(e => e.NotPocos.Where(ns => ns.NotName == "123").Count() > 1);
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();

            Console.WriteLine("expression: " + request.Expression);
            Console.WriteLine("result: " + result);
            Console.WriteLine("boolResult: " + boolResult);

            Assert.IsNotNull(result);
            Assert.IsTrue(boolResult);
        }

        #endregion

        #endregion
    }
}
