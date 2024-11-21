using System.Data;

namespace TaskManagementApp.Api.Mappers.Interfaces;

public interface ICommonMapper
{
    public T MapDataReaderToModel<T>(IDataReader reader);
}
