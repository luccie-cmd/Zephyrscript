# Zephyr Script

Zephyr script (pronounced zyper skript) is an interpreted scripting language inspired by zig.  
Zephyr was made by me to give me a litle more knowledge on the assembly language  
for anyone asking no I did not compile it from C or any other language.

# Requirements
Any x86_64 compiler (we like nasm)
A linux machine (windows does not like syscalls and x86_64 asm)
### Installation
Windows:
1. Go to the NASM website: [NASM Official Website](https://www.nasm.us/pub/nasm/releasebuilds/2.16.03/win64/).  
2. Download the NASM installer for Windows.
3. Double-click the downloaded installer file to run it.
4. Follow the on-screen instructions to complete the installation process.
Linux:
1. Open a terminal window and run the following command:

`
$ sudo apt-get install nasm
`

Mac:
1. Open a terminal window and run the following command:

`
$ brew install nasm

`

# Building
0. Make sure nasm is in `$PATH`
1. Compile `build.asm`
`
$ nasm -f elf64 build.asm
`
2. Link `build.asm` with libc (build.asm is the only thing that uses libc. The compiler is a completely standalone program)

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