using System;

namespace Lagdeling
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            robot.TurnRight();
            robot.Drive(5);
            robot.TurnAround();
        }
    }
}
