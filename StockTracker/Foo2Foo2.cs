﻿using System;
using System.Collections.Generic;
using System.Linq;
using StockTracker;

internal class Foo2Foo2
{
    private readonly StockPriceLoader _stockPriceLoader;

    public Foo2Foo2(StockPriceLoader stockPriceLoader)
    {
        _stockPriceLoader = stockPriceLoader;
    }

    public void Foo2(out double total, out double gain,
        IEnumerable<Stock> enumerateStocks,
        Action<Stock, double, double, double> foo1)
    {
        foreach (Stock stock in enumerateStocks)
        {
            var price = _stockPriceLoader.Load(stock.Ticker);

            var stockTotalPrice = stock.GetTotalPrice(price);
            var stockGain = stock.GetGain(price);
            foo1(stock, price, stockTotalPrice, stockGain);

        }

    }

    public class StockPriceStockTotalPriceStockGain
    {
        public StockPriceStockTotalPriceStockGain(
            Stock stock,
            double price,
            double stockTotalPrice,
            double stockGain)
        {
            this.Stock = stock;
            this.Price = price;
            this.StockTotalPrice = stockTotalPrice;
            this.StockGain = stockGain;
        }

        public Stock Stock { get; }
        public double Price { get;  }
        public double StockTotalPrice { get; }
        public double StockGain { get; }
    }
}