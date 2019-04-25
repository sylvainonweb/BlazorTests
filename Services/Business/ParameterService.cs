using BlazorTests.Data;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Services
{
    public class ParameterService : ServiceBase
    {
        private IWebHostEnvironment WebHostEnvironment { get; set; }

        public ParameterService(IWebHostEnvironment env, Repository repository) : base(repository)
        {
            this.WebHostEnvironment = env;
        }

        public Task<IList<Parameter>> GetParametersAsync()
        {
            return Task.FromResult(this.Repository.Parameters);
        }

        public async Task<ParameterValue[]> GetParameterValuesAsync(int parameterId, DateTime? startDate, DateTime? endDate)
        {
            var parameterValues = Repository.ParameterValues
                .Where(o => o.ParameterId == parameterId)
                .Where(o => o.Date >= startDate.GetValueOrDefault(DateTime.MinValue))
                .Where(o => o.Date <= endDate.GetValueOrDefault(DateTime.MaxValue));
            return await Task.FromResult(parameterValues.ToArray());
        }

        public Parameter GetParameter(int parameterId)
        {
            return this.Repository.Parameters.Where(o => o.Id == parameterId).Single();
        }

        public void AddParameter(Parameter parameterEntity)
        {
            parameterEntity.Id = this.Repository.Parameters.Max(o => o.Id) + 1;
            this.Repository.Parameters.Add(parameterEntity);
        }

        public void UpdateParameter(Parameter parameter)
        {
            var existingParameter = GetParameter(parameter.Id);
            existingParameter.Text = parameter.Text;
        }

        public void DeleteParameter(int parameterId)
        {
            var parameterEntity = this.Repository.Parameters.Where(o => o.Id == parameterId).Single();
            this.Repository.Parameters.Remove(parameterEntity);
        }
    }
}
