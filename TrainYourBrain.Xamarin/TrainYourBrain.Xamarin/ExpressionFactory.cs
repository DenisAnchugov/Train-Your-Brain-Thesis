using System;

namespace TrainYourBrain.Core
{
    public class ExpressionFactory
    {
        int numberRange = 8;
        char[] operators = { '+', '-' };

        public Expression CreateExpression()
        {
            var random = new Random();

            var operand1 = random.Next(numberRange);
            var operand2 = random.Next(numberRange);

            var operatorSign = operators[random.Next(operators.Length)]; 

            numberRange++;
            return new Expression(operand1, operand2, operatorSign);
        }

        public void Reset()
        {
            numberRange = 8;
        }
    }

    public class Expression
    {
        int operand1;
        int operand2;
        char operatorSign;

        public Expression(int operand1, int operand2, char operatorSign)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
            this.operatorSign = operatorSign;
        }

        public bool CheckAnswer(int userInput)
        {
            return userInput == Calculate();
        }

        int Calculate()
        {
            switch (operatorSign)
            {
                case '+':
                    return operand1 + operand2;
                default:
                    return operand1 - operand2;
            }
        }

        public override string ToString()
        {
            return $"{operand1} {operatorSign} {operand2} = ?";
        }
    }
}