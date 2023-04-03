﻿using ApiTestProject.Data;
namespace ApiTestProject.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string title { get; set; }

        public string description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category CategoryId { get; set; }

    }


}