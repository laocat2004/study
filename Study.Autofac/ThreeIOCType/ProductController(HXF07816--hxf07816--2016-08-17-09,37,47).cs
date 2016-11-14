/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Study.Autofac
 创 建 人：hxfsp
 创建日期：2016/8/9 23:46:14
 用    途：
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.Autofac.ThreeIOCType
{
    public class ProductController
    {
        public string Name = "ProductController";
        /// <summary>
        /// 属性注入必须为public 
        /// </summary>
        public IProductService ProductService { get; set; }

        //简单构造器注入
        //private ProductService _productService;
        //public ProductController(ProductService productService)
        //{
        //    _productService = productService;
        //}
        public IProductService GetProductService()
        {
            return ProductService;
        }

        //接口构造器注入
        //private IProductService _iproductService;
        //public ProductController(IProductService productService)
        //{
        //    _iproductService = productService;
        //}
        //public IProductService GetIProductService()
        //{
        //    return _iproductService;
        //}

    }
}