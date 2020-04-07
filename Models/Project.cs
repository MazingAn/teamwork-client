using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamworkClient.Config;
using TeamworkClient.Controller;

namespace TeamworkClient.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Employee> Employees { get; set; }

        public async Task LoadMember(long projectId)
        {
            string url = NetConfig.UrlJoin("project","member/"+projectId);
            EmployeeController employeeController = new EmployeeController();
            Employees = await employeeController.LoadListFromUrlAsync(url);
        }

    }
}
