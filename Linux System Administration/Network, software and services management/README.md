Linux Command Cheat Sheet

## Network Configuration Commands

| Command      | Description                                                    | Example                                  | Parameters                                                                                                                      |
| ------------ | -------------------------------------------------------------- | ---------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------- |
| `ip`         | Show/manipulate routing, devices, policy routing, and tunnels. | `ip addr add 192.168.1.44/32 dev enp3s0` | `link`: Manipulate network links. <br> `addr`: Show/manipulate IP addresses. <br> `route`: Show/manipulate routing tables.      |
| `nmcli`      | Command-line tool for controlling NetworkManager.              | `nmcli device show`                      | `device`: Manage devices. <br> `connection`: Manage network connections. <br> `general`: General status and operations.         |
| `nmtui`      | Text user interface for controlling NetworkManager.            | `nmtui-connect`                          | (none)                                                                                                                          |
| `wicked`     | Command-line tool for controlling Wicked (SUSE).               | `wicked show eth0`                       | `ifup/ifdown`: Bring interfaces up/down. <br> `show`: Display interface status. <br> `config`: Manage interface configurations. |
| `networkctl` | Query the status of network links managed by systemd-networkd. | `networkctl list`                        | `status`: Show network status. <br> `restart`: Restart network services. <br> `reload`: Reload network configurations.          |
| `ping`       | Send ICMP ECHO_REQUEST to network hosts.                       | `ping -c 4 192.168.1.1`                  | `-c`: Number of packets to send. <br> `-i`: Interval between packets. <br> `-t`: Set TTL (Time to Live).                        |
| `arp`        | Manipulate or display the system ARP cache.                    | `arp -i eth0 -d 10.0.2.2`                | `-i`: Specify the interface. <br> `-d`: Delete an entry. <br> `-a`: Display current ARP entries.                                |
| `arping`     | Send ARP REQUEST to a neighbor host.                           | `arping -c 4 192.168.1.1`                | `-c`: Number of packets to send. <br> `-I`: Specify the interface. <br> `-f`: Finish after the first reply.                     |

## Service Management Commands

| Command        | Description                                      | Example                                            | Parameters                                                                                                                           |
| -------------- | ------------------------------------------------ | -------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| `systemctl`    | System service manager.                          | `systemctl start sshd.service`                     | `start`: Start a service. <br> `stop`: Stop a service. <br> `status`: Show service status. <br> `enable/disable`: Manage startup.    |
| `firewall-cmd` | Command-line tool for managing firewalld.        | `sudo firewall-cmd --add-service=http --permanent` | `--add-service`: Add a service. <br> `--remove-service`: Remove a service. <br> `--reload`: Reload the firewall configuration.       |
| `ufw`          | Uncomplicated Firewall, a frontend for iptables. | `sudo ufw allow 80/tcp`                            | `allow`: Allow traffic on specified port. <br> `deny`: Deny traffic on specified port. <br> `reload`: Reload firewall configuration. |

## Software Management Commands

| Command   | Description                                                  | Example                           | Parameters                                                                                                                           |
| --------- | ------------------------------------------------------------ | --------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| `dpkg`    | Package management tool for Debian.                          | `sudo dpkg --install package.deb` | `--install`: Install a package. <br> `--remove`: Remove a package. <br> `--list`: List installed packages.                           |
| `apt`     | Command-line package manager for Debian-based distributions. | `sudo apt install apache2`        | `install`: Install a package. <br> `update`: Update package lists. <br> `upgrade`: Upgrade installed packages.                       |
| `yum/dnf` | Package management tools for Red Hat-based distributions.    | `sudo yum install httpd`          | `install`: Install a package. <br> `remove`: Remove a package. <br> `update`: Update installed packages.                             |
| `zypper`  | Package management tool for openSUSE.                        | `sudo zypper install nano`        | `install`: Install a package. <br> `remove`: Remove a package. <br> `refresh`: Refresh repositories. <br> `update`: Update packages. |

## Network Services Commands

| Command  | Description                                                  | Example                                    | Parameters                                                                                           |
| -------- | ------------------------------------------------------------ | ------------------------------------------ | ---------------------------------------------------------------------------------------------------- |
| `ssh`    | Securely access a computer over an unsecured network.        | `ssh -p 22 user@host`                      | `-p`: Specify the port. <br> `-i`: Identity file (private key). <br> `-L`: Local port forwarding.    |
| `dhcp`   | Dynamically set network configuration for connected devices. | Configuration file: `/etc/dhcp/dhcpd.conf` | `dhcpd`: DHCP server daemon. <br> `dhclient`: DHCP client to obtain IP addresses.                    |
| `ntp`    | Allows time synchronization of machines over a network.      | Configuration file: `/etc/ntp.conf`        | `ntpd`: NTP daemon. <br> `ntpq`: Query NTP servers. <br> `ntpstat`: Show NTP synchronization status. |
| `vsftpd` | FTP server for file transfers.                               | Configuration file: `/etc/vsftpd.conf`     | `vsftpd`: FTP server daemon. <br> `ftps`: Secure FTP (if configured).                                |
