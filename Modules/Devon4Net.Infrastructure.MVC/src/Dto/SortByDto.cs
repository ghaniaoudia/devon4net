﻿using Newtonsoft.Json;

namespace Devon4Net.Infrastructure.MVC.Dto
{
    public class SortByDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///  ASC for ascending and DESC for descending
        /// </summary>
        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; } 
        
    }
}