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
    //Creates a logger
    private readonly ILogger<HomeController> _logger;
    //Creates a Filerepository Interface
    private readonly IFileRepository _fileRepository;

    //Implements the Repository Interface and the logger

    public HomeController(ILogger<HomeController> logger, IFileRepository fileRepository)
    {
        _logger = logger;
        _fileRepository = fileRepository;
    }


    //Returns the homepage
    public IActionResult Index()
    {
        return View();
    }

    //Enables the user to access the "About us" page
    public IActionResult Privacy()
    {
        return View();
    }
    //Returns the uploaded file
    public IActionResult FileUpload()
    {
        return View();
    }

    //Returns the uploaded image
    public IActionResult FileUploadImages()
    {
        return View();
    }

    //Enables the user to upload a file, and checks whether the upload was a success

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

    //Enables the user to upload an image, and checks whether the upload was a success
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

    //Enables users to download uploaded images

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

    //Enables users to download uploaded files

    public FileResult DownloadFile(string fileName)
    {
        //Build the File Path.
        string path = Path.Combine(Environment.CurrentDirectory, "UploadedFiles/") + fileName;

        //Read the File data into Byte Array.
        byte[] bytes = System.IO.File.ReadAllBytes(path);

        //Send the File to Download.
        return File(bytes, "application/octet-stream", fileName);
    }

    //Reduces the amount of requests the client makes to the server

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}



