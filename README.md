# LSDscreensaver
#inspired by LSD.COM virus graphics

# LSD.COM-inspired-screensavers
### download .exe and rename .exe to .scr and place in C:\windows\system32\ , or compile the .cs with below command



###  run below command to compile .cs into an exe   
C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /t:exe /out:LSDscreensaver1.exe LSDscreensaver1.cs /unsafe



### open windows settings, search screensaver, select turn screensaver on or off, select screensaver name from dropdown and select time for start



###### note on /unsafe flag at https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/unsafe-code
##### C# supports an unsafe context, in which you can write unverifiable code. In an unsafe context, code can use pointers, 
##### allocate and free blocks of memory, and call methods using function pointers. Unsafe code in C# isn't necessarily dangerous; 
##### it's just code whose safety can't be verified.
