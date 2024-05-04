#!/bin/bash

set -e

dotnet publish -c Release -r linux-x64
warp -a linux-x64 -i ./bin/Release/net8.0/linux-x64/publish -e Zephyrscript -o bin/zephyr