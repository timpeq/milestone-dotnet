using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

// Be aware that with this command no authentication is possible.
// Please consider alternative ways of communicating, like triggering User-Defined event with camera id's as parameters.
// Also on the XProtect Advanced product family you have to enable the functionality in the Options dialog of the Management Client before using it.

int iport = 1776; // Milestone default is 1234
string hostname = "SGSVPMILE01.MLC.com";
string toSend = "myevent";
ProtocolType ptype = ProtocolType.Tcp;
SocketType stype = SocketType.Stream;
AddressFamily afam = AddressFamily.InterNetwork; // IPv4

Socket sock;
IPAddress ipaddr;
IPEndPoint ipe;

try
{
    sock = new Socket(afam, stype, ptype);
    ipaddr = IPAddress.Parse(hostname);
    ipe = new IPEndPoint(ipaddr, iport);
}

catch (Exception e)
{
    Console.WriteLine(e.Message);
    return;
}
    
try
{
    sock.Connect(ipe);
}

catch(Exception e)
{
    Console.WriteLine(e.Message);
    return;
}
    
int n = 0;
Byte[] bytesSent = Encoding.ASCII.GetBytes(toSend);

try
{
    n = sock.Send(bytesSent, bytesSent.Length, 0);
}

catch(Exception e)
{
    Console.WriteLine(e.Message);
    sock.Close();
    return;
}

if (n == bytesSent.Length)
{
    Console.WriteLine("String sent to specified server & port.");
}

else
{
    Console.WriteLine("Send error.");
}

sock.Close();
