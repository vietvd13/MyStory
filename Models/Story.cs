using System;
using System.Collections.Generic;

#nullable disable

namespace MyStory.Models
{
    public partial class Story
    {
        public int StoryId { get; set; }
        public string TheDescription { get; set; }
        public byte[] Picture { get; set; }
    }
}
