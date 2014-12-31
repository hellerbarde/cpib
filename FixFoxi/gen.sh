#!/bin/sh

pushd src
sml <gen.sml >../parsetable.txt
popd

echo "dont forget to clean up parsetable.txt"
