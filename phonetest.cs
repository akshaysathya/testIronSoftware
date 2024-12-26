using System;
using System.Text;

public class Test
{
    private static readonly string[] keypadArray =
    {
        " ", "", "ABC", "DEF", "GHI", "JKL",
        "MNO", "PQRS", "TUV", "WXYZ"
    };

    public static string OldPhonePad(string input)
    {
        if (string.IsNullOrEmpty(input) || !input.EndsWith("#"))
            return "Invalid input";

        StringBuilder result = new StringBuilder();
        char lastChar = '\0';
        int count = 0;

        foreach (char i in input)
        {
            if (i == '#') break;
            if (i == '*')
            {
                if (result.Length > 0) result.Length--;
            }
            else
            {
                if (i == lastChar)
                {
                    count++;
                }
                else
                {
                    AppendChar(result, lastChar, count);
                    lastChar = i;
                    count = 1;
                }
            }
        }
        AppendChar(result, lastChar, count);

        return result.ToString();
    }

    private static void AppendChar(StringBuilder result, char lastChar, int count)
    {
        if (char.IsDigit(lastChar))
        {
            string letters = keypadArray[int.Parse(lastChar.ToString())];
            result.Append(letters[(count - 1) % letters.Length]);
        }
    }

    public static void Main(string[] args)
    {
        //Console.WriteLine("Enter the OldPhonePad input:");
        //string input = Console.ReadLine();
        Console.WriteLine(OldPhonePad("8 88777444666*664#"));
        //Console.WriteLine(OldPhonePad(input));
    }
}
