using Superpower;
using Superpower.Parsers;

namespace SuperpowerSimpleSql
{
    static class SqlParser
    {
        public static TokenListParser<SqlToken, Expression> Constant =
            Token.EqualTo(SqlToken.Number)
                .Apply(Numerics.IntegerInt32)
                .Select(n => (Expression) new ConstantExpression(n));

        public static TokenListParser<SqlToken, Expression> Call =
            Parse.Chain(
                Token.EqualTo(SqlToken.Plus),
                Constant,
                (op, lhs, rhs) => new CallExpression("Add", lhs, rhs));

        public static TokenListParser<SqlToken, Expression> Expression = Call;

        public static TokenListParser<SqlToken, SelectClause> SelectClause =
            from keyword in Token.EqualToValue(SqlToken.Keyword, "select")
            from columns in Expression.ManyDelimitedBy(Token.EqualTo(SqlToken.Comma))
            select new SelectClause(columns);
    }
}