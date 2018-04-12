using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AppChambitasV1.Backend.Helper
{
    public class FilesHelper
    {
        public static string UploadPhoto(HttpPostedFileBase file, string folder)
        {
            var path = string.Empty;
            var pic = string.Empty;
            if (file != null)
            {
                pic = Path.GetFileName(file.FileName);
                path = Path.Combine(HttpContext.Current.Server.MapPath(folder), pic);
                file.SaveAs(path);
            }
            return pic;
        }
    }
}