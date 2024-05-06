#!/bin/bash

set -xe

dotnet publish -c Release -r linux-x64
warp -a linux-x64 -i ./bin/Release/net8.0/linux-x64/publish -e Zephyrscript -o bin/zephyr

mkdir -p ./bin/Zephyr
nasm -felf64 ./src/lexer.asm -o ./bin/Zephyr/lexer.o
nasm -felf64 ./src/main.asm -o ./bin/Zephyr/main.o
nasm -felf64 ./src/token.asm -o ./bin/Zephyr/token.o
nasm -felf64 ./src/util.asm -o ./bin/Zephyr/util.o

gcc -o ./zephyr  ./bin/Zephyr/*.o