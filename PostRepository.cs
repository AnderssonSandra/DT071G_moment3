using System;
using System.Collections.Generic;

namespace moment3_guestbook
{
    class PostRepository
    {
        public void AddPost(Post post)
        {
            //create instance of class DataSerialzer
            var serialize = new DataSerializer();

            //get json-file as a list
            var postList = serialize.JsonDeserialize(); 

            //add object to list
            postList.Add(post);

            //serialise postList again to json format
            serialize.JsonSerialize(postList); 
        }

        public bool DeletePost(int index) //bool- istället om false felmeddelande, true är ok 
        {
            //create instance of class DataSerialzer
            var serialize = new DataSerializer();


            try //try if input is correct
            {
                //deserialze json and get a list of all post objects
                var postList = serialize.JsonDeserialize();

                //delete object where index = index
                postList.RemoveAt(index);

                //serialize to json again
                serialize.JsonSerialize(postList);
                Console.Clear();

                return true;
            }
            // if input does not exist in the list
            catch (ArgumentOutOfRangeException) 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;  // Change color to yellow
                Console.WriteLine("Ops! Du måste ha angett ett index som inte finns, du får försöka igen. \n");
                Console.ForegroundColor = ConsoleColor.Gray;  // Change color to gray again

                return false;
            }
        }

        public List<Post> getPosts()
        {
            //create instance of class DataSerialzer
            var serialize = new DataSerializer();

            //deserialze json and get a list of all post objects
            var postList = serialize.JsonDeserialize();

            return postList;
        }

    }
}
