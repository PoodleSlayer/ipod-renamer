# ipod-renamer aka SongRenamer

Small utility script for grabbing song titles out of metadata and renaming the files with the title.

## But why?

A friend of mine had an old iPod Nano (4th gen I think? with the clicky wheel) with a bunch of songs on it that she wanted to copy over to her new phone. When I finally managed to copy the music folder off the iPod I found out all the songs had been renamed to these weird 4-character strings like `"AB3F.mp3"` and were in folders like `"F01"`, `"F02"`, etc.

From reading around online I think this was either an iTunes thing or just how those old iPods kept track of files with an internal databse. Some people had managed to reverse engineer that database and get the song info that way, but I just took the lazy way and brute-forced the metadata out of the files themselves with the help of the wonderful [TagLib library](https://github.com/mono/taglib-sharp).

## Contributions

Feel free to take this and do whatever you want with it. I probably won't maintain this really unless I get bored on a rainy day. It should be easy to make more generic and use it for renaming a variety of file types (videos, photos, music).
