# Linux Command Cheat Sheet

## Environment and Directory Commands

| Command    | Description                                                              | Example                                          | Parameters                                      |
|------------|--------------------------------------------------------------------------|--------------------------------------------------|------------------------------------------------|
| `pwd`      | Print name of the current/working directory                              | `pwd`                                            | **`-L`**: Use logical path.<br>**`-P`**: Use physical path. |
| `ls`       | List directory contents                                                  | `ls -l`                                          | **`-a`**: Show hidden files.<br>**`-l`**: Long listing format.<br>**`-h`**: Human-readable sizes.<br>**`-R`**: Recursively list subdirectories. |
| `cd`       | Change the current directory                                             | `cd /etc`                                        | *(none)*                                       |
| `mkdir`    | Create new directories                                                   | `mkdir new_directory`                            | **`-p`**: Create parent directories as needed.<br>**`-v`**: Verbose output. |
| `rmdir`    | Remove empty directories                                                 | `rmdir old_directory`                            | *(none)*                                       |
| `touch`    | Create or update a file’s timestamp                                      | `touch file.txt`                                 | **`-a`**: Change only the access time.<br>**`-m`**: Change only the modification time. |
| `cp`       | Copy files or directories                                                | `cp file.txt /new/location/`                     | **`-r`**: Recursive copy for directories.<br>**`-v`**: Verbose output.<br>**`-i`**: Prompt before overwrite. |
| `mv`       | Move or rename files                                                     | `mv file.txt /new/location/`                     | **`-i`**: Prompt before overwrite.<br>**`-v`**: Verbose output.<br>**`-n`**: Do not overwrite. |
| `rm`       | Remove files or directories                                              | `rm file.txt`                                    | **`-r`**: Remove directories recursively.<br>**`-f`**: Force removal.<br>**`-v`**: Verbose output. |
| `ln`       | Create hard or symbolic links                                            | `ln -s file.txt symlink`                         | **`-s`**: Create symbolic link.<br>**`-v`**: Verbose output.<br>**`-f`**: Force the creation of the link. |

## File Viewing and Editing Commands

| Command    | Description                                                              | Example                                          | Parameters                                      |
|------------|--------------------------------------------------------------------------|--------------------------------------------------|------------------------------------------------|
| `cat`      | Concatenate and display file contents                                    | `cat file.txt`                                   | **`-n`**: Show line numbers.<br>**`-T`**: Show tabs as `^I`. |
| `date`     | Print or set the system date and time                                    | `date +%Y-%m-%d`                                 | **`+FORMAT`**: Custom date format.<br>**`-u`**: Use UTC time. |
| `cal`      | Display a calendar                                                       | `cal`                                            | **`-3`**: Show the previous, current, and next month. |
| `echo`     | Display a line of text                                                   | `echo "Hello World"`                             | **`-n`**: Do not output the trailing newline. |
| `history`  | Show the command history                                                 | `history`                                        | **`-c`**: Clear the history.<br>**`-w`**: Write the history to the history file. |

## System Information Commands

| Command    | Description                                                              | Example                                          | Parameters                                      |
|------------|--------------------------------------------------------------------------|--------------------------------------------------|------------------------------------------------|
| `uname`    | Print system information                                                 | `uname -a`                                       | **`-a`**: Print all system information.<br>**`-r`**: Print kernel release.<br>**`-n`**: Print network node hostname. |
| `uptime`   | Show how long the system has been running                                | `uptime`                                         | **`--pretty`**: Show uptime in human-readable format. |
| `hostname` | Get or set the system hostname                                           | `hostname`                                       | **`--short`**: Show short hostname. |
| `hostnamectl`| Control the system hostname                                             | `hostnamectl set-hostname new-hostname`          | *(none)*                                       |
| `df`       | Report disk space usage                                                  | `df -h`                                          | **`-h`**: Human-readable sizes.<br>**`-T`**: Show file system type. |
| `free`     | Display memory usage                                                     | `free -h`                                        | **`-h`**: Human-readable sizes. |
| `whoami`   | Print the current user                                                   | `whoami`                                         | *(none)*                                       |

## System Management Commands

| Command    | Description                                                              | Example                                          | Parameters                                      |
|------------|--------------------------------------------------------------------------|--------------------------------------------------|------------------------------------------------|
| `reboot`   | Reboot the system                                                        | `sudo reboot`                                    | *(none)*                                       |
| `shutdown` | Shut down or reboot the system                                           | `sudo shutdown -h now`                           | **`-h`**: Halt after shutdown.<br>**`-r`**: Reboot after shutdown.<br>**`+TIME`**: Delay shutdown. |
| `poweroff` | Power off the system                                                     | `sudo poweroff`                                  | *(none)*                                       |
| `halt`     | Halt the machine                                                         | `sudo halt`                                      | **`-p`**: Power off after halting. |
| `logout`   | Exit the current login session                                           | `logout`                                         | *(none)*                                       |

## Network Commands

| Command    | Description                                                              | Example                                          | Parameters                                      |
|------------|--------------------------------------------------------------------------|--------------------------------------------------|------------------------------------------------|
| `ping`     | Test network connectivity                                                | `ping google.com`                                | **`-c`**: Specify the number of packets to send.<br>**`-i`**: Set interval between packets. |
| `ifconfig` | Configure network interfaces (deprecated, use `ip`)                      | `ifconfig eth0 up`                               | *(none)*                                       |
| `ip`       | Show/manipulate routing, devices, and tunnels                            | `ip addr show`                                   | **`addr`**: Show IP addresses.<br>**`link`**: Show network device status. |
| `netstat`  | Show network connections, routing tables, and statistics                 | `netstat -tuln`                                  | **`-t`**: Show TCP connections.<br>**`-u`**: Show UDP connections.<br>**`-l`**: Show listening services. |
| `ssh`      | Open SSH sessions to remote machines                                     | `ssh user@hostname`                              | **`-p`**: Specify port.<br>**`-i`**: Use identity file. |
