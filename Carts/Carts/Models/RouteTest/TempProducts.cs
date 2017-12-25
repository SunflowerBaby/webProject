﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carts.Models.RouteTest
{
    //商品模型類別
    public class TempProducts
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //取得目前所有商品的方法
        public static List<TempProducts> getAllproducts()
        {
            //初始化商品列表
            List<TempProducts> result = new List<TempProducts>();

            //加入三項商品
            result.Add(new TempProducts
            {
                ID = 1,
                Name = "自動鉛筆",
                Price = 30.0m
            });
            result.Add(new TempProducts
            {
                ID = 2,
                Name = "記事本",
                Price = 50.0m
            });
            result.Add(new TempProducts
            {
                ID = 3,
                Name = "橡皮擦",
                Price = 10.0m
            });
            return result; //回傳商品列表
        }
    }


}