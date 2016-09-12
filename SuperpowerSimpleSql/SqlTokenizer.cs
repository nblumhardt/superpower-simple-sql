using System.Collections.Generic;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;

namespace SuperpowerSimpleSql
{
    class SqlTokenizer : Tokenizer<SqlToken>
    {
        protected override IEnumerable<Result<SqlToken>> Tokenize(TextSpan input)
        {
            var next = SkipWhiteSpace(input);
            if (!next.HasValue)
                yield break;

            do
            {
                if (char.IsLetter(next.Value))
                {
                    var keywordStart = next.Location;
                    do
                    {
                        next = next.Remainder.ConsumeChar();
                    } while (next.HasValue && char.IsLetter(next.Value));

                    yield return Result.Value(SqlToken.Keyword, keywordStart, next.Location);
                }
                else if (char.IsDigit(next.Value))
                {
                    var integer = Numerics.Integer(next.Location);
                    yield return Result.Value(SqlToken.Number, next.Location, integer.Remainder);
                    next = integer.Remainder.ConsumeChar();
                }
                else if (next.Value == '+')
                {
                    yield return Result.Value(SqlToken.Plus, next.Location, next.Remainder);
                    next = next.Remainder.ConsumeChar();
                }
                else if (next.Value == ',')
                {
                    yield return Result.Value(SqlToken.Comma, next.Location, next.Remainder);
                    next = next.Remainder.ConsumeChar();
                }
                else
                {
                    yield return Result.Empty<SqlToken>(next.Location, $"unrecognized `{next.Value}`");
                    next = next.Remainder.ConsumeChar(); // Skip the character anyway
                }

                next = SkipWhiteSpace(next.Location);
            } while (next.HasValue);
        }
    }
}