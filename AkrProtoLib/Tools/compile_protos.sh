#!/bin/bash

rm -rf ../ProtoMessages/Generated/*.cs;
/c/Users/alexander/Downloads/protoc-3.8.0-win64/bin/protoc.exe -I=.. --csharp_out=../ProtoMessages/Generated ../ProtoMessages/Templates/*.proto;