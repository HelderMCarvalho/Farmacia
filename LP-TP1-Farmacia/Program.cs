﻿using System;
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
        int codigo;
        string nome;
        float dinheiro;
        List<Receita> receitas;

        //Get e Sets
        public string Nome { get => nome; set => nome = value; }
        public float Dinheiro { get => dinheiro; set => dinheiro = value; }
        public List<Receita> Receitas { get => receitas; set => receitas = value; }
        public int Codigo { get => codigo; set => codigo = value; }

        //Construtor
        public Cliente(int codigo, string nome, float dinheiro, List<Receita> receitas)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.dinheiro = dinheiro;
            this.receitas = receitas;
        }

        //Funções

        /// <summary>
        /// Recebe a farmácia e a lista de medicamentos encomendados
        /// Soma o total a pagar dos medicamentos encomendados
        /// Se o cliente tiver dinheiro paga, se não tiver aparece a respetiva mensagem
        /// </summary>
        /// <param name="farmacia"></param>
        /// <param name="medicamentos"></param>
        public void pagar(Farmacia farmacia, List<Medicamento> medicamentos)
        {
            float totalPagar = 0;
            foreach (Medicamento medicamento in medicamentos)
            {
                totalPagar += (medicamento.Preco * medicamento.Quantidade);
            }
            if (dinheiro >= totalPagar)
            {
                dinheiro -= totalPagar;
                farmacia.Dinheiro += totalPagar;
                Console.WriteLine("\nCompra efetuada com sucesso.");
            }
            else
            {
                Console.WriteLine("\nCompra não efetuada com sucesso. Não tem dinheiro suficiente.");
            }
        }
    }
    class Medicamento
    {
        private int codigo;
        private string nome;
        private float preco;
        private int quantidade;
        private bool tipo;

        //GETS E SETS
        public string Nome { get => nome; set => nome = value; }
        public float Preco { get => preco; set => preco = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public bool Tipo { get => tipo; set => tipo = value; }
        public int Codigo { get => codigo; set => codigo = value; }

        //Construtor
        public Medicamento(int codigo, string nome, float preco, int quantidade, bool tipo)
        {
            this.codigo = codigo;
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

    struct Venda
    {

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

        //Funções

        /// <summary>
        /// Lista todos os medicamentos em stock
        /// </summary>
        public void mostrarMedicamentos()
        {
            Console.WriteLine("Lista de medicamentos:\n");
            foreach(Medicamento medicamento in medicamentos)
            {
                if (medicamento.Quantidade > 0)
                {
                    Console.WriteLine(medicamento.Codigo + " - " + medicamento.Nome + " - " + medicamento.Preco + " euros");
                }
            }
        }

        /// <summary>
        /// Lista todos os medicamentos (mesmo que não existam em stock)
        /// </summary>
        public void mostrarMedicamentosTodos()
        {
            Console.WriteLine("Lista de medicamentos:\n");
            foreach (Medicamento medicamento in medicamentos)
            {
                Console.WriteLine(medicamento.Codigo + " - " + medicamento.Nome + " - " + medicamento.Preco + " euros");
            }
        }

        /// <summary>
        /// Recebe o código do medicamento e devolve o objeto Medicamento desse código
        /// Se for introduzida quantidade como parâmetro, o Objeto Medicamento devolvido vai ter essa quantidade
        /// Se não for introduzida quantidade como parâmetro, o Objeto Medicamento devolvido vai ter a quantidade em stock
        /// </summary>
        /// <param name="codigoMedicamento"></param>
        /// <returns>Devolve um objeto Medicamento</returns>
        public Medicamento obterMedicamento(int codigoMedicamento, int quantidade = -1)
        {
            Medicamento medicamentoFinal = null;
            foreach (Medicamento medicamento in Medicamentos)
            {
                if (codigoMedicamento == medicamento.Codigo)
                {
                    medicamentoFinal = medicamento;
                }
            }
            if (quantidade != -1)
            {
                medicamentoFinal.Quantidade = quantidade;
            }
            return medicamentoFinal;
        }

        /// <summary>
        /// Verifica se um determinado medicamento existe
        /// </summary>
        /// <param name="codigoMedicamento"></param>
        /// <returns>bool onde 1 - Existe e 0 - Não existe</returns>
        public bool existeMedicamento(int codigoMedicamento)
        {
            bool existe = false;
            foreach (Medicamento medicamento in Medicamentos)
            {
                if (codigoMedicamento == medicamento.Codigo)
                {
                    existe = true;
                }
            }
            return existe;
        }

        /// <summary>
        /// Verifica se um determinado medicamento existe em stock numa determinada quantidade
        /// </summary>
        /// <param name="codigoMedicamento"></param>
        /// <param name="quantidade"></param>
        /// <returns>bool onde 1 - Existe em stock e 0 - Não existe em stock</returns>
        public bool existeQuantidade(int codigoMedicamento, int quantidade)
        {
            bool existe = false;
            if (existeMedicamento(codigoMedicamento))
            {
                foreach (Medicamento medicamento in Medicamentos)
                {
                    if ((quantidade <= medicamento.Quantidade) && (medicamento.Codigo == codigoMedicamento))
                    {
                        existe = true;
                    }
                }
            }
            return existe;
        }

        /// <summary>
        /// Retira a quantidade do medicamento especificado
        /// </summary>
        /// <param name="codigoMedicamento"></param>
        /// <param name="quantidade"></param>
        public void retiraQuantidade(int codigoMedicamento, int quantidade)
        {
            if (existeQuantidade(codigoMedicamento, quantidade))
            {
                foreach (Medicamento medicamento in Medicamentos)
                {
                    if (codigoMedicamento == medicamento.Codigo)
                    {
                        medicamento.Quantidade -= quantidade;
                    }
                }
            }
        }

        /// <summary>
        /// Percorre os medicamentos da farmácia e calcula o valor total do stock
        /// </summary>
        /// <returns>float com o valor total do stock da farmácia</returns>
        public float totalMedicamentos()
        {
            float totalMedicamento = 0;
            foreach (Medicamento medicamento in Medicamentos)
            {
                totalMedicamento += medicamento.Preco * medicamento.Quantidade;
            }
            return totalMedicamento;
        }

        /// <summary>
        /// Recebe o código do cliente e devolve um Objeto Cliente desse código ou devolve um Objeto Cliente = null caso não exista
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <returns>Objeto Cliente</returns>
        public Cliente obterCliente(int codigoCliente)
        {
            Cliente clienteAtual = null;
            foreach(Cliente cliente in Clientes)
            {
                if(codigoCliente == cliente.Codigo)
                {
                    clienteAtual = cliente;
                }
            }
            return clienteAtual;
        }

        /// <summary>
        /// Recebe o código do funcionário e devolve um Objeto Funcionario desse código ou devolve um Objeto Funcionario = null caso não exista
        /// </summary>
        /// <param name="codigoFuncionario"></param>
        /// <returns>Objeto Funcionário</returns>
        public Funcionario obterFuncionario(int codigoFuncionario)
        {
            Funcionario funcionarioAtual = null;
            foreach (Funcionario funcionario in Funcionarios)
            {
                if (codigoFuncionario == funcionario.Id)
                {
                    funcionarioAtual = funcionario;
                }
            }
            return funcionarioAtual;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Funcionario func1 = new Funcionario(1, "Toninho", "Chefe");
            Funcionario func2 = new Funcionario(1, "Hédinho", "Base");
            Funcionario func3 = new Funcionario(1, "Carlinhos", "Base");
            List<Funcionario> funcionarios = new List<Funcionario>();
            funcionarios.Add(func1);
            funcionarios.Add(func2);
            funcionarios.Add(func3);

            List<Receita> receitas = new List<Receita>();
            Cliente clie1 = new Cliente(1, "Rebeca", 1000, receitas);
            Cliente clie2 = new Cliente(2, "Quecas", 2000, receitas);
            Cliente clie3 = new Cliente(3, "Rameira", 500, receitas);
            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(clie1);
            clientes.Add(clie2);
            clientes.Add(clie3);

            Medicamento medic1 = new Medicamento(1, "Preservativos M x12 Durex", 8, 100, false);
            Medicamento medic2 = new Medicamento(2, "Pílula", 5, 100, true);
            Medicamento medic3 = new Medicamento(3, "Pílula do dia seguinte", 2, 100, true);
            List<Medicamento> medicamentos = new List<Medicamento>();
            medicamentos.Add(medic1);
            medicamentos.Add(medic2);
            medicamentos.Add(medic3);

            Farmacia farmacia = new Farmacia(funcionarios, clientes, medicamentos, 100000);

            Cliente clienteAtual = null;
            Funcionario funcionarioAtual = null;

            bool acabou = false;
            while (!acabou)
            {
                Console.Clear();
                Console.Write("Que tipo de utilizador é? (0 - Cliente ou 1 - Funcionário): ");
                string tipoUtilizador = Console.ReadLine();
                switch (tipoUtilizador)
                {
                    case "0":
                        {
                            while (!acabou)
                            {
                                Console.Write("Introduza o seu código de cliente: ");
                                string codigo = Console.ReadLine();
                                int codigoInt = Int32.Parse(codigo);
                                clienteAtual = farmacia.obterCliente(codigoInt);
                                if (clienteAtual != null)
                                {
                                    acabou = true;
                                }
                                else
                                {
                                    Console.WriteLine("Número de cilente inválido. Introduza novamente.\n");
                                }
                            }
                            break;
                        }
                    case "1":
                        {
                            while (!acabou)
                            {
                                Console.Write("Introduza o seu código de funcionário: ");
                                string codigo = Console.ReadLine();
                                int codigoInt = Int32.Parse(codigo);
                                funcionarioAtual = farmacia.obterFuncionario(codigoInt);
                                if (funcionarioAtual != null)
                                {
                                    acabou = true;
                                }
                                else
                                {
                                    Console.WriteLine("Número de funcionário inválido. Introduza novamente.\n");
                                }
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Opção inválida.");
                            break;
                        }
                }
            }

            acabou = false;
            while (!acabou)
            {
                Console.Clear();
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
                            Console.Clear();
                            if (clienteAtual == null)
                            {
                                Console.WriteLine("Não tem permissão para usar esta função.");
                            }
                            else
                            {
                                List<Medicamento> encomenda = new List<Medicamento>();
                                bool acabou1 = false;
                                while (!acabou1)
                                {
                                    farmacia.mostrarMedicamentos();  //Mostrar todos os medicamentos
                                    Console.Write("\nIntroduza o código do medicamento que quer comprar (0 para finalizar a compra): ");
                                    string codigoMedicamento = Console.ReadLine();
                                    int codigoMedicamentoInt = Int32.Parse(codigoMedicamento);
                                    if (codigoMedicamentoInt != 0)
                                    {
                                        Console.Write("\nIntroduza a quantidade do medicamento que quer comprar: ");
                                        string quantidadeMedicamento = Console.ReadLine();
                                        int quantidadeMedicamentoInt = Int32.Parse(quantidadeMedicamento);
                                        if (farmacia.existeQuantidade(codigoMedicamentoInt, quantidadeMedicamentoInt)) //Verificar se existem as quantidades do medicamento pedido
                                        {
                                            encomenda.Add(farmacia.obterMedicamento(codigoMedicamentoInt, quantidadeMedicamentoInt));
                                        }
                                    }
                                    else
                                    {
                                        acabou1 = true;
                                    }
                                }
                                clienteAtual.pagar(farmacia, encomenda);  //Pagar medicamentos
                            }
                            while (Console.KeyAvailable)
                            {
                                Console.ReadKey(false);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            if (clienteAtual == null)
                            {
                                Console.WriteLine("Não tem permissão para usar esta função.");
                            }
                            else
                            {
                                //Verificar se existem as quantidades dos medicamentos pedidos na receita
                                //Pagar medicamentos
                            }
                            while (Console.KeyAvailable)
                            {
                                Console.ReadKey(false);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            farmacia.mostrarMedicamentos();  //Mostrar todos os medicamentos
                            while (Console.KeyAvailable)
                            {
                                Console.ReadKey(false);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            if (clienteAtual == null)
                            {
                                Console.WriteLine("Não tem permissão para usar esta função.");
                            }
                            else
                            {
                                Console.Write("Introduza o código da sua venda: ");  //Pedir código de venda
                                string codVenda = Console.ReadLine();
                                //Mostrar os medicamentos comprados e selecionar o que pretende devolver
                            }
                            while (Console.KeyAvailable)
                            {
                                Console.ReadKey(false);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "5":
                        {
                            Console.Clear();
                            if (funcionarioAtual == null)
                            {
                                Console.WriteLine("Não tem permissão para usar esta função.");
                            }
                            else
                            {
                                Console.WriteLine("A farmácia tem " + farmacia.totalMedicamentos() + " euros em stock de medicamentos.");  //Mostrar valor total em medicamentos
                                //Mostrar por tipo
                            }
                            while (Console.KeyAvailable)
                            {
                                Console.ReadKey(false);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "6":
                        {
                            Console.Clear();
                            if (funcionarioAtual == null)
                            {
                                Console.WriteLine("Não tem permissão para usar esta função.");
                            }
                            else
                            {
                                farmacia.mostrarMedicamentosTodos();  //Mostrar a lista de medicamentos
                                //Introduzir o código do medicamento e a quantidade a adicionar ao stock
                            }
                            while (Console.KeyAvailable)
                            {
                                Console.ReadKey(false);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "0":
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
