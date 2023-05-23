namespace Menu_maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // add start/end text
            // indexing is weird? idk how to fix that yet
            // add a better way to manage default arguments

            List<MenuOption> menu1Options = new List<MenuOption>() 
            { 
                new MenuOption("I will say hi", SayHi),
                new MenuOption("I will say hi... again", SayHi)
            };

            Menu menu = new(
                withExit: true,
                prompt: "Pick an option:",
                options: menu1Options
                );

            menu.Run();
        }

        static void SayHi()
        {
            Console.WriteLine("Hi");
        }
    }

    public class Menu
    {
        public List<MenuOption> Options { get; set; }
        public bool WithExit { get; set; }
        public string Prompt { get; set; }

        public Menu(List<MenuOption> options, bool withExit = true, string prompt = ">")
        {
            Options = options;
            WithExit = withExit;
            Prompt = prompt;

            if (WithExit)
                Options.Add(new MenuOption("Exit", () => { }));
        }

        public void Display()
        {
            for (int i = 0; i < Options.Count; i++)
                Console.WriteLine($"{i + 1}. {Options[i].Name}");
        }

        public void Run()
        {
            string choice;
            int choiceNum;

            do
            {
                choice = "";

                Display();

                while (!(int.TryParse(choice, out choiceNum) && choiceNum >= 1 && choiceNum <= Options.Count))
                {
                    Console.Write($"{Prompt} ");
                    choice = Console.ReadLine();
                }

                Options[choiceNum - 1].Action();
            }
            while( WithExit && choiceNum != Options.Count);


        }
    }

    public class MenuOption
    {
        public string Name { get; set; }
        public Action Action { get; set; }

        public MenuOption(string name, Action action)
        {
            Name = name;
            Action = action;
        }
    }
}