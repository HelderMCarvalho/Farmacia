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
    class Medicamento
    {
        private string nome;
        private float preco;
        private float quantidade;
        private bool tipo;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Boas Pessoas
            Más Pessoas
        }
    }
}
