# Changelog

## [1.3.3] - 2026-10-17

### Fixed

- Fixed `SpssFileFormatException` "There can be no more than 999 segment continuation variables with se same 5 letter name" when very long string variables with the same first 5 bytes of the name need more than 999 continuation segments in total: such a variable now gets a generated short name with its own segment numbering.

## [1.3.2] - 2026-06-30

### Fixed

- Bug fix: The function that calculates the displayed width of columns has been corrected.

## [1.3.1] - 2026-02-10

### Fixed

- Fixed writing a .sav file with empty mrsets list

## [1.3.0] - 2026-01-30

### Added

- Added support for writing Multuple Response Sets (MRSETS) with header subtype 7 supported by SPSS before version 14.

## [1.2.2] - 2023-11-13

### Fixed

- #2: Fixed incorrect variable name trimming: added removing of `\0` special character.

## [1.2.1] - 2021-11-09

### Added

- Added option to leaving stream open in `SavFileWriter`.

## [1.0] - 2020-02-20

Forked from [SPSS-.NET-Reader](https://github.com/fbiagi/SPSS-.NET-Reader) 

### Changed

- Ported to `netstandard2.0`
