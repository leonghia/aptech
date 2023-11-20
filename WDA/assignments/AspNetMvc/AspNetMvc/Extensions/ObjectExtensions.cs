using System.Dynamic;
using System.Reflection;

namespace AspNetMvc.Extensions
{
    public static class ObjectExtensions
    {
        public static ExpandoObject Shape(this object? e, string? fields)
        {
            if (e is null) throw new ArgumentNullException($"Cannot shape object {nameof(e)} as it is null.");
            var expandoObject = new ExpandoObject();
            // first we get the default properties of object e
            var defaultProperties = e.GetType().GetProperties();
            // then we check if each field is a valid prop in the default properties
            if (fields is not null)
            {
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
            }
            else
            {
                foreach (var property in defaultProperties)
                {
                    expandoObject.TryAdd(property.Name, property.GetValue(e));
                }
            }

            return expandoObject;
        }
    }
}
