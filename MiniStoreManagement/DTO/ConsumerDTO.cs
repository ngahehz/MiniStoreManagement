﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    public class ConsumerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DoB { get; set; }
        public int Cell { get; set; }
        public ConsumerDTO()
        {

        }
        public ConsumerDTO(int id, string name, string gender, DateTime doB, int cell)
        {
            Id = id;
            Name = name;
            Gender = gender;
            DoB = doB;
            Cell = cell;
        }
    }
}
