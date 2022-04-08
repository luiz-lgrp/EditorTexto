using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
          Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Deseja criar um novo arquivo ou abrir?");
            Console.WriteLine("1 - Abrir");
            Console.WriteLine("2 - Criar");
            Console.WriteLine("0 - Sair");
            byte option = byte.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: CriarEditar(); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void CriarEditar()
        {
            Console.Clear();
            Console.WriteLine("Digite o seu texto aqui! (ESC para sair)");
            Console.WriteLine("--------------------");

            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Deseja salvar onde?");
            var path = Console.ReadLine();

            using(var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo salvo em {path} com sucesso!");
            Console.ReadLine();
            Menu();
        }
   
    }


}
