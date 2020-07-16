using System;
using AkrProtoTools;

namespace AkrProtoTools
{
    public class VersionInfo
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("APPLICATION VERSION: " + AkrLibCommon.LIB_VERSION);
            if(args.Length > 0)
            {

            }
        }
    }
}
