using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Support
{
    /// <summary>
    /// A Table top. including location and position information
    /// </summary>
    public class TableTop
    {
        public enum Direction
        {
            NORTH,
            EAST,
            SOUTH,
            WEST
        }

        private bool _onTheTable = false;
        private int _x;
        private int _y;
        private int _height;
        private int _width;
        private Direction _direction;

        public bool OnTheTable
        {
            get { return _onTheTable; }
        }


        public TableTop(int height, int width)
        {
            _height = height; _width = width;
        }

        /// <summary>
        /// Move forward
        /// </summary>
        /// <returns></returns>
        public bool Move()
        {
            if (!OnTheTable) return false;
            switch (_direction)
            {
                case Direction.SOUTH:
                    if (_y > 0)
                    {
                        _y--;
                        return true;
                    }
                    break;
                case Direction.WEST:
                    if (_x > 0)
                    {
                        _x--;
                        return true;
                    }
                    break;
                case Direction.NORTH:
                    if (_y < _height - 1)
                    {
                        _y++;
                        return true;
                    }
                    break;
                case Direction.EAST:
                    if (_x < _width - 1)
                    {
                        _x++;
                        return true;
                    }

                    break;
                default:
                    return false;
            }
            return false;
        }

        /// <summary>
        /// Rotate Left
        /// </summary>
        /// <returns></returns>
        public bool RotateLeft()
        {
            if (!OnTheTable) return false;
            _direction = (_direction > Direction.NORTH) ? _direction = _direction - 1 : Direction.WEST;
            return true;
        }

        //Rotate Right
        public bool RotateRight()
        {
            if (!OnTheTable) return false;
            _direction = (_direction < Direction.WEST) ? _direction = _direction + 1 : Direction.NORTH;
            return true;
        }

        /// <summary>
        /// Are the coords on the board
        /// </summary>
        /// <param name="x">x/param>
        /// <param name="y">y/param>
        /// <returns></returns>
        private bool isValidCoords(int x, int y)
        {
            return (x >= 0 && x < _width - 1 && y >= 0 && y < _height - 1);
        }

        /// <summary>
        /// Change Place to coordinates including Direction
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool Place(int x, int y, Direction direction)
        {
            if (!isValidCoords(x, y)) return false;
            _x = x;
            _y = y;
            _onTheTable = true;
            _direction = direction;
            return true;
        }

        /// <summary>
        /// Change Place to coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>       
        /// <returns></returns>
        public bool Place(int x, int y)
        {
            if (!isValidCoords(x, y) || !_onTheTable) return false;
            _x = x;
            _y = y;
            return true;
        }

       
        public string Report()
        {
            if (!OnTheTable) return null;
            try
            {
                return $"Output: {_x},{_y},{_direction}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
