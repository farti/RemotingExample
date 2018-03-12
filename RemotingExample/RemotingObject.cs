using System;
using System.Text;

namespace RemotingExample
{
    public class RemotingObject: MarshalByRefObject
    {
        public RemotingObject() { }

        public String Test()
        {
            return ".NET Remoting test";
        }
    }
}
