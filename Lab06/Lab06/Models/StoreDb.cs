using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Lab06
{
    public static class StoreDb
    {
        public static ObservableCollection<Product> products { get; set; }
        public static ObservableCollection<ProductType> productTypes { get; set; }
        private static JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), };

        static StoreDb()
        {
            string fileName1 = @"../../../Data/Products.json";
            string json1 = File.ReadAllText(fileName1);
            string fileName2 = @"../../../Data/ProductType.json";
            string json2 = File.ReadAllText(fileName2);


            products = JsonSerializer.Deserialize<ObservableCollection<Product>>(json1, options);
            productTypes = JsonSerializer.Deserialize<ObservableCollection<ProductType>>(json2, options);
            products.CollectionChanged += ProductsChanged;
            foreach (Product item in products)
                item.PropertyChanged += ProductChanged;
        }
        private static void ProductsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (Product item in e.NewItems)
                    item.PropertyChanged += ProductChanged;

            if (e.OldItems != null)
                foreach (Product item in e.OldItems)
                    item.PropertyChanged -= ProductChanged;
            string fileName1 = @"../../../Data/Products.json";
            string json = JsonSerializer.Serialize(products, options);
            File.WriteAllText(fileName1, json);
        }
        private static void ProductChanged(object sender, PropertyChangedEventArgs e)
        {
            string fileName1 = @"../../../Data/Products.json";
            string json = JsonSerializer.Serialize(products, options);
            File.WriteAllText(fileName1, json);
        }
    }
}
