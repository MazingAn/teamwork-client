using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamworkClient.DataSource;

namespace TeamworkClient.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string JobTitle { get; set; }
        public HashSet<Skill> skills { get; set; }
    }

}
