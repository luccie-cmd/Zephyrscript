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

namespace zephyr{
public class Lexer{
    private readonly String p_data;
    private static UInt64 p_pos;
    private static char p_c;
    private static bool p_errored = false;
    public Lexer(String data){
        p_data = data;
        p_pos = 0;
        Advance();
    }

    private void Advance(){
        try{
            p_c = p_data[(int)p_pos++];
        } catch (System.Exception){
            p_c = '\0';
        }
    }
    private void SkipWhiteSpace(){
        while(char.IsWhiteSpace(p_c)){
            Advance();
        }
    }
    private Token NextIdentifier(){
        Token token = new();
        token.SetTokenType(TokenType.IDENTIFIER);
        String value = "";
        while(char.IsLetterOrDigit(p_c) || p_c == '_'){
            value += p_c;
            Advance();
        }
        token.SetValue(value);
        return token;
    } 
    private Token NextString(){
        Token token = new();
        token.SetTokenType(TokenType.STRING);
        Advance();
        String value = "";
        while(p_c != '"' && p_c != '\0'){
            value += p_c;
            Advance();
        }
        if(p_c == '\0'){
            Console.WriteLine($"ERROR: Unterminated string literal\n");
            p_errored = true;
        }
        Advance();
        token.SetValue(value);
        return token;
    }
    private Token NextNumber(){
        Token token = new();
        token.SetTokenType(TokenType.NUMBER);
        String value = "";
        while(Char.IsDigit(p_c)){
            value += p_c;
            Advance();
        }
        if(p_c == '.'){
            value += p_c;
            Advance();
            while(Char.IsDigit(p_c)){
                value += p_c;
                Advance();
            }
            token.SetTokenType(TokenType.FLOAT);
        }
        token.SetValue(value);
        return token;
    }
    public Token NextToken(){
        SkipWhiteSpace();
        Token token = new(); // Initialize the token variable
        if(p_c == '\0'){
            token.SetTokenType(TokenType.EOF);
            return token;
        }
        while(p_c == '/' && p_data[(int)p_pos] == '/'){
            Advance();
            while(p_c != '\n'){
                Advance();
            }
            SkipWhiteSpace();
        }
        switch(p_c){
            case ';':
            case '.':
            case '(':
            case ')':
            case '{':
            case '}':
            case ':':
            case '@': {
                token.SetTokenType((TokenType)p_c);
                token.SetValue(new String(p_c, 1));
                Advance();
            } break;
            case '=': {
                Advance();
                if(p_c == '>'){
                    Advance();
                    token.SetTokenType(TokenType.RIGHT_ARROW);
                    token.SetValue("=>");
                } else{
                    token.SetTokenType(TokenType.EQUAL);
                    token.SetValue("=");
                }
            } break;
            case 'a': case 'b': case 'c': case 'd': case 'e':
            case 'f': case 'g': case 'h': case 'i': case 'j':
            case 'k': case 'l': case 'm': case 'n': case 'o':
            case 'p': case 'q': case 'r': case 's': case 't':
            case 'u': case 'v': case 'w': case 'x': case 'y':
            case 'z':
            case 'A': case 'B': case 'C': case 'D': case 'E':
            case 'F': case 'G': case 'H': case 'I': case 'J':
            case 'K': case 'L': case 'M': case 'N': case 'O':
            case 'P': case 'Q': case 'R': case 'S': case 'T':
            case 'U': case 'V': case 'W': case 'X': case 'Y':
            case 'Z':
            case '_': {
                token = NextIdentifier();
            } break;
            case '0': case '1': case '2': case '3': case '4':
            case '5': case '6': case '7': case '8': case '9': {
                token = NextNumber();
            } break;
            case '"': {
                token = NextString();
            } break;
            default: {
                Console.WriteLine($"ERROR: Unexpected character '{p_c}'");
                p_errored = true;
                Advance();
                token = NextToken();
            } break;
        }
        return token;
    }
    public Token[] AllTokens(){
        List<Token> tokensList = new List<Token>();
        Token token = NextToken();
        while(token.GetTokenType() != TokenType.EOF){
            tokensList.Add(new Token(token));
            token = NextToken();
        }
        return tokensList.ToArray();
    }
    public bool GetErrorStatus(){
        return p_errored;
    }
}
}