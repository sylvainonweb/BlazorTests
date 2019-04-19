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

        public async Task<ParameterValue[]> GetParameterValuesAsync(int parameterId, DateTime? startDate, DateTime? endDate)
        {
            string fileContent = File.ReadAllText(Path.Combine(WebHostEnvironment.WebRootPath, "data/parameters-values.json"));
            var allParameterValues = JsonConvert.DeserializeObject<ParameterValue[]>(fileContent);
            var parameterValues = allParameterValues
                .Where(o => o.ParameterId == parameterId)
                .Where(o => o.Date >= startDate.GetValueOrDefault(DateTime.MinValue))
                .Where(o => o.Date <= endDate.GetValueOrDefault(DateTime.MaxValue));
            return await Task.FromResult(parameterValues.ToArray());
        }

        public Parameter GetParameter(int parameterId)
        {
            return this.Parameters.Where(o => o.Id == parameterId).Single();
        }

        public void AddParameter(Parameter parameter)
        {
            var parameters = this.Parameters;
            parameter.Id = parameters.Max(o => o.Id) + 1;
            this.Parameters.Add(parameter);
        }

        public void UpdateParameter(Parameter parameter)
        {
            var existingParameter = GetParameter(parameter.Id);
            existingParameter.Text = parameter.Text;
            this.Parameters.Add(existingParameter);
        }

        public void DeleteParameter(int parameterId)
        {
            var parameter = this.Parameters.Where(o => o.Id == parameterId).Single();
            this.Parameters.Remove(parameter);
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
