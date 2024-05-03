# Zephyr Script

Zephyr script (pronounced zyper skript) is an interpreted scripting language inspired by zig.

# Requirements
Any C# compiler (we like dotnet)  
[warp](https://github.com/dgiagio/warp/releases)
### Installation
1. Install [warp](https://github.com/dgiagio/warp/releases) (use linux-x64 for linux, windows-x64 for windows and mac-x64 for mac)
2. Install [dotnet](https://dotnet.microsoft.com/en-us/download) (follow the instructions provided by microsoft)

# Building
0. Make sure warp and dotnet are in `$PATH`
1. Make [build.sh](build.sh) executable  
This version of Zephyr uses a .sh file  
`
$ chmod +x ./build.sh
`
2. Run [build.sh](build.sh)  
`
$ ./build.sh
`

# Running 
If you followed the building instructions correctly you should have a file named "Zephyr" inside of the bin folder  
run it by using  
`
$ ./bin/zephyr [options...] file
`  
run `./bin/zephyr --help` for available options
# Contributing
1. Fork the repository
2. Make your changes
3. Create a pull request

# License
Zephyr is licensed under the MIT license