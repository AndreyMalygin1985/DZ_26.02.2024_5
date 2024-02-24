// Пользователь с клавиатуры вводит в строку арифметическое выражение. Приложение должно
// посчитать его результат. Необходимо поддерживать только две операции: + и –.

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите арифметическое выражение (например, 10+5-3):");
        string expression = Console.ReadLine();

        try
        {
            int result = CalculateExpression(expression);
            Console.WriteLine("Результат: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    static int CalculateExpression(string expression)
    {
        int result = 0;
        int currentIndex = 0;
        char currentOperator = '+';

        while (currentIndex < expression.Length)
        {
            if (expression[currentIndex] == ' ')
            {
                currentIndex++;
                continue;
            }

            if (Char.IsDigit(expression[currentIndex]))
            {
                int number = 0;
                while (currentIndex < expression.Length && Char.IsDigit(expression[currentIndex]))
                {
                    number = number * 10 + (expression[currentIndex] - '0');
                    currentIndex++;
                }

                if (currentOperator == '+')
                    result += number;
                else if (currentOperator == '-')
                    result -= number;
            }
            else if (expression[currentIndex] == '+')
            {
                currentOperator = '+';
                currentIndex++;
            }
            else if (expression[currentIndex] == '-')
            {
                currentOperator = '-';
                currentIndex++;
            }
            else
            {
                throw new ArgumentException("Выражение содержит недопустимый символ: " + expression[currentIndex]);
            }
        }
        return result;
    }
}