using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace moment3_guestbook
{
    class DataSerializer
    {
        string filePath = @"data.json"; // sökväg till json-fil

        //serilize
        public void JsonSerialize(List<Post> postList)
        {
            //check if json file eist and create if it dosen´t exist
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
            }

            //serialise data
            string jsonData = JsonConvert.SerializeObject(postList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }

        //deserilize
        public List<Post> JsonDeserialize()
        {
            //check if json file eist and create if it dosen´t exist
            if (!File.Exists(filePath))
            {
                return new List<Post>();
            }
            else
            {
                //read json file
                var jsonData = System.IO.File.ReadAllText(filePath);

                // Deserialise json file to C# object and create list
                var postList = JsonConvert.DeserializeObject<List<Post>>(jsonData)
                ?? new List<Post>();

                //return list
                return postList;

            }

        }
    }
}
