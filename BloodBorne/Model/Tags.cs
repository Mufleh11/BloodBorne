﻿using Microsoft.EntityFrameworkCore;

namespace BloodBorne.Model
{
    public class Tags
    {
        public int Id { get; set; }
        public string tagName { get; set; }
        public List <Comment> Comment { get; set; }
    }
}
