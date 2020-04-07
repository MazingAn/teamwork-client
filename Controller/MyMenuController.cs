using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamworkClient.DataSource;
using TeamworkClient.Models;

namespace TeamworkClient.Controller
{
    class MyMenuController :  IJsonApiController<MyMenu>
    {

        public async Task<List<MyMenu>> LoadListFromUrlAsync(string url)
        {
            List<MyMenu> myMenus = new List<MyMenu>()
            {
                new MyMenu("主页", "HomePage.xaml", "Home"),
                new MyMenu("项目", "ProjectPage.xaml", "Projector"),
                new MyMenu("工作包", "TaskPage.xaml", "CalendarTask"),
                new MyMenu("资源", "ResourcesPage.xaml", "Dictionary"),
                new MyMenu("通信录", "ContactPage.xaml", "Contact"),
                new MyMenu("知识库", "KnowledgePage.xaml", "BookInformationVariant"),
                new MyMenu("个人信息", "ProfilePage.xaml", "FaceProfile")
            };
            return myMenus;
        }

        public string SerializeAsnyc(MyMenu modelObject)
        {
            throw new NotImplementedException();
        }

        public Task<MyMenu> DeserializeAsync(string jsonStr)
        {
            throw new NotImplementedException();
        }

        public Task<MyMenu> LoadOneFromUrlAsync(string url)
        {
            throw new NotImplementedException();
        }

    }
}
