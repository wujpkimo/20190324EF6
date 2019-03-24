using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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

            CCourseWithRelation(db);
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

        private static void SelectCourWithRelation2(ContosoUniversity190324Entities db)
        {
            // 顯示程式碼
            db.Database.Log = (msg) => Console.WriteLine(msg);

            // 最好是都取消lazyloading
            db.Configuration.LazyLoadingEnabled = false;
            foreach (var item in db.Courses.Include(p => p.Department).Select(p => new { CourseTitle = p.Title, DeptTitle = p.Department.Name }))
            {
                Console.WriteLine(item.CourseTitle);

                Console.Write('\t' + item.DeptTitle + '\n');
            }
        }

        private static void SelectCourWithRelation3(ContosoUniversity190324Entities db)
        {
            // 顯示程式碼
            db.Database.Log = (msg) => Console.WriteLine(msg);

            var data = from p in db.Courses.Include(p => p.Department)
                       select new
                       {
                           CourseTitle = p.Title,
                           DeptTitle = p.Department.Name
                       };

            // 最好是都取消lazyloading
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            foreach (var item in data)
            {
                Console.WriteLine(item.CourseTitle);

                Console.Write('\t' + item.DeptTitle + '\n');
            }
        }

        private static void CRUDCourWithRelation1(ContosoUniversity190324Entities db)
        {
            // 顯示程式碼
            db.Database.Log = (msg) => Console.WriteLine(msg);

            Department dept = new Department
            {
                Name = "TEST",
                Budget = 100,
                StartDate = DateTime.Now,
                ModifyOn = DateTime.Now
            };

            dept.Courses.Add(new Course
            {
                Title = "Test 課程1",
                Credits = 1,
                Department = dept
            });

            dept.Courses.Add(new Course
            {
                Title = "Test 課程2",
                Credits = 2,
                Department = dept
            });
            db.Departments.Add(dept);
            db.SaveChanges();

            Console.WriteLine("產生部門id: " + dept.DepartmentID);
            Console.WriteLine("產生部門名稱: " + dept.Name);

            foreach (var c in dept.Courses)
            {
                Console.WriteLine("CourseId: " + c.CourseID.ToString());
            }

            var data = db.Departments.Find(dept.DepartmentID);

            data.Name = "Adjust Test";
            db.SaveChanges();

            Console.WriteLine("部門名稱調整為: " + data.Name);

            //db.Departments.Remove(data);
            //db.SaveChanges();
            //Console.WriteLine("部門 " + data.Name + " 已刪除");
        }

        private static void CCourseWithRelation(ContosoUniversity190324Entities db)
        {
            // 顯示程式碼
            db.Database.Log = (msg) => Console.WriteLine(msg);

            var course = db.Courses.Find(1);

            course.Instructors.Add(new Person()
            {
                FirstName = "will",
                LastName = "Huang",
                HireDate = DateTime.Now,
                //Discriminator = "XXX"
            });

            // enity錯誤處理
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var sb = new StringBuilder();
                foreach (var ex in e.EntityValidationErrors)
                {
                    foreach (var ve in ex.ValidationErrors)
                    {
                        sb.AppendLine($"欄位: {ve.PropertyName} 發生錯誤: {ve.ErrorMessage} ");
                    }
                }
                //Console.WriteLine(e.EntityValidationErrors);
                throw new Exception(sb.ToString(), e);
            }
        }
    }
}