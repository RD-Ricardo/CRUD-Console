
namespace Crud_console
{
    public class Opcoes : Funcoes
    {
         public Opcoes(int op){
            switch(op){
                case 1: 
                    listar();
                break;
                case 2:
                    cadastar();
                break;
                case 3:
                    editar();
                break;
                case 4:
                    excluir();
                break;
            }
        }
    }
}