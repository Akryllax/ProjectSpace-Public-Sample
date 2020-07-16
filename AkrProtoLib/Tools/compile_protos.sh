#!/bin/bash

rm -rf ../ProtoMessages/Generated/*.cs;
/c/Users/alexm/Downloads/protoc-3.11.2-win64/bin/protoc.exe -I=.. --csharp_out=../ProtoMessages/Generated ../ProtoMessages/Templates/*.proto;