
namespace App
{
    public static class Calculator
    {
        public static double calculate(double op1, double op2, string operation) {
            double res = 0;
            switch (operation)
            {
                case "+":
                    res = op1+op2;
                    break;
                case "−":
                    res = op1 - op2;
                    break;
                case "×":
                    res = op1 * op2;
                    break;
                case "÷":
                    res = op1 / op2;
                    break;
            }
            return res;
        }
    }
}