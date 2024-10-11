using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace chipchop.Core.Classes;

public class ImageClass
{
    string groupPath = "wwwroot/images/groups/";
    string contentPath = "wwwroot/images/content";
    public async Task<string> createSVG(string svgCode, string FileName)
    {
        string ImgFileName = $"{FileName}.svg";
        string SavePath = "wwwroot/images/groups/";
        if (!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
        }
        else
        {
            Debug.WriteLine("there is a folder named groups");
        }
        string FileAdress = Path.Combine(SavePath, ImgFileName);
        await File.WriteAllTextAsync(FileAdress, svgCode);
        return ImgFileName;
    }

    public async Task<string> GetSvgCode(string FileNmae)
    {
        string FileAdress = "wwwroot/images/groups/" + FileNmae;
        if (File.Exists(FileAdress))
        {
            return await File.ReadAllTextAsync(FileAdress);
        }
        return string.Empty;
    }

    public async Task<string> editSVG(string svgCode, string fileName, string oldName)
    {
        string svgFileName = $"{fileName}.svg";
        //string fileAdress = groupPath + svgFileName;
        if (oldName != svgFileName && File.Exists(groupPath + oldName))
        {
            File.Delete(groupPath + oldName);
        }
        string fileAdress = Path.Combine(groupPath , svgFileName);
        await File.WriteAllTextAsync(fileAdress, svgCode);
        return svgFileName;
    }

    //public async Task<string> DeleteCurrentImg(string fileAdress)
    //{
    //    fileAdress = ;
    //    if (File.Exists(fileAdress))
    //    {
    //        File.Delete(fileAdress);
    //    }
    //    return string.Empty;
    //}

    public void RemoveSVG(string FileName)
    {
        if(File.Exists(groupPath + FileName))
        {
            File.Delete(groupPath + FileName);
        }
    }
    //Task<dynamic> ==> return anytype of varible
    public async Task<string> SaveContentImg(IFormFile ImgFile)
    {
        var imageName = $"{new Random().Next(1000,10000)}.png";
        if (!Directory.Exists(contentPath))
        {
            Directory.CreateDirectory(contentPath);
        }
        var fileAddress = Path.Combine(contentPath, imageName);

        var stream = new FileStream(fileAddress, FileMode.Create);
        await ImgFile.CopyToAsync(stream);
        stream.Dispose();
        return imageName;
    }

}
