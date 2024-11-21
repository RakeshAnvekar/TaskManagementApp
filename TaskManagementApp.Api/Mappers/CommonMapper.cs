using System.Data;
using System.Reflection;
using TaskManagementApp.Api.Mappers.Interfaces;

namespace TaskManagementApp.Api.Mappers;

public class CommonMapper : ICommonMapper
{
    public T MapDataReaderToModel<T>(IDataReader reader)
    {
        // Create an instance of the model (type T)
        var model = Activator.CreateInstance<T>();

        // Get all the properties of the model type
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        for (int i = 0; i <= reader.FieldCount; i++)
        {
            // Get the column name from the IDataReader
            var coloumName = reader.GetName(i);
            var property = properties.FirstOrDefault(p => p.Name.Equals(coloumName, StringComparison.OrdinalIgnoreCase));
            if (property!=null && property.CanWrite)
            {
                // Get the value from the reader for this column
                var value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                if (value != null)
                {
                    var targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    var safeValue = Convert.ChangeType(value, targetType);
                    property.SetValue(model, safeValue);
                }
            }
        }
        throw new NotImplementedException();
    }
}
