using Microsoft.AspNetCore.Hosting;
using BlazorTests.Data;
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

        public Task<IList<CivilityEntity>> GetCivilityEntities()
        {
            return Task.FromResult(this.Repository.CivilityEntities);
        }

        #endregion

        #region Gestion des activités       

        public Task<IList<ActivityEntity>> GetActivityEntities()
        {
            return Task.FromResult(this.Repository.ActivityEntities);
        }

        #endregion
    }
}
