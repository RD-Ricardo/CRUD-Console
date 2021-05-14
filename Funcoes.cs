using System;
using System.Linq;
using Crud_console.db;
namespace Crud_console
{
    public class Funcoes
    {
        public void listar()
        {   
            Console.WriteLine("Voce listou");
            //conexao com banco de dados
            using (var db = new db_crudContext())
            {   
                Console.WriteLine("id--nome--telefone--cidade ");
                foreach(var pessoa in db.TbPessoa)
                {
                    Console.WriteLine($"| {pessoa.IdPessoa} | {pessoa.NmPessoa} | {pessoa.NrTelefonePessoa} | {pessoa.NmCidadePessoa} |");
                }
            }
       }

        public void cadastar()
        {
            Console.WriteLine("cadastrou");
            Console.WriteLine("Digite os seguintes campos para cadastrar");
            Console.Write("\n Nome:  ");
            string nome = Console.ReadLine();
            Console.Write("Telefone:  ");
            string telefone = Console.ReadLine();
            Console.Write("Cidade:  ");
            string cidade =  Console.ReadLine();

            using(var db = new db_crudContext())
            {   
               var novaPessoa = new TbPessoa {
                   NmPessoa = nome ,
                   NrTelefonePessoa = telefone,
                   NmCidadePessoa = cidade
               };

               db.TbPessoa.Add(novaPessoa);
               db.SaveChanges();
            }

        }

       public void editar()
       {
           Console.WriteLine("VOce editou");
           listar();
           Console.WriteLine("Selecionao o id para edita");
            int id = Convert.ToInt32(Console.ReadLine());
           using(var db =  new db_crudContext())
           {
               var pessoa =  db.TbPessoa.SingleOrDefault(d => d.IdPessoa == id);
               Console.WriteLine($"Nome:  {pessoa.NmPessoa}");
               Console.Write("Novo nome:  ");
               string nome = Console.ReadLine();
               Console.Write("Telefone:  ");
               string telefone = Console.ReadLine();
               Console.Write("Cidade:");
               string cidade = Console.ReadLine();
               pessoa.NmPessoa = nome;
               pessoa.NrTelefonePessoa = telefone;
               pessoa.NmCidadePessoa = cidade;
               db.SaveChanges();
           }
           
       }

        public void excluir()
        {
            Console.WriteLine("Voce excluiu");

            using(var  db = new db_crudContext())
            {
                listar();
                Console.WriteLine("Selecione um id");
                int id = Convert.ToInt32(Console.ReadLine());
                var pessoa = db.TbPessoa.SingleOrDefault(d => d.IdPessoa == id);
                pessoa.IdPessoa =  id;
                db.Remove(pessoa);
                db.SaveChanges();
            }
            
        }
    }
}