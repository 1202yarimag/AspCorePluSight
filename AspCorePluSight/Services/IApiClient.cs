using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Services
{
    public interface IApiClient <T>
    {
      
            Task<T> GetAsync(string relativePath);
            //Task<T> PostAsync(Dictionary<string, string> sendFormValue, string relativePath);
            //Task<T> PostAsJsonAsync(object sendValue, string relativePath);
            //Task PostAsJsonAsyncNoResponse(object sendValue, string relativePath);
    }
}
