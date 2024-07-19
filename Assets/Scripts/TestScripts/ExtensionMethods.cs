using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Random = UnityEngine.Random;

namespace TestScripts
{
    public static class ExtensionMethods
    {
        public static void Shuffle<T>(this Stack<T> stack)
        {
            var values = stack.ToArray();
            stack.Clear();
            foreach (var value in values.OrderBy(x => Random.value))
                stack.Push(value);
        }

        public static string GetDescription(this Enum e)
        {
            var attribute = e.GetType()
                    .GetTypeInfo()
                    .GetMember(e.ToString())
                    .FirstOrDefault(member => member.MemberType == MemberTypes.Field)
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault()
                as DescriptionAttribute;
            return attribute?.Description ?? e.ToString();
        }
    }
}