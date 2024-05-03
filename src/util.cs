using System;

namespace zephyr{
public class Util{
    public static String ReadFile(String path){
        if (!File.Exists(path)){
            System.Console.Write($"ERROR: File {path} doesn't exist\n");
            System.Environment.Exit(1);
        }
        return File.ReadAllText(path);
    }
};
};