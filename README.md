# yt-dlp Drag-n-Drop

**WARNING - Vibe Coded**
License: MIT
Repo: [Mad9Scientist/yt-dlp-dnd](https://www.github.com/mad9scientist/yt-dlp-dnd)

A 'simple' C# WinForm App to drag and drop url/links to download videos (works with services that are supported by 
yt-dlp).


## How To Use

0. Have Prereq Installed
1. Download (or build) Executable/Binary Release
    1.1 Update the config.ini file to your needs
2. Open executable
3. Drag the url from your browser to the window
4. Wait for Download
5. Enjoy your video


## Pre Req

* Windows 10/11 (Tested on Win11)
* [Dot Net v9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0/runtime)
    * `winget install Microsoft.DotNet.Runtime.9`
* [yt-dlp](https://github.com/yt-dlp/yt-dlp) - Public Domain
    * Stable: `winget install yt-dlp.yt-dlp`
    * nightly: `winget install yt-dlp.yt-dlp.nightly`
* [ffmpeg](https://ffmpeg.org/) - GPL
    * `winget install Gyan.FFmpeg.Essentials`

## Setting

If `yt-dlp` and `ffmpeg` are in your Windows Path, you only need to update the download folder. If you have these 
programs in different locations, include full path to the particular programs' executable.

`config.ini`
```ini
[Paths]
yt_dlp = <Defaults to System Path yt-dlp>
ffmpeg = <Defaults to System Path ffmpeg> # Not implemented yet

[Output]
download_folder = <Defaults to Desktop>
```

## Changelog

* 2025-April-19: Initial Released (ver. 0.1)