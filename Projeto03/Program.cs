using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03
{
    [System.Serializable]
    internal class Program
    {
        
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listagem = 1, Adicionar, Remover, Entrada, Saida, Sair };
        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (escolheuSair == false)
            {
                Console.WriteLine("Listagem de Produtos:");
                Console.WriteLine("1-Listagem\n2-Adicionar\n3-Remover\n4-Registrar Entrada\n5-Registrar Saída\n6-Sair");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);

                if (opInt > 0 && opInt < 7)
                {
                    Menu escolha = (Menu)opInt;
                    Console.Clear();
                    switch (escolha)
                    {
                        case Menu.Listagem:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                          Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }
                else
                {
                    escolheuSair = true;
                }
                Console.Clear();
            }
        }

        static void Listagem()
        {
            Console.WriteLine("Lista de Produtos: ");
            int i = 0; 
            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Escolha o ID q deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do produto que você deseja dar entrada:");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id <= produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do produto que você deseja dar baixa:");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id <= produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }
        static void Cadastro()
        {
            Console.WriteLine("Cadastro do Produto: ");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Curso");
            string str = Console.ReadLine();
            int escolheu = int.Parse(str);
            switch (escolheu)
            {
                case 1:
                    CadastrarPFisico();
                    break;                   
                case 2:
                    CadastrarEbook();
                    break;                    
                case 3:
                    CadastrarCurso();
                    break;
            }
        }
        
        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrando produto fisico: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome,preco,frete);
            produtos.Add(pf);
            Salvar();
        }
        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando produto fisico: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }
        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando produto fisico: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook cs = new Ebook(nome, preco, autor);
            produtos.Add(cs);
             Salvar();
        }

        static void Salvar()  
        {
            FileStream stream = new FileStream("produtos.txt " , FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);
            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.txt ", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();            

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if (produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch (Exception e)
            {
                produtos = new List<IEstoque>();
            }
            stream.Close();
            
        }
    }
}
