# Linux Command Cheat Sheet

## Environment and Shell Commands

| Command    | Description                                                              | Example                                          | Parameters                                      |
|------------|--------------------------------------------------------------------------|--------------------------------------------------|------------------------------------------------|
| `set`      | Display/set shell options and variables                                  | `set -o vi`                                      | **`-o`**: Enable an option.<br>**`+o`**: Disable an option.<br>**`-e`**: Exit on error.<br>**`-x`**: Print commands before executing. |
| `env`      | Print environment variables; run a command in a modified environment     | `env VAR=value command`                          | **`-i`**: Start with an empty environment.<br>**`-u`**: Unset a variable before running the command. |
| `printenv` | Print environment variables                                              | `printenv PATH`                                  | *(none)*                                       |
| `unset`    | Unset shell variables or functions                                       | `unset MY_VAR`                                   | *(none)*                                       |
| `export`   | Set export attribute for shell variables                                 | `export PATH=/new/path:$PATH`                    | *(none)*                                       |
| `alias`    | Define or display aliases                                                | `alias ll='ls -la'`                              | *(none)*                                       |
| `unalias`  | Remove aliases                                                           | `unalias ll`                                     | **`-a`**: Remove all aliases.                  |
| `type`     | Display information about command type                                   | `type ls`                                        | **`-a`**: Display all locations containing an executable of that name. |
| `which`    | Locate a command                                                         | `which ls`                                       | **`-a`**: Print all matching pathnames.         |
| `whereis`  | Locate the binary, source, and manual page files for a command           | `whereis ls`                                     | *(none)*                                        |
| `hash`     | Display or manipulate the command hash table                             | `hash`                                           | *(none)*                                        |

## File and Directory Commands

