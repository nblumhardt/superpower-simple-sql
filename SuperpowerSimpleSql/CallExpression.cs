using System;

namespace SuperpowerSimpleSql
{
    class CallExpression : Expression
    {
        public string Operator { get; set; }
        public Expression[] Operands { get; set; }

        public CallExpression(string @operator, params Expression[] operands)
        {
            if (@operator == null) throw new ArgumentNullException(nameof(@operator));
            if (operands == null) throw new ArgumentNullException(nameof(operands));
            Operator = @operator;
            Operands = operands;
        }

        public override string ToString()
        {
            return $"CallExpression {{ Operator = \"{Operator}\", Operands = {FormatArray(Operands)} }}";
        }
    }
}