namespace PalindromeExcercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Paliandrome");
            test(Console.ReadLine());
        }

        public static string test(string tr)
        {
            char[] chars = tr.ToCharArray();
            Array.Reverse(chars);
            string revTr = new string(chars);
            Console.WriteLine(tr == revTr ? "true" : "false");
            return revTr;
        }
    }
}