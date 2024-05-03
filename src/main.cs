using System;
using zephyr;

namespace zephyr{
class Zephyr{
    public static void Main(String[] argv){
        if(argv.Length < 1){
            Console.WriteLine("Usage: zephyr <path>");
            return;
        }
        String path = argv[0];
        Lexer lexer = new Lexer(Util.ReadFile(path));
        Token token = lexer.NextToken();
        while(token.GetTokenType() != TokenType.EOF){
            Console.WriteLine($"Token value = {token.GetValue()}");
            token = lexer.NextToken();
        }
    }
}
}