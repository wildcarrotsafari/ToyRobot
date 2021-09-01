using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Support
{
    /// <summary>
    /// Toy Robot simulator
    /// I started writing Command Pattern Version - but the instructions were not to overcomplicate it.
    /// </summary>
    public class ToyRobot
    {
        /// <summary>
        /// The Table Top it is on
        /// </summary>
        protected TableTop Table { get; set; }

        public ToyRobot()
        {
            this.Table = new TableTop(6, 6);           
        }

        /// <summary>
        /// Toy Robot Constructor
        /// </summary>
        /// <param name="board"></param>
        public ToyRobot(TableTop board)
        {
            if (board is null)
            {
                this.Table = new TableTop(6, 6);
            }
            else
            {
                this.Table = board;
            }
        }

        /// <summary>
        /// Issue a sequence of command
        /// Dicard (don't process invalid commands)
        /// </summary>
        /// <param name="commands"></param>
        /// <returns>will return last output</returns>
        public string IssueCommands(List<string> commands)
        {
            string lastOutput = null;
            if (commands == null) return lastOutput;
            foreach(var command in commands)
            {
                try
                {
                    lastOutput = ProcessCommand(command);
                }
                catch (Exception ex)
                {
                    // Normally I would log here...but for now this is just to handle any really invalid data.
                    // We could do Console.WriteLine(ex.message)
                    return lastOutput;
                }
               
            }

            return lastOutput;
        }
        /// <summary>
        /// Parse a Place Command
        /// </summary>
        /// <param name="text"></param>
        public void ProcessPlaceCommand(string text)
        {
            string[] arguments = text.Substring(text.IndexOf(" ")).Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int x;
            int y;

            if (this.Table.OnTheTable && arguments.Length == 2)
            {               
                int.TryParse(arguments[0], out x);
                int.TryParse(arguments[1], out y);
                this.Table.Place(x, y);
                
            }
            else if (arguments.Length == 3)
            {
                TableTop.Direction direction;
                if (int.TryParse(arguments[0], out x) && int.TryParse(arguments[1], out y)
                    && Enum.TryParse(arguments[2], out direction))
                    {
                    this.Table.Place(x, y, direction);
                }   
            }
        }


        /// <summary>
        /// Issues a command
        /// Invalid commands are ignored
        /// </summary>
        /// <param name="text"></param>
        /// <returns>response if applicable</returns>
        public string ProcessCommand(string text)
        {
            string response = null;
            if (!string.IsNullOrWhiteSpace(text))
            {
                text = text.ToUpper();
                if (text.StartsWith("PLACE "))
                {
                    ProcessPlaceCommand(text);
                }
                else if (this.Table.OnTheTable)
                {
                    switch (text)
                    {
                        case "MOVE" :
                            this.Table.Move();
                            break;
                        case "LEFT":
                            this.Table.RotateLeft();
                            break;
                        case "RIGHT":
                            this.Table.RotateRight();
                            break;
                        case "REPORT":
                            response = this.Table.Report();
                            Console.WriteLine(response);
                            return response;                            
                    }
                }
            }

            return response;
        }

        public void Move()
        {
            this.Table.Move();
        }

        public void Left()
        {
            this.Table.RotateLeft();
        }

        public void Right()
        {
            this.Table.RotateRight();
        }

        public void Place(int x, int y)
        {
            this.Table.Place(x, y);
        }

        public void Place(int x, int y, TableTop.Direction direction)
        {
            this.Table.Place(x, y, direction);
        }        

        public string Report()
        {
                       
            var output = this.Table.Report();
            Console.WriteLine(output);
            return output;
            
        }

    }
}
