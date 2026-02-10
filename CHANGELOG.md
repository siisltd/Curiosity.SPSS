# Changelog

## [1.3.1] - 2026-02-3010

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
