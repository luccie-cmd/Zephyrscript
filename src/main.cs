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
    public static void Usage(){
        Console.WriteLine("Usage: zephyr [options] <path>");
        Console.WriteLine("Options:");
        Console.WriteLine("-h, --help");
    }
    public static void Main(String[] argv){
        if(argv.Length < 1){
            Usage();
            return;
        }
        String path = "None";
        foreach(string arg in argv){
            if(arg.Equals("-h") || arg.Equals("--help")){
                Usage();
                return;
            } else{
                if(path != "None"){
                    Console.WriteLine("ERROR: Multiple input paths provided!\n");
                    return;
                }
                path = arg;
            }
        }
        Console.WriteLine($"{path}");
        return;
    }
}
}