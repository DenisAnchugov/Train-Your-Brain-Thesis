using System;

namespace TrainYourBrain.Core
{
    public class ExpressionFactory
    {
        int sumAndSubtractionNumRange = 30;
        int multiplicationNumRange = 10;
        int operatorRange = 3;

        public Expression CreateExpression(int level)
        {
            var random = new Random();

            var operand1 = random.Next(sumAndSubtractionNumRange * level);
            var operand2 = random.Next(sumAndSubtractionNumRange * level);

            var multiplicant = random.Next(multiplicationNumRange * level);
            var multiplier = random.Next(multiplicationNumRange * level);

            var sign = random.Next(operatorRange);
            int result;

            switch (sign)
            {
                case 0:
                    result = operand1 + operand2;
                    return new Expression(operand1, operand2, '+', result);

                case 1:
                    result = operand1 - operand2;
                    return new Expression(operand1, operand2, '-', result);

                default:
                    result = multiplicant * multiplier;
                    return new Expression(multiplicant, multiplier, '*', result);
            }
        }
    }

    public class Expression
    {
        int operand1;
        int operand2;
        char operatorSign;
        int result;

        public Expression(int operand1, int operand2, char operatorSign, int result)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
            this.operatorSign = operatorSign;
            this.operatorSign = operatorSign;
            this.result = result;
        }

        public bool CheckAnswer(int userInput)
        {
            return userInput == result;
        }

        public override string ToString()
        {
            return $"{operand1} {operatorSign} {operand2} = ?";
        }
    }
}