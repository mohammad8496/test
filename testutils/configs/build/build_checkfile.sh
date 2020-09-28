#!/bin/bash

command="curl --max-time 30 -s 'http://127.0.0.1:80/\$1-\$2/api/CIInfo/BuildDate'"
expected_result="$5"

printf "$command\n$expected_result" > checkfile.txt