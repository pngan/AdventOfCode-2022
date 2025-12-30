# Advent Of Code 2022

C# solutions to the [Advent Of Code 2022](https://adventofcode.com/) Puzzles.

## Get input files
- The convenience script `Get-AdventOfCodeInput.ps1` can be used to download puzzle inputs, using the Advent of Code API.
- Because the script is not digitally signed, you must bypass Windows security policy using
```powershell
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
```
An example to get the input files for Year 2022 and Day 1 is:
```powershell
 .\Get-AdventOfCodeInput.ps1 -Password <password> -Cookie <cookie> -Year 2022 -Day 1
```
 - The cookie required by this script can be obtained [as follows](https://github.com/GreenLightning/advent-of-code-downloader?tab=readme-ov-file#how-do-i-get-my-session-cookie)

<!-- TIMINGS START -->

## Timings

| Day | Name | Type | Part 1 (ms) | Part 2 (ms) |
|---:|---|---|---:|---:|
| [01](code/day01.cs) | [Calorie Counting](https://adventofcode.com/2022/day/1) | Sorting/Search | 17 | 7 |
| [02](code/day02.cs) | [Rock Paper Scissors](https://adventofcode.com/2022/day/2) | Unknown | 2 | 1 |
| [03](code/day03.cs) | [Rucksack Reorganization](https://adventofcode.com/2022/day/3) | Unknown | 0 | 3 |
| [04](code/day04.cs) | [Camp Cleanup](https://adventofcode.com/2022/day/4) | Parsing | 5 | 3 |
| [12](code/day12.cs) | [Hill Climbing Algorithm](https://adventofcode.com/2022/day/12) | Graph | 76 | 19 |

<!-- TIMINGS END -->



