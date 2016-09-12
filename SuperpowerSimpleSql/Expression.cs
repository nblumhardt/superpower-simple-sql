using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperpowerSimpleSql
{
    abstract class Expression
    {
        public static string FormatArray(IEnumerable<object> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            return "[" + string.Join(", ", values.Select(c => c.ToString())) + "]";
        }
    }
}