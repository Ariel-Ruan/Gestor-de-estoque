using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03
{
    [System.Serializable]
    class Curso : Produto , IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome , float preco ,string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas do curso {nome}");
            Console.WriteLine("Digite a Qnt. que você deseja dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saída do produto {nome}");
            Console.WriteLine("Digite a Qnt. que você deseja consumir: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas -= entrada;
            Console.WriteLine("Saída Registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas: {vagas}");
            Console.WriteLine("================================");

        }
    }    
}
