using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveClient.ViewModel
{
    public class UploadVM
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
    }
}
