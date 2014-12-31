#!/bin/sh

pushd src
sml <check.sml | less
popd

