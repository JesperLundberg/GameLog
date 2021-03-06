﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GameLog.Web.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime GameAddedDate { get; set; }
    }
}