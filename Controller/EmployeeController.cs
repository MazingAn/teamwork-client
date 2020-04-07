using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamworkClient.DataSource;
using TeamworkClient.Models;

namespace TeamworkClient.Controller
{
    class EmployeeController : IJsonApiController<Employee>
    {
        public async Task<Employee> DeserializeAsync(string jsonStr)
        {
            Employee employee = JsonConvert.DeserializeObject<Employee>(jsonStr, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            return employee;
        }

        public async Task<List<Employee>> LoadListFromUrlAsync(string url)
        {
            List<Employee> employees = new List<Employee>();
            MyJsonDataSource dataSource = new MyJsonDataSource(url);
            string employeeStr = await dataSource.LoadJsonStrFromWebAsync();
            JArray job = JArray.Parse(employeeStr);
            foreach (var employeeObject in job)
            {
                employees.Add(await DeserializeAsync(employeeObject.ToString()));
            }
            return employees;
        }

        public Task<Employee> LoadOneFromUrlAsync(string url)
        {
            throw new NotImplementedException();
        }

        public string SerializeAsnyc(Employee modelObject)
        {
            throw new NotImplementedException();
        }
    }
}
