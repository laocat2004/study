/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Study.Autofac
 创 建 人：hxfsp
 创建日期：2016/8/9 23:44:36
 用    途：
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Study.Resposity;

namespace Study.Autofac.ThreeIOCType
{
    public class ProductService:IProductService
    {
        public readonly string Name = "ProductService";
        public ProductResp Resp { get; set; }

        public string GetProductReso()
        {
            return Resp.GetProductResp();
        }
    }
}