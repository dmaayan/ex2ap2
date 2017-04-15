﻿using MazeLib;
using System.Net.Sockets;

namespace Command
{
    internal class PlayCommand : Command
    {

        public PlayCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            Maze maze = Model.GenerateMaze(name, rows, cols);
            return maze.ToJSON();
        }
    }
}