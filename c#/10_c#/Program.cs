using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Chat chat=new Chat();

            Player C = new Player("C");

            chat.add(new Player("A"));
            chat.add(new Player("B"));
            chat.add(C);

            chat.notify("ABC");
            chat.remove(C);
            chat.notify("AB");
        }

    }
}