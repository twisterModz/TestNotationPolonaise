/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        
        static float Polonaise(string laFormule)
        {
            //transformation formule en vecteur
            string[] vec = laFormule.Split(' ');

            //nombre de case remplie
            int nbcases = vec.Length;

            //boucle tant qu'il reste plus d'une case
            while(nbcases > 1 )
            {
                // recherche d'un signe à partir de la fin
                int k = nbcases - 1;
                while (k>0 && vec[k]!="+" && vec[k] != "-" && vec[k] != "*" && vec[k] != "/")
                {
                    k--;
                }
                //récupération des 2 valeurs numériques
                float v1 = float.Parse(vec[k + 1]);
                float v2 = float.Parse(vec[k + 2]);

                //calcul 
                float result = 0;
                switch (vec[k])
                {
                    case "+": result = v1 + v2; break;
                    case "-": result = v1 - v2; break;
                    case "*": result = v1 * v2; break;
                    case "/": result = v1 / v2; break;
                }

                // stockage du résultat
                vec[k] = result.ToString();

                // décalages de 2 cases pour la suite du vecteur (supprimer 2 cases)
                for(int j=k+1; j < nbcases -2; j++)
                {
                    vec[j] = vec[j + 2];
                }
                nbcases -= 2;
            }
            //retourner le resultat
            return float.Parse(vec[0]);
        }
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
