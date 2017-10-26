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
        List<Medicamento> receita;
    }

    class Funcionario
    {
        private int id;
        private string nome;
        private string funcao; /* Chefe e Base */

        public Funcionario(int id, string nome, string funcao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Funcao = funcao;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Funcao { get => funcao; set => funcao = value; }
    }

    class Farmacia
    {
        List<Funcionario> funcionarios;
        List<Cliente> clientes;
        List<Medicamento> medicamentos;
        
        //GETS E SETS

        public List<Funcionario> Funcionarios { get => funcionarios; set => funcionarios = value; }
        public List<Cliente> Clientes { get => clientes; set => clientes = value; }
        public List<Medicamento> Medicamentos { get => medicamentos; set => medicamentos = value; }

        //Construtor

        public Farmacia(List<Funcionario> funcionarios, List<Cliente> clientes, List<Medicamento> medicamentos)
        {
            this.Funcionarios = funcionarios;
            this.Clientes = clientes;
            this.Medicamentos = medicamentos;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