| Command  | Description                                  | Example                     | Parameters                                      |
|----------|----------------------------------------------|-----------------------------|------------------------------------------------|
| `ls`     | List directory contents                      | `ls -l`                      | **`-a`**: Show all files, including hidden.<br>**`-l`**: Use long listing format.<br>**`-h`**: Human-readable sizes.<br>**`-R`**: List directories recursively. |
| `cd`     | Change directory                             | `cd /home/user`              | *(none)*                                       |
| `pwd`    | Print working directory                      | `pwd`                        | *(none)*                                       |
| `mkdir`  | Make directories                             | `mkdir new_dir`              | **`-p`**: Create parent directories as needed.<br>**`-v`**: Verbose output. |
| `rmdir`  | Remove empty directories                     | `rmdir old_dir`              | *(none)*                                       |
| `touch`  | Change file timestamps or create empty files | `touch newfile.txt`          | **`-a`**: Change only access time.<br>**`-m`**: Change only modification time.<br>**`-t`**: Set time explicitly. |
| `cp`     | Copy files and directories                   | `cp file1.txt /path/to/dir`  | **`-r`**: Recursive copy.<br>**`-v`**: Verbose output.<br>**`-i`**: Prompt before overwrite. |
| `mv`     | Move/rename files and directories            | `mv file1.txt file2.txt`     | **`-i`**: Prompt before overwrite.<br>**`-v`**: Verbose output.<br>**`-n`**: No clobber (don't overwrite existing files). |
| `rm`     | Remove files or directories                  | `rm file1.txt`               | **`-r`**: Remove directories recursively.<br>**`-f`**: Force removal.<br>**`-v`**: Verbose output. |
| `ln`     | Create links between files                   | `ln -s file1.txt linkname`   | **`-s`**: Create a symbolic link.<br>**`-f`**: Force creation of the link.<br>**`-v`**: Verbose output. |

## File Information Commands

| Command  | Description                        | Example                       | Parameters                                      |
|----------|------------------------------------|-------------------------------|------------------------------------------------|
| `file`   | Determine file type                | `file script.sh`              | *(none)*                                       |
| `stat`   | Display file or file system status | `stat file1.txt`              | **`-f`**: Display filesystem status.<br>**`-L`**: Follow symlinks. |

## User and Group Management

| Command    | Description                             | Example                     | Parameters                                      |
|------------|-----------------------------------------|-----------------------------|------------------------------------------------|
| `useradd`  | Create a new user                       | `useradd newuser`           | **`-m`**: Create a home directory.<br>**`-d`**: Specify home directory.<br>**`-s`**: Specify shell. |
| `usermod`  | Modify a user account                   | `usermod -l newname oldname`| **`-l`**: Change login name.<br>**`-d`**: Change home directory.<br>**`-G`**: Add user to groups. |
| `userdel`  | Delete a user account                   | `userdel newuser`           | **`-r`**: Remove home directory and mail spool. |
| `groupadd` | Create a new group                      | `groupadd newgroup`         | *(none)*                                       |
| `groupmod` | Modify a group                          | `groupmod -n newname oldname`| *(none)*                                      |
| `groupdel` | Delete a group                          | `groupdel oldgroup`         | *(none)*                                       |
| `passwd`   | Change user password                    | `passwd newuser`            | *(none)*                                       |
| `chage`    | Change user password expiry information | `chage -l newuser`          | **`-l`**: List password aging information.<br>**`-E`**: Set account expiration date.<br>**`-M`**: Set maximum number of days before password change. |
| `id`       | Print user and group IDs                | `id`                        | **`-u`**: Print only the effective user ID.<br>**`-g`**: Print only the effective group ID.<br>**`-G`**: Print all group IDs. |
| `adduser`  | Add a user interactively (Debian/Ubuntu)| `sudo adduser newuser`      | *(none)*                                        |
| `addgroup` | Add a group (Debian/Ubuntu)             | `sudo addgroup newgroup`    | *(none)*                                        |

## Access Rights

| Command  | Description                           | Example                       | Parameters                                      |
|----------|---------------------------------------|-------------------------------|------------------------------------------------|
| `chmod`  | Change file mode bits (permissions)   | `chmod 755 file1.txt`         | **`-R`**: Change permissions recursively.<br>**`-v`**: Verbose output. |
| `chown`  | Change file owner and group           | `chown user:group file1.txt`  | **`-R`**: Change owner recursively.<br>**`-v`**: Verbose output. |
| `chgrp`  | Change group ownership                | `chgrp group file1.txt`       | **`-R`**: Change group recursively.<br>**`-v`**: Verbose output. |
| `umask`  | Set default permissions for new files | `umask 022`                   | *(none)*                                       |

## System Information

| Command   | Description                                   | Example                     | Parameters                                      |
|-----------|-----------------------------------------------|-----------------------------|------------------------------------------------|
| `uname`   | Print system information                      | `uname -a`                  | **`-a`**: Print all system information.<br>**`-r`**: Print kernel release.<br>**`-n`**: Print network node hostname. |
| `whoami`  | Print effective user ID                       | `whoami`                    | *(none)*                                       |
| `who`     | Show who is logged on                         | `who`                       | **`-H`**: Print column headers.<br>**`-q`**: Quick format (names only). |
| `w`       | Show who is logged on and what they are doing | `w`                         | **`-h`**: Omit header.<br>**`-u`**: Show processes for logged-in users.<br>**`-s`**: Short format. |
| `last`    | Show listing of last logged in users          | `last`                      | **`-n`**: Limit number of lines.<br>**`-R`**: Display hostnames in short format. |

## Help Commands

| Command    | Description                                   | Example                     | Parameters                                      |
|------------|-----------------------------------------------|-----------------------------|------------------------------------------------|
| `man`      | Display system manual pages                   | `man ls`                    | **`-k`**: Search manual pages.<br>**`-f`**: Display short descriptions.<br>**`-M`**: Specify manpath. |
| `info`     | Read Info documents                           | `info coreutils`            | *(none)*                                       |
| `whatis`   | Display one-line manual page descriptions     | `whatis ls`                 | *(none)*                                       |
| `apropos`  | Search the manual page names and descriptions | `apropos copy`              | **`-e`**: Search for exact match.<br>**`-l`**: Display results in long format. |

## System Information and Session Management

| Command    | Description                                                              | Example                                          | Parameters                                      |
|------------|--------------------------------------------------------------------------|--------------------------------------------------|------------------------------------------------|
| `su`       | Switch user or become superuser                                          | `su - root`                                      | **`-`**: Provide an environment similar to a real login. |
| `sudo`     | Execute a command as another user (typically as superuser)               | `sudo command`                                   | **`-u`**: Specify the user to execute as.       |
