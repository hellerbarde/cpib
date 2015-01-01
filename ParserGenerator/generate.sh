#!/bin/bash

pushd ../../Compiler/Compiler/Parser;
rm Parser.cs;
rm Interfaces/*.cs;
rm Implementations/*.cs;
popd;

pushd src;
./generate.py ../parsetable.txt ../../Compiler/Compiler/Parser/{Parser.cs,Interfaces,Implementations};
popd;
