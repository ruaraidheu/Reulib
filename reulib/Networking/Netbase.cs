using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using static Ruaraidheulib.List;
using static Ruaraidheulib.Interface.Obsolete.List;

namespace Ruaraidheulib.Networking
{
    public class NoNetSpaceExeption : Exception
    {
        public NoNetSpaceExeption() : base("There is no NetSpace with that ID.")
        {
        }
    }
    public class OutOfNetSpaceExeption : Exception
    {
        public OutOfNetSpaceExeption() : base("You are trying to modify netspace that hasn't been allocated to that ID.")
        {
        }
    }
    public class NetSpaceAllocationClosedException : Exception
    {
        public NetSpaceAllocationClosedException() : base("NetSpace allocation period has closed. Use GetNetSpace before ending the AllocPeriod")
        {
        }
    }
    public class NetHost
    {//. Not assigned
        NetSync ns = new NetSync();
        List<object> netdata;
#pragma warning disable CS0612 // Type or member is obsolete
        List<Interface.Obsolete.List.Threeint> netspaces;
        List<Thread> threads;

        NetType nt;
        AllocPeriod ap;
        bool run;
        int threadc;
        public NetHost(NetType nettype, int connections)
        {
            nt = nettype;
            ap = AllocPeriod.Open;
            run = false;
            threadc = connections;
            netdata = new List<object>();
            netspaces = new List<Interface.Obsolete.List.Threeint>();
            threads = new List<Thread>();
        }
        #region API
        public enum NetType
        {
            Host, Client, Level
        }
        public enum AllocPeriod
        {
            Open, Protected, Closed
        }



        public void CloseAllocPeriod()
        {
            ap = AllocPeriod.Closed;
        }
        public bool ReopenAllocPeriod()
        {
            if (!run)
            {
                ap = AllocPeriod.Open;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool StartNet()
        {
            if (ap != AllocPeriod.Open)
            {
                run = true;
                Loop.For(() =>
                {

                }, threadc);

                return true;
            }
            else
            {
                return false;
            }
        }
        public void StopNet()
        {
            foreach (Thread t in threads)
            {
                t.Abort();
            }
            run = false;
        }
        #endregion
        #region NetSpace
        /// <summary>
        /// Returns ID of your space
        /// </summary>
        /// <param name="noobjects">Number of objects to syncronise</param>
        /// <returns></returns>
        public int GetNetSpace(int noobjects)
        {
            if (ap == AllocPeriod.Open)
            {
                Interface.Obsolete.List.Threeint sd = new Interface.Obsolete.List.Threeint();
                sd.X = netspaces.Count;
                sd.Y = netdata.Count;
                Loop.For(() =>
                {
                    netdata.Add(new NetNull());
                }, noobjects);
                sd.Z = netdata.Count;
                netspaces.Add(sd);
                return sd.X;
            }
            else
            {
                throw new NetSpaceAllocationClosedException();
            }
        }
        public object[] EditNetSpace(int ID)
        {
            if (ID >= netspaces.Count)
            {
                throw new NoNetSpaceExeption();
            }
            else
            {
                Interface.Obsolete.List.Threeint ti = netspaces[ID];
                object[] o = new object[ti.Z - ti.Y];
                Loop.For((i) =>
                {
                    o[i] = netdata[ti.Y+i];
                }, o.Length);
                return o;
            }
        }
        public void EditNetSpace(int ID, object[] o)
        {
            if (ID >= netspaces.Count)
            {
                throw new NoNetSpaceExeption();
            }
            else
            {
                Interface.Obsolete.List.Threeint ti = netspaces[ID];
                if ((ti.Z - ti.Y) > o.Length)
                {
                    Loop.For((i) =>
                    {
                        netdata[ti.Y + i] = o[i];
                    }, o.Length);
                }
                else
                {
                    throw new OutOfNetSpaceExeption();
                }
            }
        }
        #endregion
        #region IO
        public void Send()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 25566);
            UdpClient cli = new UdpClient(ipep);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            byte[] data;
            data = cli.Receive(ref sender);

            object se = Netbase.FromBytes(data);
            if (se is NetSync)
            {
                NetSync sen = (NetSync)se;
                if (sen.ID() == Netbase.getID())
                {
                    while (run)
                    {
                        data = Netbase.ToBytes(ns);
                        cli.Send(data, data.Length, sender);
                        for (int i = 0; i < netdata.Count; i++)
                        {
                            data = Netbase.ToBytes(netdata[i]);
                            cli.Send(data, data.Length, sender);
                        }
                        Thread.Sleep(16);
                    }
                }
            }
        }

        public void Recieve()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 25565);
            UdpClient newsock = new UdpClient(ipep);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            byte[] data;
            data = newsock.Receive(ref sender);
            
            newsock.Send(data, data.Length, sender);

            while (run)
            {
                data = newsock.Receive(ref sender);
                Netbase.FromBytes(data);
            }
        }
        #endregion
    }
    public class Netbase
    {
#region ID
        static string ID = "reulib:V1.0.0.1";
        public static string getID()
        {
            //TODO: Fix
            return ID;
        }
        public static void setID(string uuid)
        {
            ID = uuid;
        }
#endregion
        public Netbase()
        {

        }
        public static byte[] ToBytes(object o)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream s = new MemoryStream();
            bf.Serialize(s, o);
            return s.ToArray();
        }
        public static object FromBytes(byte[] data)
        {
            MemoryStream s = new MemoryStream();
            s.Read(data, 0, data.Length);
            BinaryFormatter bf = new BinaryFormatter();
            return bf.Deserialize(s);
        }




        //public void Recieve()
        //{
        //    try
        //    {
        //        UdpClient cli = new UdpClient();
        //        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ipadd), 25566);
        //        cli.Connect(ipep);
        //        cli.Send(Encoding.ASCII.GetBytes("I am a client"), Encoding.ASCII.GetByteCount("I am a client"));
        //        byte[] data;
        //        while (true)
        //        {
        //            data = cli.Receive(ref ipep);
        //            string[] ip = Encoding.ASCII.GetString(data, 0, data.Length).Split();
        //            if (ip.Length == 4)
        //            {
        //                if (sync)
        //                {
        //                    p1 = new System.Drawing.Point(Convert.ToInt32(ip[0]), Convert.ToInt32(ip[1]));
        //                    sync = false;
        //                }
        //                p2 = new System.Drawing.Point(Convert.ToInt32(ip[2]), Convert.ToInt32(ip[3]));
        //            }
        //        }
        //    }
        //    catch (System.Net.Sockets.SocketException)
        //    {

        //    }
        //}
        //public void Send()
        //{
        //    try
        //    {
        //        UdpClient cli = new UdpClient();
        //        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ipadd), 25565);
        //        cli.Connect(ipep);
        //        cli.Send(Encoding.ASCII.GetBytes("I am a client"), Encoding.ASCII.GetByteCount("I am a client"));
        //        byte[] data;
        //        data = cli.Receive(ref ipep);
        //        Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
        //        while (true)
        //        {
        //            cli.Send(Encoding.ASCII.GetBytes(p1.X.ToString() + " " + p1.Y.ToString()), Encoding.ASCII.GetByteCount(p1.X.ToString() + " " + p1.Y.ToString()));
        //            Thread.Sleep(new TimeSpan(0, 0, 0, 0, 16));
        //        }
        //    }
        //    catch (System.Net.Sockets.SocketException)
        //    {

        //    }
        //}
    }

    [Serializable]
    public class NetSync
    {
        public virtual string ID()
        {
            return Netbase.getID();
        }
    }
    [Serializable]
    public class NetNull
    {
    }
}
