using System.ComponentModel;
using System.Reflection;

namespace Bytescove_Solutions.CommonServices
{
    public static class EnumUtility
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute == null ? value.ToString() : attribute.Description;
        }
        public static int GetIndexByDescription<T>(string description) where T : Enum
        {
            var enumType = typeof(T);
            var values = Enum.GetValues(enumType).Cast<Enum>().ToList();

            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].GetDescription().Equals(description, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                return i;
            }

            throw new ArgumentException($"Description '{description}' not found in Enum '{enumType.Name}'.");
        }
    }
}
