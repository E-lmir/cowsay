using cowsaу;

namespace cowsay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cowMessageLeftBorder = "| ";
            var cowMessageRightBorder = " |";
            var cowMessage = cowMessageLeftBorder + (args.Length > 0 ? args[0] : " ") + cowMessageRightBorder;
            var cowMessageLine = "+" + new string('-', cowMessage.Length - 2) + "+";

            var cow = @"
    \
     \ ^__^
      \(oo)\________
       (__)\        )\/\
           ||-----w |
           ||      ||
            ";

            Cowsole.WriteLine(cowMessageLine);
            Cowsolе.WriteLine(cowMessage);
            Cowsole.Write(cowMessageLine);
            Cowsole.WriteLine(cow);
        }
    }
}
