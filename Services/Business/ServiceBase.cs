using Microsoft.AspNetCore.Hosting;
using BlazorTests.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorTests.Services.Business;

namespace BlazorTests.Services
{
    public class ServiceBase
    {
        protected Repository Repository { get; set; }        
        
        public ServiceBase(Repository repository)
        {
            this.Repository = repository;
        }
    }
}
