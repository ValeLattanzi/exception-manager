using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ExceptionManager.Model;

public class UniqueConstraintViolationException : Exception
{
    public string EntityName { get; }
    public string PropertyName { get; }
    public object DuplicateValue { get; }
    public SqlException? SqlException { get; }

    public UniqueConstraintViolationException(string entityName, string propertyName, object duplicateValue, SqlException? sqlException)
         : base($"Entity: {entityName}, Property: {propertyName}, Duplicate Value: {duplicateValue}")
    {
        EntityName = entityName;
        PropertyName = propertyName;
        DuplicateValue = duplicateValue;
        SqlException = sqlException ?? null;
    }

    public override string ToString()
    {
        return $"{base.ToString()}" + SqlException?.Message;
    }

    public static string ExtractIndexName(SqlException sqlEx)
    {
        var match = Regex.Match(sqlEx.Message, @"UNIQUE KEY constraint '(\w+)'");
        return match.Success ? match.Groups[1].Value : string.Empty;
    }

    public static object ExtractDuplicateValue(string message)
    {
        var match = Regex.Match(message, @"The duplicate key value is \((.*?)\)");
        return match.Success ? match.Groups[1].Value : null;
    }
}
