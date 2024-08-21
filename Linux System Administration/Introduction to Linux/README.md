# Linux and Virtualization Cheat Sheet

## Linux Basics

| Concept                    | Description                           |
| -------------------------- | ------------------------------------- |
| Linux                      | A kernel, not a complete OS           |
| Linux Distribution         | Kernel + Utilities                    |
| Main Distribution Families | Debian, Fedora/Red Hat, openSUSE/SUSE |

## Virtualization

| Term                 | Description                                       |
| -------------------- | ------------------------------------------------- |
| Host OS              | The main operating system on the physical machine |
| Virtual Machine (VM) | A software-based emulation of a computer          |
| Guest OS             | The operating system running inside a VM          |
| Hypervisor           | Software that creates and runs virtual machines   |

## Basic Linux Commands

| Command    | Description                               |
| ---------- | ----------------------------------------- |
| `pwd`      | Print working directory                   |
| `ls`       | List directory contents                   |
| `cd`       | Change directory                          |
| `cat`      | Concatenate and display file content      |
| `date`     | Display or set date and time              |
| `cal`      | Display a calendar                        |
| `hostname` | Show or set the system's hostname         |
| `uname`    | Print system information                  |
| `uptime`   | Show how long the system has been running |
| `history`  | Display command history                   |
| `exit`     | Exit the shell                            |
| `logout`   | Exit a login shell                        |
| `reboot`   | Reboot the system                         |
| `poweroff` | Shut down the system                      |
| `shutdown` | Schedule a system shutdown                |
| `wall`     | Send a message to all users               |

## Environment Variables

| Variable   | Description                                |
| ---------- | ------------------------------------------ |
| `PATH`     | Directories to search for executable files |
| `PWD`      | Current working directory                  |
| `HOSTNAME` | Name of the current host                   |
| `USER`     | Current user name                          |
| `HOME`     | Home directory of the current user         |
| `SHELL`    | Path to the user's preferred shell         |

## Shell Keyboard Shortcuts

| Shortcut | Action                            |
| -------- | --------------------------------- |
| Ctrl + A | Move to beginning of line         |
| Ctrl + E | Move to end of line               |
| Ctrl + L | Clear the screen                  |
| Ctrl + C | Interrupt current process         |
| Ctrl + Z | Suspend current process           |
| Ctrl + D | Exit the terminal                 |
| Tab      | Auto-complete command or filename |

## Connecting to Linux

| Method           | Description                                            |
| ---------------- | ------------------------------------------------------ |
| Local VM Console | Direct access, no network required                     |
| Remote SSH       | Requires network and SSH service, allows file transfer |
