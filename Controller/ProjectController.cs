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
    class ProjectController : IJsonApiController<Project>
    {
        /// <summary>
        /// json数据转换为对象
        /// </summary>
        /// <param name="jsonStr">son类型字符串</param>
        /// <returns></returns>
        public async Task<Project> DeserializeAsync(string jsonStr)
        {
            Project project = JsonConvert.DeserializeObject<Project>(jsonStr, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }) ;
            await project.LoadMember(project.Id);
            return project; 
        }

        /// <summary>
        /// 从URL加载数据
        /// </summary>
        /// <param name="url">访问地址</param>
        /// <returns></returns>
        public async Task<Project> LoadOneFromUrlAsync(string url)
        {
            MyJsonDataSource dataSource = new MyJsonDataSource(url);
            string projectJsonStr = await dataSource.LoadJsonStrFromWebAsync();
            return await DeserializeAsync(projectJsonStr);
        }


        /// <summary>
        /// 从URL加载一个集合
        /// </summary>
        /// <param name="url">访问地址</param>
        /// <returns></returns>
        public async Task<List<Project>> LoadListFromUrlAsync(string url)
        {
            List<Project> projects = new List<Project>();
            MyJsonDataSource dataSource = new MyJsonDataSource(url);
            string projectJsonStr = await dataSource.LoadJsonStrFromWebAsync();
            JObject job = JObject.Parse(projectJsonStr);
            if (job.ContainsKey("content"))
            {
                foreach( JObject projectJsonObject in job["content"] as JArray)
                {
                    projects.Add(await DeserializeAsync(projectJsonObject.ToString()));
                }
            }
            return projects;
        }

        /// <summary>
        /// 模型转为Json
        /// </summary>
        /// <param name="modelObject">模型</param>
        /// <returns></returns>
        public string SerializeAsnyc(Project modelObject)
        {
            throw new NotImplementedException();
        }
    }
}
