using System;
using System.Text;

namespace EditorHtml
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("-----------");
            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("DDeseja salvar este arquivo?");

            Console.WriteLine("SIM ou NÃO");

            string resposta = Console.ReadLine();

            if (resposta.ToUpper().Contains("SIM"))
            {

                Salvar(file.ToString());
            }
            else
            {
                Viewer.Show(file.ToString());
            }

        }

        public static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu.Show();
        }

        public static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Digite o caminho do arquivo:");
            var path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu.Show();
        }
    }
}