using Microsoft.AspNetCore.Hosting;
using BlazorTests.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Services
{
    public class ParameterService
    {
        private IWebHostEnvironment WebHostEnvironment { get; set; }

        public ParameterService(IWebHostEnvironment env)
        {
            this.WebHostEnvironment = env;
        }

        public Task<IList<Parameter>> GetParametersAsync()
        {
            return Task.FromResult(this.Parameters);
        }

        public async Task<ParameterValue[]> GetParameterValuesAsync(string parameterId, DateTime? startDate, DateTime? endDate)
        {
            string fileContent = File.ReadAllText(Path.Combine(WebHostEnvironment.WebRootPath, "data/parameters-values.json"));
            var allParameterValues = JsonConvert.DeserializeObject<ParameterValue[]>(fileContent);
            var parameterValues = allParameterValues
                .Where(o => o.ParameterId == parameterId)
                .Where(o => o.Date >= startDate.GetValueOrDefault(DateTime.MinValue))
                .Where(o => o.Date <= endDate.GetValueOrDefault(DateTime.MaxValue));
            return await Task.FromResult(parameterValues.ToArray());
        }

        public void AddParameter(Parameter parameter)
        {
            this.Parameters.Add(parameter);
        }

        private IList<Parameter> parameters = null;
        public IList<Parameter> Parameters
        {
            get
            {
                if (parameters == null)
                {
                    string fileContent = File.ReadAllText(Path.Combine(WebHostEnvironment.WebRootPath, "data/parameters.json"));
                    parameters = JsonConvert.DeserializeObject<IList<Parameter>>(fileContent);
                }

                return parameters;
            }
        }
    }
}
