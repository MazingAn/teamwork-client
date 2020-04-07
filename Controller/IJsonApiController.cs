using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkClient.DataSource
{
    interface IJsonApiController<T>
    {
        Task<T> LoadOneFromUrlAsync(string url);
        Task<List<T>> LoadListFromUrlAsync(string url);
        string SerializeAsnyc(T modelObject);
        Task<T> DeserializeAsync(string jsonStr);
    }
}
