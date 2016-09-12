namespace SuperpowerSimpleSql
{
    class ConstantExpression : Expression
    {
        public int Value { get; set; }

        public ConstantExpression(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"ConstantExpression {{ Value = {Value} }}";
        }
    }
}