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
    public class ReferenceService : ServiceBase
    {
        #region Initialisation

        public ReferenceService(Repository repository) : base(repository)
        {
        }

        #endregion

        #region Gestion des civilités       

        public Task<IList<Civility>> GetCivilitiesAsync()
        {
            return Task.FromResult(this.Repository.Civilities);
        }

        #endregion
    }
}
