# BOGOSORT Demonstration of Probability
Some random junk I decided to make after one of my friends introduced me to this both extremely fast and extremely slow sorting algorithm. 

ChatGPT did assist in development.

# What is Bogosort?
Bogosort, Also known as stupidsort, is a method of sorting an array of values by a certain condition. In this program, it sorts it from least to greatest. The method in which it sorts is by continuously randomizing the layout of the array until it meets the condition. In this particular case, it is randomizing a list of 10 items, which means it is a 1 in 10<sup>10</sup>% chance of hitting the least to greatest condition **each operation.**

# How to run?
You need .NET 8.0 installed. I did not provide AOT release binaries; they were absolutely massive and included tons of junk files with them. I provided Release-published binaries for macOS ARM64 (Apple Silicon), and for Windows x64.

macOS users will need to open Terminal and do ``chmod +x bogosort-osx-arm64`` to be able to run, and Windows users will need to allow it through SmartScreen.

# Performance Tests
BOGOSORT is a good utility to test a general operations performance of a processor.

| CPU         | Host System  | Operations/s  | OS |
| :---        | :---         |          ---: | :--- |
| Apple M1    | Apple MacBook Air (2020) |12,500,000| macOS Sonoma 14.3.1 |
| Apple M2    | Apple MacBook Pro (2022) |14,700,000| macOS Sonoma 14.1 |
| Intel Core i7-8700| Lenovo ThinkCentre (2018) |8,000,000| Windows 10 22H2 |
| AMD Ryzen 7 7800X3D | Custom PC | 16,000,000 | Windows 11 22H2 |
