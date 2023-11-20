using System.Dynamic;
using System.Reflection;

namespace AspNetMvc.Utilities
{
    public static class ObjectExtensions
    {
        public static ExpandoObject Shape(this object e, string fields)
        {
            var expandoObject = new ExpandoObject();
            // first we get the default properties of object e
            var defaultProperties = e.GetType().GetProperties();
            // then we check if each field is a valid prop in the default properties
            var fieldsArr = fields.Split(',');
            foreach (var f in fieldsArr)
            {
                var property = defaultProperties.FirstOrDefault(p => p.Name.Equals(f, StringComparison.InvariantCultureIgnoreCase));
                if (property is null)
                {
                    throw new ArgumentException($"Cannot parse '{f}' as a valid field for data shaping.");
                }
                else
                {
                    // then we map each prop from e to the new expandoObject
                    expandoObject.TryAdd(property.Name, property.GetValue(e));
                }             
            }

            return expandoObject;
        }
    }
}
