using System.Data;

namespace OrderSystem.Queries;
public class GuidTypeHandler : Dapper.SqlMapper.TypeHandler<Guid>
{
    public override Guid Parse(object value)
    {
        return Guid.Parse(value.ToString()!);
    }

    public override void SetValue(IDbDataParameter parameter, Guid value)
    {
        parameter.Value = value.ToString();
    }
}
