/*Copyright (c) 2024 luccie-cmd

Permission is hereby granted, free of charge, to any person obtaining a
copy of this software and associated documentation files (the "Software"), 
to deal in the Software without restriction, including without limitation
the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.*/
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