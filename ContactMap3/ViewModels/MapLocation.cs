﻿using System;
using System.ComponentModel;
using Xamarin.Forms.Maps;

namespace ContactMap3.ViewModels
{
    public class MapLocation : BaseViewModel
    {
        Position _position;

        public string Address { get; }
        public string Description { get; }

        public Position Position
        {
            get => _position;
            set
            {
                if (!_position.Equals(value))
                {
                    _position = value;
                    OnPropertyChanged();//TODO Verify this
                }
            }
        }

        public MapLocation(string address, string description, Position position)
        {
            Address = address;
            Description = description;
            Position = position;
        }
    }
}

