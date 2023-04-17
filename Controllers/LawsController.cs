using KnowledgeBase.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Controllers
{
    public class LawsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


//var fileModels = new List<FileModel>();
//if (files != null)
//{
//    foreach (var file in files)
//    {
//        if (file.Length > 0)
//        {
//            var fileModel = new FileModel();
//            fileModel.Title = Path.GetFileNameWithoutExtension(file.FileName);
//            fileModel.Extension = Path.GetExtension(file.FileName);
//            string wwwrootpath = _webHostEnvironment.WebRootPath;
//            string subDirPath = $"{document.Id}";
//            DirectoryInfo dirInfo = new DirectoryInfo(wwwrootpath + "/files/");
//            if (!dirInfo.Exists)
//            {
//                dirInfo.Create();
//            }
//            dirInfo.CreateSubdirectory(subDirPath);
//            fileModel.Path = Path.Combine(Directory.GetCurrentDirectory(), wwwrootpath + "/files/" + subDirPath + "/", fileModel.Title + fileModel.Extension);
//            fileModels.Add(fileModel);
//            using (var fileStream = new FileStream(fileModel.Path, FileMode.Create))
//            {
//                await file.CopyToAsync(fileStream);
//            }
//        }
//    }
//}
//return fileModels;