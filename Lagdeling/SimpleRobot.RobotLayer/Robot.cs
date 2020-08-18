using System;
using System.Collections.Generic;
using System.Text;

namespace Lagdeling
{
    public class Robot
    {
        private SimpleRobot _simbleRobot;

        public Robot()
        {
            _simbleRobot = new SimpleRobot();
        }

        public  void TurnRight()
        {
            _simbleRobot.TurnLeft();
            _simbleRobot.TurnLeft();
            _simbleRobot.TurnLeft();
        }

        public void TurnLeft()
        {
            _simbleRobot.TurnLeft();
        }

        public void TurnAround()
        {
            _simbleRobot.TurnLeft();
            _simbleRobot.TurnLeft();
        }

        public void Drive(int distanceUnits)
        {
            for (int i = 0; i < distanceUnits; i++)
            {
                _simbleRobot.Drive();
            }
        }
    }
}
