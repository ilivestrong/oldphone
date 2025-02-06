# OldPhone

This application is simple simulation of a keypad from old phones where each button corresponds to 3-4 alphabets. It also had '0' key for space and a '\*' key for backspace.

Each button can be pressed multiple times which will show the character at the corresponding index. Moving past the index will reset it to the first character on the button.

'\*' key represents backspace and will erase one character.

## Overview

The solution contains 2 projects:

- **oldphone** - This contains the core functionality of the Keypad.

- **Oldphone_tests** - This contains the unit test for the project. All the possible cases have been covered including the ones given in original test.
