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

            SelectCourWithRelation1(db);
        }

        private static void SelectCourWithRelation(ContosoUniversity190324Entities db)
        {
            // 顯示程式碼
            db.Database.Log = (msg) => Console.WriteLine(msg);

            // Contains用法(相當於like % %)
            var c = db.Courses.Where(p => p.Title.Contains("Git")).ToList();

            //var c = db.Courses.Where(p => p.Title.StartsWith("Git")).ToList();
            //var c = db.Courses.Where(p => p.Title.EndsWith("Git")).ToList();

            // 只選擇單一欄位跑SQL by Linq
            //var c = db.Courses.Where(p => p.Title.StartsWith("Git")).Select(p => new { p.Title });

            // 只選擇單一欄位跑SQL
            //var c = from p in db.Courses
            //        where p.Title.StartsWith("Git")
            //        select new
            //        {
            //            p.Title
            //        };

            // 只選擇單一欄位跑SQL+排序
            //var c = from p in db.Courses
            //        where p.Title.StartsWith("Git")
            //        orderby p.Credits descending
            //        select new
            //        {
            //            p.Title
            //        };

            foreach (var item in c)
            {
                //Console.WriteLine(item.Title);
                Console.WriteLine(item.Department.Name + '\t' + item.Title);
            }
        }

        private static void SelectCourWithRelation1(ContosoUniversity190324Entities db)
        {
            // 顯示程式碼
            db.Database.Log = (msg) => Console.WriteLine(msg);

            var dept = from p in db.Departments
                       select p;

            foreach (var item in dept)
            {
                Console.WriteLine(item.Name);

                foreach (var item1 in item.Courses)
                {
                    Console.Write('\t' + item1.Title + '\n');
                }
            }
        }
    }
}