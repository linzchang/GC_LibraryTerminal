using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal

    //NEED TO FIX:  Search, Sort by Author  Need to build return function
{
    //Console program that allows a user to search a library catalog and reserve books


    //Return a book

    class Program
    {
        public const int TITLE = 0;
        public const int AUTHOR = 1;
        public const int STATUS = 2;
        public const string CHECKED_IN = "CHECKED_IN";
        public const string CHECKED_OUT= "CHECKED_OUT";

        static void Main(string[] args)
        {
            List<string> book1 = new List<string> { "Harry Potter and the Sorcerer's Stone", "J.K. Rowling", CHECKED_IN,};
            List<string> book2 = new List<string> { "The Hobbit", "J.R.R. Tolkein", CHECKED_IN,};
            List<string> book3 = new List<string> { "The Girl with the Dragon Tattoo", "Stieg Larsson", CHECKED_OUT,};
            List<string> book4 = new List<string> { "The Velveteen Rabbit", "Margery Williams", CHECKED_IN,};
            List<string> book5 = new List<string> { "Howl's Moving Castle", "Diana Wynne Jones", CHECKED_OUT,};
            List<string> book6 = new List<string> { "The Hunger Games", "Suzanne Collins", CHECKED_IN,};
            List<string> book7 = new List<string> { "Pride and Prejudice", "Jane Austen", CHECKED_IN,};
            List<string> book8 = new List<string> { "A Good Earth", "Pearl S. Buck", CHECKED_IN,};
            List<string> book9 = new List<string> { "Harry Potter and the Goblet of Fire", "J.K. Rowling", CHECKED_OUT,};
            List<string> book10 = new List<string> { "The Lion, The Witch, and The Wardrobe", "C. S. Lewis", CHECKED_IN,};
            List<string> book11 = new List<string> { "The Fellowship of the Ring", "J.R.R. Tolkein", CHECKED_OUT,};
            List<string> book12 = new List<string> { "A Feast for Crows", "George R.R. Martin", CHECKED_IN,};

            Dictionary<string, List<string>> myLibrary = new Dictionary<string, List<string>> ();
            myLibrary.Add("Rowling1", book1);
            myLibrary.Add("Tolkein1", book2);
            myLibrary.Add("Larsson1", book3);
            myLibrary.Add("Williams1", book4);
            myLibrary.Add("Jones1", book5);
            myLibrary.Add("Collins1", book6);
            myLibrary.Add("Austen1", book7);
            myLibrary.Add("Buck1", book8);
            myLibrary.Add("Rowling2", book9);
            myLibrary.Add("Lewis1", book10);
            myLibrary.Add("Tolkein2", book11);
            myLibrary.Add("Martin1", book12);

            Console.WriteLine("Welcome to Lin-z's Library!");
            MainMenu(myLibrary);
        }

        public static void MainMenu(Dictionary<string, List<string>> myLibrary)
        {
            while (true)
            {
                string switchAnswer = GetInput("Would you like to 1) check out or 2) return a book?");

                switch (switchAnswer)
                {
                    //Check out
                    case "1":
                        //User can decide if they want to see a list of books or search by keyword to find a book to check out
                        string checkOutAnswer = GetInput("Would you like to 1) see a list of books, or 2) search by keyword?");
                        CheckOut(checkOutAnswer, myLibrary);
                        break;
                    //Return
                    case "2":
                        ReturnBook(myLibrary);
                        break;
                    default:
                        Console.WriteLine("That is not a valid selection, try again.");
                        continue;
                }

                string endProgram = GetInput("Would you like to continue to the main menu?  Press Y to continue");
                if (endProgram.ToUpper() != "Y")
                {
                    break;
                }
                Console.Clear();
            }
        }

        public static string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static void DisplayLibrary(Dictionary<string, List<string>> myLibrary)
        {
            Console.WriteLine("{0, -39:0} {1, -39:0}", "Title", "Author");
            Console.WriteLine("{0, -39:0} {0, -39:0}", "========");

            //iterating over whole dictionary Library
            foreach (KeyValuePair<string, List<string>> entry in myLibrary)
            {
                //iterating over Lists and printing variables in Lists
                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine("{0, -39:0} {1, -39:0} ", entry.Value[0], entry.Value[1]);
                }
                //Console.Write(" ");
            }
            Console.WriteLine(" ");

        }

        public static void CheckOut(string checkOutAnswer, Dictionary<string, List<string>> myLibrary)
        {
            while (checkOutAnswer != "1" || checkOutAnswer != "2")
            {
                //User selected display list
                if (checkOutAnswer == "1")
                {
                    //Displays library
                    DisplayLibrary(myLibrary);
                    //Asks user if/how they'd like to sort the library
                    AlphabetizeList(ref myLibrary);
                    //Prompts user to check out book
                    CheckOutBook(myLibrary);
                    break;
                }
                //User selected search by keyword 
                else if (checkOutAnswer == "2")
                {
                    string searchAnswer = GetInput("Would you like to search by 1) Title or 2) Author?");
                    DetermineSearch(searchAnswer, myLibrary);
                    //ask user if they want to check out a book
                    CheckOutBook(myLibrary);
                    break;
                }
                //Validate input
                else
                {
                    checkOutAnswer = GetInput("That is not valid. Please try again.  Select 1) to see a list of books or 2) to search by keyword.");
                }
            }
        }

        public static void AlphabetizeList(ref Dictionary<string, List<string>> myLibrary)
        {
            //Ask if they want to alphabetize list? 
            string alphabetize = GetInput("Do you want to alphabetize the list?  Press Y to alphabetize.");
            if (alphabetize.ToUpper() == "Y")
            {
                //By author or title?
                string sortList = GetInput("Would you like to sort by 1) book title or 2) author?");
                while (true)
                {
                    if (sortList == "1")
                    {
                        int index = 0;
                        string selection = "title";
                        SortList("Here is the list of books in alphabetical order by Title:", index, selection, ref myLibrary);
                        break;
                    }
                    else if (sortList == "2")
                    {
                        int index = 1;
                        string selection = "author";
                        SortList("Here is the list of books in alphabetical order by Title:", index, selection, ref myLibrary);
                        break;
                    }
                    else
                    {
                        sortList = GetInput("That is not valid. Please try again.  Select 1) to sort by book title or 2) author.");
                        continue;
                    }
                }
            }
        }

        public static void SortList(string message, int index, string selection, ref Dictionary<string, List<string>> library)
        {
            List<string> titles = new List<string> { "Harry Potter and the Sorcerer's Stone", "The Hobbit", "The Girl with the Dragon Tattoo", "The Velveteen Rabbit",
                "Howl's Moving Castle", "The Hunger Games", "Pride and Prejudice", "A Good Earth", "Harry Potter and the Goblet of Fire",
                "The Lion, The Witch, and The Wardrobe", "The Fellowship of the Ring", "A Feast for Crows",};

            List<string> authors = new List<string> { "J.K. Rowling", "J.R.R. Tolkein", "Stieg Larsson", "Margery Williams", "Diana Wynne Jones", "Suzanne Collins",
                "Jane Austen", "Pearl S. Buck", "J.K. Rowling", "C. S. Lewis", "J.R.R. Tolkein", "George R.R. Martin",};

            Dictionary<string, List<string>> tempDictionary = new Dictionary<string, List<string>> { };

            if (selection == "title")
            {
                titles.Sort(); 
                for (int i = 0; i < library.Count; i++)
                {
                    foreach (var entry in library)
                    {
                        if(entry.Value[index] == titles[i])
                        {
                            string key = (i).ToString();
                            tempDictionary.Add(key, entry.Value);

                        }
                    }
                }
                DisplayLibrary(tempDictionary);
            }
            else if (selection == "author")
            {
                authors.Sort();
                for (int i = 0; i < library.Count; i=i)
                {
                    foreach (var entry in library)
                    {
                        if (entry.Value[index] == authors[i])
                        {
                            string key = (i).ToString();
                            tempDictionary.Add(key, entry.Value);
                            i++;

                            if (i >= library.Count)
                            {
                                break;
                            }
                        }
                    }
                }
                DisplayLibrary(tempDictionary);
            }
            else
            {
                selection = GetInput("That is not a valid selection, please try again.");
            }
        }

        public static void DetermineSearch(string searchAnswer, Dictionary<string, List<string>> myLibrary)
        {
            while (true)
            {
                //search by title
                if (searchAnswer == "1")
                {
                    int searchIndex = TITLE;
                    SearchList("Please enter a title keyword to search by (case sensitive):", searchIndex, myLibrary);
                    break;
                }
                //search by author
                else if (searchAnswer == "2")
                {
                    int searchIndex = AUTHOR;
                    SearchList("Please enter an Author to search by (case sensitive):", searchIndex, myLibrary);
                    break;
                }
                else
                {
                    searchAnswer = GetInput("That is not valid. Please try again.  Select 1) to search by Title keyword or 2) to search by Author.");
                    continue;
                }
            }
        }

        public static void SearchList(string message, int index, Dictionary<string, List<string>> selection)
        {
            bool result;
            bool flag = false;
            Console.WriteLine(message);
            string input = Console.ReadLine();

            foreach (var entry in selection)
            {
                result = entry.Value[index].Contains(input);
                if (result)
                {
                    flag = true;
                    Console.WriteLine($"The library contains '{entry.Value[0]}' by author {entry.Value[1]}.");
                }
            }

            if (!flag)
            {
                Console.WriteLine($"Sorry, {input} was not found in the library.");
                MainMenu(selection);
            }
        }

        public static void CheckOutBook(Dictionary<string, List<string>> myLibrary)
        {
            //Ask user to select a book
            string selectedTitle = GetInput("Which book would you like to check out? Please enter the title of the book (case sensitive):");
            bool bookExists = false;

            foreach (var entry in myLibrary)
            {
                if (entry.Value[TITLE] == selectedTitle)
                {
                    bookExists = true;
                    if (entry.Value[STATUS] == CHECKED_IN)
                    {
                        Console.WriteLine($"You have checked out {selectedTitle}.");
                        //update status to checked out
                        myLibrary[entry.Key][STATUS] = CHECKED_OUT;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{selectedTitle} is currently checked out.");
                    }
                }
            }

            if (!bookExists)
            {
                //book doesn't exist, validate input
                Console.WriteLine("That is invalid.");
            } 
        }

        public static void ReturnBook(Dictionary<string, List<string>> myLibrary)
        {
            //Ask user to select a book
            string selectedTitle = GetInput("Which book would you like to return? Please enter the title of the book (case sensitive):");
            bool bookExists = false;

            foreach (var entry in myLibrary)
            {
                if (entry.Value[TITLE] == selectedTitle)
                {
                    bookExists = true;
                    if (entry.Value[STATUS] == CHECKED_OUT)
                    {
                        Console.WriteLine($"You have returned {selectedTitle}.");
                        //update status to checked out
                        myLibrary[entry.Key][STATUS] = CHECKED_IN;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{selectedTitle} is already checked in.");
                    }
                }
            }

            if (!bookExists)
            {
                //book doesn't exist, validate input
                Console.WriteLine("That is invalid.");
            }
        }
    }
}
