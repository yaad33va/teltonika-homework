#!/bin/bash
OUTPUT_FILE="generated_passwords.txt"
> "$OUTPUT_FILE"
for username in "$@"; do
    new_pass=$(< /dev/urandom tr -dc 'A-Za-z0-9' | head -c12)
    echo "$username:$new_pass" >> "$OUTPUT_FILE"
done