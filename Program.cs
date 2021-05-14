using System;

namespace Crud_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("--------");
            Console.WriteLine("--Grud--");
            Console.WriteLine("--------");
            Console.WriteLine("Selecione um  opcao");;
            Console.WriteLine("1 - Listar Pessoas");
            Console.WriteLine("2 - Cadastar uma pessoa");
            Console.WriteLine("3 - Editar um pessoa");
            Console.WriteLine("4 - Excluir pessoa");

            int op =  Convert.ToInt32(Console.ReadLine());
            Opcoes p = new Opcoes(op);
        }
    }
}
