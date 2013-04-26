﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VietSovPetro.BO.Controllers
{
    public class CommonController : Controller
    {
        //
        // GET: /Common/
        [HttpPost]
        public ActionResult SaveImages(IEnumerable<HttpPostedFileBase> files, string folder)
        {
            string ImageUrl = "";
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(file.FileName);
                    var pathString = Path.Combine(Server.MapPath("~/Images/"), folder);
                    if (!Directory.Exists(pathString))
                    {
                        Directory.CreateDirectory(pathString);
                    }
                    var physicalPath = Path.Combine(pathString, fileName);

                    // The files are not actually saved in this demo
                    file.SaveAs(physicalPath);
                    var fileInfo = new FileInfo(fileName);
                    if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png" || fileInfo.Extension == ".gif" || fileInfo.Extension == ".jpeg" || fileInfo.Extension == ".html")
                    {
                        ImageUrl = String.Concat(folder + "/" + fileName);
                    }
                }
            }

            // Return an empty string to signify success
            return Json(new { ImageUrl = ImageUrl, Folder = folder }, JsonRequestBehavior.AllowGet);

        }
    }
}
