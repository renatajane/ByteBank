using byteBank.Titular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace byteBank.Contas
{
    public class ContaCorrente
    {
        public static int TotalDeContasCriadas { get; private set; }
        public static float TaxaOperacao { get; private set; }

        private int numero_agencia;
        public int Numero_agencia 
        {
            get { return this.numero_agencia; }
            private set {
                    if (value > 0)
                    {
                       this.numero_agencia= value;
                    }
                }

        }

        public string Conta { get; set; }

        private double saldo = 100; 

        public Cliente Titular { get; set; } 
        public void Depositar(double valor) 
        {
            saldo += valor;
        }

        public bool Sacar(double valor) 
        {
            if (valor <= saldo)
            {
                saldo -= valor;
                return true;
            }
            else
            {
                throw new SaldoInsuficienteException("Saldo insuficiente para realizar a operação!");
            }
        }

        public bool Transferir(double valor, ContaCorrente destino)
        {
            if (saldo < valor)
            {
                return false;
            }
            if (valor < 0)
            {
                return false;
            }
            else
            {
                saldo = saldo - valor;
                destino.saldo = destino.saldo + valor;
                return true;
            }
        }

        //public string blabla()
        //{
        //    return "Olá mundo!";
        //}

        //public string mat(double numero1, double numero2)
        //{
        //    double soma = numero1+ numero2;
        //    return ("A soma de " + numero1 + " e " + numero2 + " é : " +soma);
        //}

        //SEGUNDA FORMA DE ESCREVER A MESMA CLASSE ACIMA 
        //public bool Transferir (double valor, ContaCorrente destino)
        //{
        //    if (saldo < valor)
        //    {
        //        return false;
        //    }
        //    else 
        //    {
        //        this.saldo -= valor; 
        //        destino.saldo += valor; 
        //        return true;
        //    }
        //}

        public void SetSaldo(double valor)  
        {
            if (valor < 0)
            {
                return;
            }
            else
            {
                this.saldo = valor;
            }

        }

        public double GetSaldo()
        {
            return this.saldo;
        }

        public ContaCorrente (int numero_agencia, string numero_conta)
        {
            this.Numero_agencia = numero_agencia;
            this.Conta = numero_conta;

            if (numero_agencia <= 0)
            {
                throw new ArgumentException("Número de agência menor ou igual a zero!", nameof(numero_agencia));
            }

            /*
            try 
            {
                TaxaOperacao = 30 / TotalDeContasCriadas;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ocorreu um erro! Não é possível fazer uma divisão por zero!");
            }
            */

            TotalDeContasCriadas++;
        }

    }
}

