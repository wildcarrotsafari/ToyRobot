using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Support;

namespace ToyRobotSimultator.Tests
{
    public class RobotTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void JunkCommand()
        {
            ToyRobot robot = new ToyRobot();
            List<string> commands = new List<string>()
            {
                "EXTERMINATE"                
            };

            var response = robot.IssueCommands(commands);
            Assert.IsTrue(string.IsNullOrEmpty(response));           
        }

        [Test]
        public void JunkAndValidCommand()
        {
            ToyRobot robot = new ToyRobot();
            List<string> commands = new List<string>()
            {
                "TRANSFORM",
                "PLACE 0,0,NORTH",
                "REPORT"

            };

            var response = robot.IssueCommands(commands);
            Assert.AreEqual("Output: 0,0,NORTH", response);
        }


        [Test] 
        public void NorthMovement()
        {
            ToyRobot robot = new ToyRobot();
            List<string> commands = new List<string>()
            {
                "PLACE 0,0,NORTH",
                "MOVE",
                "REPORT"               
            };

            var response = robot.IssueCommands(commands);

            Assert.AreEqual("Output: 0,1,NORTH", response);
        }

        [Test]
        public void OffTable()
        {
            ToyRobot robot = new ToyRobot();
            List<string> commands = new List<string>()
            {
                "PLACE 6,6,NORTH",              
                "REPORT"
            };

            var response = robot.IssueCommands(commands);

            Assert.IsTrue(string.IsNullOrEmpty(response));
        }


        [Test]
        public void OffTableBottom()
        {
            ToyRobot robot = new ToyRobot();
            List<string> commands = new List<string>()
            {
                "PLACE -1,-1,NORTH",
                "REPORT"
            };

            var response = robot.IssueCommands(commands);

            Assert.IsTrue(string.IsNullOrEmpty(response));
        }


        [Test]
        public void LeftMovement()
        {
            ToyRobot robot = new ToyRobot();
            List<string> commands = new List<string>()
            {
                "PLACE 0,0,NORTH",
                "LEFT",
                "REPORT"
            };

            var response = robot.IssueCommands(commands);

            Assert.AreEqual("Output: 0,0,WEST", response);
        }

        [Test]
        public void MoveAndPlaceTwice()
        {
            ToyRobot robot = new ToyRobot();
            List<string> commands = new List<string>()
            {
                "PLACE 1,2,EAST",
                "MOVE",
                "LEFT",
                "MOVE",
                "PLACE 3, 1",
                "MOVE",
                "REPORT"
            };

            var response = robot.IssueCommands(commands);

            Assert.AreEqual("Output: 3,2,NORTH", response);
        }

        [Test]
        public void MoveAndPlaceOnce()
        {
            ToyRobot robot = new ToyRobot();
            List<string> commands = new List<string>()
            {
                "PLACE 1,2,EAST",
                "MOVE",
                "MOVE",
                "LEFT",
                "MOVE",
                "REPORT"
            };

            var response = robot.IssueCommands(commands);

            Assert.AreEqual("Output: 3,3,NORTH", response);
        }


        [Test]
        public void ValidPlace()
        {
            ToyRobot robot = new ToyRobot();
            List<string> commands = new List<string>()
            {
                "PLACE 1,2,EAST",
                "MOVE",
                "LEFT",
                "MOVE",
                "PLACE 3, 1",
                "MOVE",
                "REPORT"
            };

            var response = robot.IssueCommands(commands);

            Assert.AreEqual("Output: 3,2,NORTH", response);
        }   
    }
}
