using BlogSite.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adi";

                int blogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(blogRowCount, 1).Value = item.Id;
                    worksheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Deneme1.xlsx");
                }
            }
            return View();
        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogList = new List<BlogModel>
            {
                new BlogModel{Id = 1, BlogName="C# candir"},
                new BlogModel{Id = 2, BlogName="Bitcoin piyasasi"},
                new BlogModel{Id=3, BlogName="2022 Dunya Kupasi"}
            };
            return blogList;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adi";

                int blogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(blogRowCount, 1).Value = item.Id;
                    worksheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Deneme1.xlsx");
                }
            }
            return View();
        }

        public List<BlogModel> BlogTitleList()
        {
            List<BlogModel> blogList = new List<BlogModel>();

            using (var c = new Context())
            {
                blogList = c.Blogs.Select(x => new BlogModel
                {
                    Id = x.BlogId,
                    BlogName = x.Title
                }).ToList();
            }
            return blogList;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
