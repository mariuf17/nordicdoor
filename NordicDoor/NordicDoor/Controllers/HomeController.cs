using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NordicDoor.Models;
using NordicDoor.Contracts;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace NordicDoor.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFileRepository _fileRepository;

    //private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

    public HomeController(ILogger<HomeController> logger, IFileRepository fileRepository)
    {
        _logger = logger;
        _fileRepository = fileRepository;
    }

    public IActionResult Login()
    {
        return View();
    }

    //https://localhost:5001/home/Index
    public IActionResult Index()
    {
        return View();
    }

    //https://localhost:5001/home/Privacy
    public IActionResult Privacy()
    {
        return View();
    }
    //https://localhost:5001/home/FileUpload
    public IActionResult FileUpload()
    {
        return View();
    }

    //https://localhost:5001/home/FileUploadImages
    public IActionResult FileUploadImages()
    {
        return View();
    }

    [HttpPost("/fileUpload")]
    public ActionResult FileUpload(IFormFile file)
    {
        try
        {
            if (_fileRepository.UploadFileServer(file))
            {
                ViewBag.Message = "File Upload Successful";
            }
            else
            {
                ViewBag.Message = "File Upload Failed";
            }
        }
        catch (Exception ex)
        {
            //Log ex
            ViewBag.Message = "File Upload Failed";
        }
        return View();
    }

    [HttpPost("/fileUploadImages")]
    public async Task<ActionResult> FileUploadImages(IFormFile file)
    {
        try
        {
            var imageupload = await _fileRepository.UploadFileInDB(file);

            if (imageupload > 0)
            {
                ViewBag.Message = "File Upload Successful";
            }
            else
            {
                ViewBag.Message = "File Upload Failed";
            }
        }
        catch (Exception ex)
        {
            //Log ex
            ViewBag.Message = "File Upload Failed";
        }
        return View();
    }


    public IActionResult Download()
    {
        //Fetch all files in the Folder (Directory).
        string[] filePaths = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "UploadedFiles/"));

        //Copy File names to Model collection.
        List<FileModel> files = new List<FileModel>();
        foreach (string filePath in filePaths)
        {
            files.Add(new FileModel
            {
                FileName = Path.GetFileName(filePath)
            });
        }

        return View(files);
    }

    public async Task<IActionResult> DownloadImage()
    {
        //Fetch all files in the Folder (Directory).           
        List<FileModel> files = new List<FileModel>();
        //Copy File names to Model collection.
        files = (List<FileModel>)await _fileRepository.GetFileInfo();

        foreach (FileModel file in files)
        {
            _logger.LogInformation(Convert.ToString(file.Id));
            _logger.LogInformation(file.FileName);
            _logger.LogInformation(Convert.ToString(file.Content));
        }

        return View(files);
    }

    public async Task<FileResult> DownloadFileImage(int Id, String fileName)
    {
        _logger.LogInformation(Id.ToString());
        //Build the File Path.
        byte[] file = await _fileRepository.GetFileInfoById(Id);

        _logger.LogInformation(file.ToString());

        //Read the File data into Byte Array.
        byte[] bytes = Convert.FromBase64String(Encoding.UTF8.GetString(file));

        //Send the File to Download.
        return File(bytes, "application/octet-stream", fileName);
    }

    public FileResult DownloadFile(string fileName)
    {
        //Build the File Path.
        string path = Path.Combine(Environment.CurrentDirectory, "UploadedFiles/") + fileName;

        //Read the File data into Byte Array.
        byte[] bytes = System.IO.File.ReadAllBytes(path);

        //Send the File to Download.
        return File(bytes, "application/octet-stream", fileName);
    }

    //https://localhost:5001/home/MycontrollerTest
    public string MycontrollerTest()
    {
        return "Hi, I am a controller";
    }

    //https://localhost:5001/home/Mycontroller
    public IActionResult Mycontroller()
    {
        return View("Views/Home/Index.cshtml");
    }

    //https://localhost:5100/home/Insert
    public IActionResult Insert()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}



