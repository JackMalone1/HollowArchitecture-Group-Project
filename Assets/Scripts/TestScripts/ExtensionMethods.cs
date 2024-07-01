using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
    }
}