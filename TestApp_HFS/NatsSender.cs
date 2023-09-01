using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATS;
using NATS.Client;

namespace TestApp_HFS
{
    class NatsSender
    {
        private IEncodedConnection connection = new ConnectionFactory().CreateEncodedConnection();
       
        public void Send(byte[] massive)
        {
            connection.Publish("listeners",massive);
        }
    }
}
