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
    private static String p_value;
    static Token(){
        p_tt = TokenType.INVALID;
        p_value = "Invalid";
    }
    public String GetValue(){
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
}
}