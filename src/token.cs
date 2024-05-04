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
public enum TokenType{
    INVALID=0,
    EOF=1,

    OPENPAREN = '(',
    CLOSEPAREN = ')',
    OPENBRACE = '{',
    CLOSEBRACE = '}',
    SEMICOLON = ';',
    COLON = ':',
    AT='@',
    COMMA=',',
    LESS = '<',
    GREATER = '>',
    EQUAL='=',
    STAR='*',
    PLUS='+',
    MINUS='-',
    SLASH='/',
    DOT='.',

    __MULTIBYTE_START=255,

    IDENTIFIER,
    STRING,
    NUMBER,
    FLOAT,

    RIGHT_ARROW,
    LESSEQUAL,
    LESSLESSEQUAL,
    LESSLESS,
    GREATEREQUAL,
    GREATERGREATEREQUAL,
    GREATERGREATER,
    EQUALEQUAL,
    PLUSPLUS,
    MINUSMINUS,
    
    __KEYWORDS_START,

    };
public class Token{
    private static TokenType p_tt;
    private static String? p_value;
    public Token(){
        p_tt = TokenType.INVALID;
        p_value = "Invalid";
    }
    public Token(Token tok){
        p_tt = tok.GetTokenType();
        p_value = tok.GetValue();
    }
    public String? GetValue(){
        return p_value;
    }
    public TokenType GetTokenType(){
        return p_tt;
    }
    public void SetValue(String value){
        p_value = value;
    }
    public void SetTokenType(TokenType type){
        p_tt = type;
    }
    public void Print(){
        Console.WriteLine($"Value = {p_value}");
    }
}
}