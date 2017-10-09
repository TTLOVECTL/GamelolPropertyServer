using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceNetFrame.ace;
using AceNetFrame.ace.auto;
using System.Threading;

namespace GamelolPropetryServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NetServer server = new NetServer(100);
                server.lengthEncode = LengthEncoding.encode;
                server.lengthDecode = LengthEncoding.decode;
                server.serDecode = MessageEncoding.Decode;
                server.serEncode = MessageEncoding.Encode;
                server.center = new HandlerCenter();
                server.init();
                server.Start(2002);
            }
            catch (Exception e)
            {
                Console.WriteLine("Server Error " + e.TargetSite);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.Message);
            }
            while (true)
            {
                Thread.Sleep(360000);
            }
        }
    }
}
