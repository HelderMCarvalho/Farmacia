using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Farmácia:
        - Funcionários,Clientes;
        - Medicamentos;
        - Receita;
    Ações da Farmácia:
        - Comprar medicamentos;
        - Verificar e Levantar a receita;
        - Encomendar medicamentos;
        - etc...

        Criar as classes, variáveis e structs necessárias para modelar:
        - Funcionários que tem um nome, id e função(o chefe pode comprar e repor os stocks, mas qualquer funcionário pode vender
aos clientes) e Clientes com nome, dinheiro e podendo ter nenhuma ou várias receitas;
        - Medicamentos que tem um nome, quantidade, preço e tipo, sendo que o tipo de medicamento determina se ele pode ser
vendido com ou sem receita;
        - Receita que é basicamente uma lista de medicamentos e quantidades mas que só acaba quando todos os medicamentos forem
levantados;

    Ações da Farmácia:
        - Comprar medicamentos;
        - Verificar e Levantar a receita;
        - Repor stocks;
        - Procurar e verificar se existem medicamentos;
        - Verificar se existem as quantidades do medicamento pedido;
        - Acrescentar ou devolver medicamentos em caso de engano (pessoas às vezes enganam-se e em vez de pedir um medicamento
para a constipação pedem para a obstipação);
        - Pagar os medicamentos;
        - Saber o valor total em medicamentos da farmácia (de toda a farmácia e também por tipo, exemplo: valor total em opiáceos)
        - ter um menu com estas opções.
*/

namespace LP_TP1_Farmacia
{
    class Cliente
    {
        string nome;
        float dinheiro;
        List<Receita> receitas;

        //Get e Sets
        public string Nome { get => nome; set => nome = value; }
        public float Dinheiro { get => dinheiro; set => dinheiro = value; }
        public List<Receita> Receitas { get => receitas; set => receitas = value; }

        //Construtor
        public Cliente(string nome, float dinheiro, List<Receita> receitas)
        {
            this.nome = nome;
            this.dinheiro = dinheiro;
            this.receitas = receitas;
        }
    }
    class Medicamento
    {
        private string nome;
        private float preco;
        private int quantidade;
        private bool tipo;

        //GETS E SETS
        public string Nome { get => nome; set => nome = value; }
        public float Preco { get => preco; set => preco = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public bool Tipo { get => tipo; set => tipo = value; }

        //Construtor
        public Medicamento(string nome, float preco, int quantidade, bool tipo)
        {
            this.nome = nome;
            this.preco = preco;
            this.quantidade = quantidade;
            this.tipo = tipo;
        }
    }

    class Receita
    {
        int codigo;
        List<Medicamento> medicamentos;
        bool entregue;

        //Gets e Sets
        public int Codigo { get => codigo; set => codigo = value; }
        public bool Entregue { get => entregue; set => entregue = value; }
        public List<Medicamento> Medicamentos { get => medicamentos; set => medicamentos = value; }

        //Construtor
        public Receita(int codigo, List<Medicamento> medicamentos, bool entregue)
        {
            this.codigo = codigo;
            this.medicamentos = medicamentos;
            this.entregue = entregue;
        }
    }

    class Funcionario
    {
        private int id;
        private string nome;
        private string funcao; /* Chefe e Base */

        //Gets e Sets
        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Funcao { get => funcao; set => funcao = value; }

        //Construtor
        public Funcionario(int id, string nome, string funcao)
        {
            this.id = id;
            this.nome = nome;
            this.funcao = funcao;
        }
    }

    class Farmacia
    {
        List<Funcionario> funcionarios;
        List<Cliente> clientes;
        List<Medicamento> medicamentos;
        float dinheiro;
        
        //GETS E SETS
        public List<Funcionario> Funcionarios { get => funcionarios; set => funcionarios = value; }
        public List<Cliente> Clientes { get => clientes; set => clientes = value; }
        public List<Medicamento> Medicamentos { get => medicamentos; set => medicamentos = value; }
        public float Dinheiro { get => dinheiro; set => dinheiro = value; }

        //Construtor
        public Farmacia(List<Funcionario> funcionarios, List<Cliente> clientes, List<Medicamento> medicamentos, float dinheiro)
        {
            this.funcionarios = funcionarios;
            this.clientes = clientes;
            this.medicamentos = medicamentos;
            this.dinheiro = dinheiro;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool acabou = false;
            while (!acabou)
            {
                Console.WriteLine("Bem-vindo à Farmácia CORARE");
                Console.WriteLine("\n----------MENU----------");
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Comprar medicamentos");
                Console.WriteLine("2 - Mostrar receita");
                Console.WriteLine("3 - Procurar e verificar se existem medicamentos");
                Console.WriteLine("4 - Devolver medicamentos");
                Console.WriteLine("5 - Mostrar valor total em medicamentos");
                Console.WriteLine("6 - Repor stock");
                Console.WriteLine("0 - SAIR");
                Console.Write("\nA sua opção: ");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        {
                            //Mostrar todos os medicamentos
                            //Verificar se existem as quantidades do medicamento pedido
                            //Pagar medicamentos
                            Console.Clear();
                            break;
                        }
                    case "2":
                        {
                            //Verificar se existem as quantidades do medicamento pedido
                            //Pagar medicamentos
                            Console.Clear();
                            break;
                        }
                    case "3":
                        {
                            //Mostrar todos os medicamentos
                            Console.Clear();
                            break;
                        }
                    case "4":
                        {
                            //Pedir código de venda
                            //Mostrar os medicamentos comprados e selecionar o que pretende devolver
                            Console.Clear();
                            break;
                        }
                    case "5":
                        {
                            //Pedir password de admin
                            //Mostrar valor total em medicamentos
                            //Mostrar por tipo
                            Console.Clear();
                            break;
                        }
                    case "6":
                        {
                            //Pedir password de admin
                            //Mostrar a lista de medicamentos
                            //Introduzir o código do medicamento e a quantidade a adicionar ao stock
                            Console.Clear();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nMuito obrigado pela sua preferência!");
                            acabou = true;
                            break;
                        }
                }
            }
        }
    }
}
