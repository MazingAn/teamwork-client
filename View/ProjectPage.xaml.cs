using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeamworkClient.Config;
using TeamworkClient.Controller;
using TeamworkClient.DataSource;
using TeamworkClient.Models;
using TeamworkClient.Templates;

namespace TeamworkClient.View
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class ProjectPage : BasePage
    {
        ProjectController projectController;
        List<Project> projects;

        public ProjectPage()
        {
            InitializeComponent();
            LoadProjectData();
        }


        /// <summary>
        /// load then parse project data from web and bind to xaml
        /// </summary>
        private async void LoadProjectData()
        {
            try
            {
                projectController = new ProjectController();
                string url = NetConfig.UrlJoin("project", "");
                projects = await projectController.LoadListFromUrlAsync(url);
                lbProjects.ItemsSource = projects;
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await this.AnimateIn();
        }
    }
}
