using System.Text;
using System.Net;
using System.Net.Sockets;

int iport = 1776; // Milestone default is 1234
string hostname = "10.20.50.140";
string toSend = "pcrv1";
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

