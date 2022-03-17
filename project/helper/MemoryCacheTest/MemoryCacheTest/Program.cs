using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Threading;

namespace MemoryCacheTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectCache cache = MemoryCache.Default;
            ComplexType obj1 = new ComplexType(5);
            ComplexType obj2 = new ComplexType(6);

            //add ClassContent object obj1 in Cache 
            //without cacheItem expiration date
            cache.Add("Obj1", obj1, null);
            Console.WriteLine("Obj1 is added with no expiration time and counter 5");

            //add also a simple int data 
            //without cacheItem expiration date
            cache.Add("Obj3", 5, null);
            Console.WriteLine("Obj3 is added with no expiration time and value 5");

            //add ClassContent object obj1 in Cache 
            //with a first cache item experimentation policy
            var cacheItemPolicy1 = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(1.0),

            };
            cache.Add("Obj2", obj2, cacheItemPolicy1);
            Console.WriteLine("Obj2 is added with 1s of expiration time and counter 6");

            //add a second int data in Cache 
            //with a second cache item experimentation policy
            var cacheItemPolicy2 = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(4.0),

            };
            cache.Add("Obj4", 7, cacheItemPolicy2);
            Console.WriteLine("Obj4 is added with 4s of expiration time and value 7");


            //print all cache
            PrintAllCache(cache);

            Thread.Sleep(2000);
            Console.WriteLine("waiting for 2 seconds");

            //print all cache
            PrintAllCache(cache);

            Thread.Sleep(5000);
            Console.WriteLine("waiting for 5 seconds");

            //print all cache
            PrintAllCache(cache);

            //remove cache
            cache.Remove("obj3");

            //print all cache
            PrintAllCache(cache);

            //update cache value obj4 to 8 
            cache.Set("obj4", 8, null);
            Console.WriteLine("Obj4 is set to 8 with no expiration time");

            //print all cache
            PrintAllCache(cache);

            if (cache.Get("obj1") == null)
            {
                Console.WriteLine("obj1 is null");
                cache.Set("obj1", obj1, null);
                Console.WriteLine("obj1 is reinitialized with obj1");
            }

            ComplexType c = (ComplexType) cache.Get("obj1");
            
            Console.WriteLine("obj1 counter value is "+ c.display());
            Console.WriteLine("obj1 counter value is incremented ");
            c.incr();
            Console.WriteLine("obj1 counter value is " + c.display());

            Console.ReadLine();
        }

        public static void PrintAllCache(ObjectCache cache)
        {

            DateTime dt = DateTime.Now;

            Console.WriteLine("All key-values at " + dt.Second);
            //loop through all key-value pairs and print them
            foreach (var item in cache)
            {
                Console.WriteLine("cache object key-value: " + item.Key + "-" + item.Value);
            }
        }
    }
}