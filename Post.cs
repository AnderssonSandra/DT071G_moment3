using System;

namespace moment3_guestbook
{
    [Serializable] //allow to serialize
    class Post
    {
        public string Author { get; set; }
        public string PostContent { get; set; }
    }
}
