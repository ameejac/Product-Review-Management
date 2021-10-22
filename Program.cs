using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //uc1 creating product review records
            List<ProductReview> list = new List<ProductReview>()
            {
                new ProductReview(){ ProductId=1,UserId=1,Review="bad",Rating=5,IsLike=false},
                new ProductReview(){ProductId=2,UserId=3,Review ="good",Rating=10,IsLike=true },
                new ProductReview(){ProductId=3,UserId=4,Review ="average",Rating=15,IsLike=false },
                new ProductReview(){ProductId=4,UserId=5,Review ="bad",Rating=16,IsLike=true },
                new ProductReview(){ProductId=5,UserId=3,Review ="good",Rating=10,IsLike=true },
                new ProductReview(){ProductId=6,UserId=8,Review ="bad",Rating=18,IsLike=true },
                new ProductReview(){ProductId=7,UserId=2,Review ="good",Rating=5,IsLike=true },
                new ProductReview(){ProductId=8,UserId=3,Review ="good",Rating=15,IsLike=true },
                new ProductReview(){ProductId=9,UserId=5,Review ="average",Rating=8,IsLike=true },
                new ProductReview(){ProductId=1,UserId=4,Review ="bad",Rating=10,IsLike=false },
                new ProductReview(){ProductId=4,UserId=3,Review ="good",Rating=4,IsLike=true },
                new ProductReview(){ProductId=2,UserId=1,Review ="average",Rating=9,IsLike=true },
                new ProductReview(){ProductId=3,UserId=2,Review ="average",Rating=13,IsLike=true },
                new ProductReview(){ProductId=4,UserId=8,Review ="good",Rating=12,IsLike=true },
                new ProductReview(){ProductId=5,UserId=1,Review ="bad",Rating=10,IsLike=false },
                new ProductReview(){ProductId=1,UserId=9,Review ="good",Rating=5,IsLike=true },
                new ProductReview(){ProductId=7,UserId=3,Review ="bad",Rating=8,IsLike=false },
                new ProductReview(){ProductId=8,UserId=4,Review ="good",Rating=9,IsLike=true },
                new ProductReview(){ProductId=1,UserId=3,Review ="bad",Rating=4,IsLike=false },
                new ProductReview(){ProductId=2,UserId=2,Review ="good",Rating=2,IsLike=true },
                new ProductReview(){ProductId=1,UserId=5,Review ="average",Rating=15,IsLike=true },
                new ProductReview(){ProductId=2,UserId=4,Review ="good",Rating=12,IsLike=true },
                new ProductReview(){ProductId=3,UserId=1,Review ="average",Rating=13,IsLike=true },
                new ProductReview(){ProductId=2,UserId=5,Review ="bad",Rating=17,IsLike=false },
                new ProductReview(){ProductId=5,UserId=4,Review ="good",Rating=19,IsLike=true },
            };
            IterateOverProductList(list);
            RetriveTop3RecordsList(list);
            RetrieveBasedOnRatingAndProductId(list);
            Console.ReadLine();

        }
        //uc1 Add 25 values in the list
        public static void IterateOverProductList(List<ProductReview> list)
        {
            foreach(ProductReview product in list)
            {
                Console.WriteLine("ProductId:" + product.ProductId + "\t" + "UserId:" + product.UserId + "\t" + "ProductReview:" + product.Review + "\t" + "Product:" + product.Review + "\t");
            }
        }
        //uc2 Retrive top 3 records froms the list 
        public static void RetriveTop3RecordsList(List<ProductReview> list)
        {
            //using Linq
            var result = (from product in list orderby product.Rating descending select product).ToList();
            Console.WriteLine("After sort in desending order based on rating");
            IterateOverProductList(result);
            var top3Records = result.Take(3).ToList();
            Console.WriteLine("RetriveTop3RecordsList");
            IterateOverProductList(top3Records);

        }
        //UC3 Retrieve All Records From The List whose reating is greater than 3 and product Id is eaither 1 or 4or 9
        public static void RetrieveBasedOnRatingAndProductId(List<ProductReview> list)
        {
            //using Linq
            var data = (list.Where(r => r.Rating > 3 && (r.ProductId == 1 || r.ProductId == 4 || r.ProductId == 9))).ToList();
            Console.WriteLine("Retrieve  recorrds is based on Rating and Product Id : \t");
            IterateOverProductList(data);
        }
    }
}
