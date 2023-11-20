using AspNetMvc.Models;
using System.Dynamic;

namespace AspNetMvc.Extensions
{
    public static class ServiceResponseExtensions
    {
        public static ExpandoObject Shape(this ServiceResponse<object> serviceResponse)
        {
            var expandoObject = new ExpandoObject();

            var defaultProperties = serviceResponse.GetType().GetProperties();
            foreach (var property in defaultProperties)
            {
                expandoObject.TryAdd(property.Name, property.GetValue(serviceResponse));
            }

            return expandoObject;
        }
    }
}
