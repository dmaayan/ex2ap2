﻿using MazeLib;
using System.Net.Sockets;
using SearchAlgorithmsLib;
using Ex1;

namespace MVC
{
    public class RunDFSCommand : Command
    {

        public RunDFSCommand(IModel model) : base(model) { }

        public override string Execute(string[] args, TcpClient client)
        {
            MazeSolution ms = Model.SolveMaze(args[0], new DFS<Position>().search);
            if (ms == null)
            {
                return "No solution possible";
            }
            return ms.ToJson();
        }
    }
}