# AutoLogin Intro
Using the .Net framework to set auto-login registry keys.

Can be run two different ways brienfly described below. GUI and Console

Download the .exe from release and try either method. 

# GUI
Only Requires password Pulls Domain and Current user

![Imgur Image](https://i.imgur.com/YT3vj8x.png)

# Console
Run from command using switches.
```
cmd.exe /c /Path/To/AutoLoginBuilder.exe {-h -r -u -p -d}
-----------------------------------------------------
      Welcome to the help for this auto Login
     Remember domain can be blank for localhost
      You may only ever set or remove not both


Options:
  -h, --help                 Shows help msg and exits
  -r, --remove               Removes Auto Login
  -u, --username=Required    Computer Account being set for Auto Login.
                               Required to Setup autologin
  -p, --password=Required    Password for account being set for Auto Login
                               Required to Setup autologin
  -d, --domain=Optional      Domain for account being set for Auto Login.
                               Optional Blank if not in domain add for Domain
-----------------------------------------------------
```
