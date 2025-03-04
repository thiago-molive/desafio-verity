using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EasyCash.Domain.Extensions;

public static class EnumerableExtensions
{

    public static bool AddIfNotContains<T>(this ICollection<T> source, T item)
    {
        if (source == null) throw new ArgumentNullException("source");

        if (source.Contains(item)) return false;

        source.Add(item);
        return true;
    }

    public static string GetName(this Enum enumValue)
    {
        if (enumValue == null)
            return null;
        var displayAttribute = enumValue.GetDisplayAttribute();
        return displayAttribute == null ? enumValue.ToString() : displayAttribute.Name;
    }

    public static string GetDescription(this Enum enumValue)
    {
        if (enumValue == null)
            return null;
        var displayAttribute = enumValue.GetDisplayAttribute();
        return displayAttribute == null ? enumValue.ToString() : displayAttribute.Description;
    }

    private static DisplayAttribute? GetDisplayAttribute(this Enum enumValue)
    {
        FieldInfo? field = enumValue.GetType().GetField(enumValue.ToString());
        return (object)field == null ? null : field.GetCustomAttribute<DisplayAttribute>();
    }
}

