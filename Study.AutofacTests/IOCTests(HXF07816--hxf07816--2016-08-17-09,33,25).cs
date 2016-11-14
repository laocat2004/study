using Microsoft.VisualStudio.TestTools.UnitTesting;
using Study.Autofac.ThreeIOCType;
/*======================================================================
Copyright (c) 同程网络科技股份有限公司. All rights reserved.
所属项目：Study.AutofacTests.ThreeIOCType
创 建 人：hxfsp
创建日期：2016/8/9 23:52:12
用    途：
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.AutofacTests
{
    [TestClass()]
    public class IOCTests
    {
        [TestMethod()]
        public void ConstructInjectTest()
        {
            var productService=ProductTest.ConstructInject();
            Assert.IsNotNull(productService);
        }

        [TestMethod()]
        public void PropertyInjectTest()
        {
            var productService = ProductTest.PropertyInject();
            Assert.IsNotNull(productService);
        }

        [TestMethod]
        public void MethodInjectTest()
        {
            //var productController = ProductTest.MethodInject();
            //Assert.IsNotNull(productController);
        }
    }
}