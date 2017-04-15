﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Command;

namespace Server
{
    public class ClientHandler : IClientHandler
    {
        Controller controller;

        public ClientHandler(Controller c)
        {
            controller = c;
        }

        public void HandleClient(TcpClient client)
        {
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string commandLine = "";
                    //** לשנות את התנאי
                    while (!commandLine.Contains("close"))
                    {
                        try
                        {
                            commandLine = reader.ReadLine();
                            Console.WriteLine("Got command: {0}", commandLine);
                            string result = controller.ExecuteCommand(commandLine, client);
                            writer.Write(result);
                        }
                        //**לשנות את האקספשין 
                        catch (SocketException)
                        {
                            break;
                        }
                    }
                }
                client.Close();
            }).Start();
        }
    }
}
