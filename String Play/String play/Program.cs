using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_play
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("brincadeiras com strings\n Escreva palavra:");
            string pal = Console.ReadLine();
            bool palPalindrome = isPalindrome(pal);
            Dictionary<char, int> letterCount = countLetters(pal);

            if (pal.Length == 0) {
                Console.WriteLine("Não tem palavra. Pressione tecla para terminar.");
                Console.ReadKey();
            }
            if (palPalindrome == true)
            {
                Console.WriteLine("a palavra é palímdrome!");
            }
            else {
                Console.WriteLine("A palavra não é palímdrome!");
            }

            Console.WriteLine("Contagem de letras: ");
            foreach (var a in letterCount)
            {
                Console.WriteLine("letra: {0}: {1} vezes", a.Key, a.Value);
            }

            switchVowel(pal);

            Console.WriteLine("Palavra invertida: {0}: ",reverse(pal));

            Console.WriteLine("programa finalizado, pressione tecla para finalizar...");
            Console.ReadKey();
        }

        // verifica se uma string é palímdrome.
        static bool isPalindrome(string word)
        {
            int i = 0; int j = word.Length - 1;
            while(i < j)
            {
                if (word[i] != word[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }
        // cria uma estrutura de dados com a contagem de todas as letras.
        static Dictionary<char, int> countLetters(string word)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach(char w in word)
            {
                if (dict.ContainsKey(w))
                {
                    dict[w] += 1;
                }
                else
                {
                    dict[w] = 1;
                }
            }
            return dict;
        }

        //troca vogais por números
        static void switchVowel(string word)
        {
            string newWord = word.Replace('a', '4').Replace('e', '3').Replace('i', '1').Replace('o', '0');
            Console.WriteLine("nova palavra: {0}",newWord);
        }

        //inverte a string
        static string reverse(string word)
        {
            string reversedWord = "";
            for (int i = word.Length - 1; i >= 0; i--)
            {
                reversedWord += word[i];
            }

            return reversedWord;
        }
     }
}
