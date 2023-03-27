using Microsoft.AspNetCore.Http;

namespace Data.API.FileUpload
{
    public class Upload
    {
        public async Task<string[]> Uploader(IFormFile formFile,string DirPath)
        {
            string filename="", filedir="";
            if(formFile != null)
            {
                filename = Path.GetFileNameWithoutExtension(formFile.FileName);
                var extension = Path.GetExtension(formFile.FileName);
                filename = DateTime.Now.ToString("yyssmmfff") + extension;
                filedir = DirPath + "/Images/";
                var path = Path.Combine(filedir, filename);
                using(var file = new FileStream(path, FileMode.Create))
                {
                   await formFile.CopyToAsync(file);
                }
            }

            string[] dizi = new string[] { filename, filedir, Convert.ToString(formFile.Length) };
            return dizi;
        }
    }
}
