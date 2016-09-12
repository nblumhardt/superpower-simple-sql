using System;

namespace SuperpowerSimpleSql
{
    class SelectClause
    {
        public Expression[] Columns { get; set; }

        public SelectClause(Expression[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            Columns = columns;
        }

        public override string ToString()
        {
            return $"SelectClause {{ Columns = {Expression.FormatArray(Columns)} }}";
        }
    }
}