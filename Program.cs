using System;

namespace moment3_guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            //clear console
            Console.Clear();

            //create instance of classes
            PostRepository postRepository = new PostRepository();
            bool showMenu = true;

            while (showMenu)
            {
                // Display title
                Console.ForegroundColor = ConsoleColor.DarkBlue;  // Change color to blue
                Console.WriteLine("SANDRAS GUESTBOOK\r");
                Console.WriteLine("------------------------\n");
                Console.ForegroundColor = ConsoleColor.Gray;  // Change color to gray again

                // Ask user to choose an option
                Console.ForegroundColor = ConsoleColor.Blue;  // Change color to blue
                Console.WriteLine("Välj ett av följande altetnativ, skriv in siffraN alternativet du valt och klicka ENTER:");
                Console.ForegroundColor = ConsoleColor.Gray;  // Change color to gray again
                Console.WriteLine("1: Lägg till ett blogginlägg");
                Console.WriteLine("2: Radera ett blogginlägg");
                Console.WriteLine("X: Stäng ner konsollapplikationen\n");


                Console.ForegroundColor = ConsoleColor.Blue;  // Change color to blue
                Console.WriteLine("Här kan du se gästboksinläggen:\n");
                Console.ForegroundColor = ConsoleColor.Gray;  // Change color to gray again

                int i = 0;
                foreach (Post post in postRepository.getPosts())
                {
                    Console.WriteLine($"[{i}] {post.Author} - {post.PostContent}\n");
                    i++;
                }

                Console.ForegroundColor = ConsoleColor.Blue;  // Change color to Blue
                //Ask user to choose an option
                Console.Write("\nVilket alternativ har du valt? \n");
                Console.ForegroundColor = ConsoleColor.Gray;  // Change color to gray again


                //switch, choose case based on input
                string option = Console.ReadLine().ToLower();
                switch (option)
                {
                    case "1":

                        string author = "";
                        string postContent = "";

                        //clear console
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;  // Change color to yellow
                        Console.WriteLine("Skriv gästboksinlägg:\n");
                        Console.ForegroundColor = ConsoleColor.Gray;  // Change color to gray again
                        //ask user for name and postContent
                        Console.Write("Skriv ditt namn: ");
                        author = Console.ReadLine();            // read input
                        Console.Write("Skriv ditt gästboksinlägg: ");
                        postContent = Console.ReadLine();          // read input

                        //do while author or postContent is empty
                        while (string.IsNullOrEmpty(postContent) || string.IsNullOrEmpty(author))
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;  // Change color to red
                            Console.WriteLine(" Obs! Du glömde skriva in namn eller gästboksinlägg. Försök igen\n");
                            Console.ForegroundColor = ConsoleColor.Gray;  // Change color to gray again
                            Console.Write("Skriv in ditt namn: ");
                            author = Console.ReadLine();              // read input
                            Console.Write("Skriv ditt inlägg: ");
                            postContent = Console.ReadLine();              // read input
                        }

                        //add object 
                        Post post = new Post();
                        post.Author = author;
                        post.PostContent = postContent;

                        //send object to function AddPost
                        postRepository.AddPost(post);

                        //clear console
                        Console.Clear();
                        break;

                    case "2":
                        //clear console
                        Console.Clear();
                        //ask user for index on post to delete
                        Console.ForegroundColor = ConsoleColor.Yellow;  // Change color to yellow
                        Console.Write("Ange index på det inlägg du vill radera: ");
                        Console.ForegroundColor = ConsoleColor.Gray;  // Change color to gray again


                        string indexInput = Console.ReadLine();
                        int index;

                        //check if input is a number
                        bool isNumber = int.TryParse(indexInput, out index);


                        //if index isn´t a number
                        if (isNumber == false)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;  // Change color to red
                            Console.WriteLine("Ops! Nu skrev du inte en siffra, du får börja om\n");
                            Console.ForegroundColor = ConsoleColor.Gray;  // Change color to gray again
                        }
                        else
                        {
                            //send index to function "DeletePost"
                            postRepository.DeletePost(Convert.ToInt32(index));
                        }
                        break;

                    case "x":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;  // Change color to green
                        Console.WriteLine("Tack för idag, hoppas vi ses snart igen \n");
                        Console.ForegroundColor = ConsoleColor.Gray;  // Change color to gray again
                        //close console
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;  // Change color to red
                        Console.WriteLine(" Ojdå. Nu valde du inget av alternativen. Testa igen. \n");
                        Console.ForegroundColor = ConsoleColor.Gray;  // Change color to gray again
                        break;

                }
            }

        }

    }

}
