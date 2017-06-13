using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPFCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Verificador de CPF---");
            Console.WriteLine("\nDigite o CPF (sem pontos): ");
            string cpf = Console.ReadLine();
            Console.WriteLine("Digite o Digito Verificador (digite n caso não queria verificar): ");
            string digt = Console.ReadLine();
            // por motivos praticos, a verificação para letras não foi implementada.
            if (cpf.Length > 0)
            {
                string dv = calculaCPF(cpf);
                Console.WriteLine("O digito verificador é {0} ", dv);
            }

            if (digt != "n")
            {
                bool dv = isValid(digt, calculaCPF(cpf));
                if (dv == true)
                {
                    Console.WriteLine("Este cpf é válido");
                }
                else
                {
                    Console.WriteLine("Este cpf é inválido");
                }
            }

            Console.WriteLine("Execução terminada, digite qualquer tecla para continuar...");
            Console.ReadKey();

        }

        static string calculaCPF(string cpf)
        {
            int firstDigit = 0, secondDigit = 0;
            int firstCount = 10, secondCount = 11;

            for (int i = 0; i < cpf.Length; i++)
            {
                firstDigit += Int32.Parse(cpf[i]+"") * firstCount;
                secondDigit += Int32.Parse(cpf[i]+"") * secondCount;

               firstCount --;
               secondCount --;
            }

            firstDigit = 11 - (firstDigit % 11);
            if (firstDigit > 9) firstDigit = 0;
            if (firstDigit < 2) firstDigit = 0;
            //importante notar que o primeiro digito é usado no calculo do segundo.
            secondDigit += firstDigit * 2;

            secondDigit = 11 - (secondDigit % 11);
            if (secondDigit > 9) secondDigit = 0;
            
            return "" + firstDigit + secondDigit;
        }

        /*embora não pareça necessário, é interessante criar um método assim, uma vez que se forem julgadas 
         * futuras modificações, basta acrescer ou remover código. */

        static bool isValid(string dv, string calcDv)
        {
            if (dv == calcDv)
            {
                return true;
            }
            return false;
        }
    }
}
