using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Chopi.Modules.Share.Test
{
    [TestClass]
    public class DataRequest_SetExpressionTest
    {
        [TestMethod]
        public void SetExpression_Set_Null_Ctor_Null()
        {
            var request = new DataRequest<Poco>(string.Empty);
            request.SetExpression(null);
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public async Task SetExpression_Set_Null_Ctor_Null_Async()
        {
            var request = new DataRequest<Poco>(string.Empty);
            await Task.Run(() => request.SetExpression(null));
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void SetExpression_Check_And_Set_Null_Ctor_Null()
        {
            var request = new DataRequest<Poco>(string.Empty);
            var boolResult = request.IsSetExpression();
            request.SetExpression(null);
            var result = request.GetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public async Task SetExpression_Check_And_Set_Null_Ctor_Null_Async()
        {
            var request = new DataRequest<Poco>(string.Empty);
            var boolResult = request.IsSetExpression();
            await Task.Run(() => request.SetExpression(null));
            var result = request.GetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void SetExpression_Set_Null_Ctor_Params_Express()
        {
            var request = new DataRequest<Poco>(e => e.Name == "123");
            request.SetExpression(null);
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void SetExpression_Set_Null_Ctor_Params_String()
        {
            var request = new DataRequest<Poco>("e => e.Name == \"123\"");
            request.SetExpression(null);
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNull(result);
            Assert.IsFalse(boolResult);
        }

        [TestMethod]
        public void SetExpression_Set_NormalExpress()
        {
            var request = new DataRequest<Poco>(string.Empty);
            request.SetExpression(e => e.Name == "123");
            var result = request.GetExpression();
            var boolResult = request.IsSetExpression();
            Assert.IsNotNull(result);
            Assert.IsTrue(boolResult);
        }
    }
}
