using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var db = new ContosoUniversity190324Entities();

            // 顯示程式碼
            db.Database.Log = (msg) => Console.WriteLine(msg);

            // Contains用法(相當於like % %)
            var c = db.Courses.Where(p => p.Title.Contains("Git")).ToList();

            foreach (var item in c)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}