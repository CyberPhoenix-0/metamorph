using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ConsoleApplication2
{

    internal class Nmap
        {
            public static string _ip;
            public static int _port;

            public static Dictionary<int, string> protocol = new Dictionary<int, string>()
            {
                {20, "ftp - Data Transfer"}, {21, "ftp - Command Control"}, {22, "ssh"}, {23, "telnet"}, 
                {25, "simple-mail-transfer-smtp - e-mail routing"}, {53, "Dns-service"}, {67, "dhcp-bootp-server"}, 
                {68, "dhcp-bootp-client"}, {80, "http"}, {110, "pop3"}, {119, "nntp"}, {123, "ntp"}, {135, "ms-rpc95"}, 
                {137, "netbios-name-service"}, {138, "netbios-datagram-service"}, {139, "netbios-session-service"}, 
                {143, "imap"}, {161, "snmp"}, {194, "irc"}, {443, "https - http over tls/ssl"}, {445, "microsoft-ds smb file sharing"}, 
                {500, "isakmp / ike"}, {530, "rpc"}, {587, "smtp - soumission"}, {853, "dns-over-tls"}, {873, "rsync-file-synchronisation-protocol"}, 
                {989, "ftps-data - ftp over tls/ssl"}, {990, "ftps-control - ftp over tls/ssl"}, {1080, "socks"}, {1194, "openvpn"},
                {1293, "ipsec"}, {1521, "listener-oracle-database"}, {3128, "ndl-aas"}, {5900, "vnc"}, {5938, "teamviewer"}, {8080, "web-alternatif"}, 
                {6665, "irc"}, {6666, "irc"}, {6667, "irc"}, {6668, "irc"}, {66689, "irc"}, {65534, "trojans"}


            };
            public Nmap(int port, string ip)
            {
                _port = port;
                _ip = ip;
            }

            public static void Scan1()
            {
                try
                {
                    TcpClient Scan = new TcpClient();
                    Scan.Connect(Nmap._ip, _port);
                    Console.WriteLine("At : " + Nmap._ip + " : "+ Nmap._port + " :  OUVERT");
                }
                catch
                {
                    Console.WriteLine("At : " + Nmap._ip + " : "+ Nmap._port + " : FERMEE");
                }
            }

            public static void ScanAll()
            {
                foreach (KeyValuePair<int, string>p in protocol)
                {
                    try
                    {
                        TcpClient Scan = new TcpClient();
                        Scan.Connect(_ip, p.Key);
                        Console.WriteLine("At : " + _ip + " : " + p + " : OUVERT");
                        Scan.Close();
                    }
                    catch
                    {
                        //Console.WriteLine("At : " + _ip + " : "+ p + " : FERMEE");
                    }
                }
            }
        
        }

}