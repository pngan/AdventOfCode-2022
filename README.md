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
| [01](code/day01.cs) | [Calorie Counting](https://adventofcode.com/2022/day/1) | Sorting/Search | 16 | 5 |
| [02](code/day02.cs) | [Rock Paper Scissors](https://adventofcode.com/2022/day/2) | Unknown | 1 | 0 |
| [03](code/day03.cs) | [Rucksack Reorganization](https://adventofcode.com/2022/day/3) | Unknown | 0 | 2 |
| [04](code/day04.cs) | [Camp Cleanup](https://adventofcode.com/2022/day/4) | Parsing | 1 | 0 |
| [05](code/day05.cs) | [Supply Stacks](https://adventofcode.com/2022/day/5) | Stack | 3 | 0 |
| [06](code/day06.cs) | [Tuning Trouble](https://adventofcode.com/2022/day/6) | Unknown | 0 | 3 |
| [07](code/day07.cs) | [No Space Left On Device](https://adventofcode.com/2022/day/7) | Stack | 4 | 3 |
| [08](code/day08.cs) | [Treetop Tree House](https://adventofcode.com/2022/day/8) | Grid/Map | 16 | 10 |
| [09](code/day09.cs) | [Rope Bridge](https://adventofcode.com/2022/day/9) | Simulation | 10 | 1 |
| [10](code/day10.cs) | [Cathode-Ray Tube](https://adventofcode.com/2022/day/10) | Unknown | 0 | 0 |
| [11](code/day11.cs) | [Monkey in the Middle](https://adventofcode.com/2022/day/11) | Unknown | 0 | 0 |
| [12](code/day12.cs) | [Hill Climbing Algorithm](https://adventofcode.com/2022/day/12) | Graph | 38 | 21 |

<!-- TIMINGS END -->















