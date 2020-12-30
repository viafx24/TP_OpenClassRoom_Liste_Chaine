using System;

namespace TP_OpenClassRoom_Liste_Chaine
{
    class Program
    {
        static void Main(string[] args)
        {
            ListeChainee<int> listeChainee = new ListeChainee<int>();
            listeChainee.Ajouter(5);
            listeChainee.Ajouter(10);
            listeChainee.Ajouter(4);
            Console.WriteLine(listeChainee.Premier.Valeur);
            Console.WriteLine(listeChainee.Premier.Suivant.Valeur);
            Console.WriteLine(listeChainee.Premier.Suivant.Suivant.Valeur);
            Console.WriteLine("*************");
            Console.WriteLine(listeChainee.ObtenirElement(0).Valeur);
            Console.WriteLine(listeChainee.ObtenirElement(1).Valeur);
            Console.WriteLine(listeChainee.ObtenirElement(2).Valeur);
            Console.WriteLine("*************");
            listeChainee.Inserer(99, 0);
            listeChainee.Inserer(33, 2);
            listeChainee.Inserer(30, 2);
            Console.WriteLine(listeChainee.ObtenirElement(0).Valeur);
            Console.WriteLine(listeChainee.ObtenirElement(1).Valeur);
            Console.WriteLine(listeChainee.ObtenirElement(2).Valeur);
            Console.WriteLine(listeChainee.ObtenirElement(3).Valeur);
            Console.WriteLine(listeChainee.ObtenirElement(4).Valeur);
            Console.WriteLine(listeChainee.ObtenirElement(5).Valeur);
        }
    }

    public class Chainage<T>
    {
        public Chainage<T> Precedent { get; set; }
        public Chainage<T> Suivant { get; set; }
        public T Valeur { get; set; }
    }
    public class ListeChainee<T>
    {
        public Chainage<T> Premier { get; private set; }

        public Chainage<T> Dernier
        {
            get
            {
                if (Premier == null)
                    return null;
                Chainage<T> dernier = Premier;
                while (dernier.Suivant != null)
                {
                    dernier = dernier.Suivant;
                }
                return dernier;
            }
        }
        public void Ajouter(T element)
        {
            if (Premier == null)
            {
                Premier = new Chainage<T> { Valeur = element };
            }
            else
            {
                Chainage<T> dernier = Dernier;
                dernier.Suivant = new Chainage<T> { Valeur = element, Precedent = dernier };
            }
        }
        public Chainage<T> ObtenirElement(int indice)
        {
            Chainage<T> temp = Premier;
            for (int i = 1; i <= indice; i++)
            {
                if (temp == null)
                    return null;
                temp = temp.Suivant;
            }
            return temp;
        }

        public void Inserer(T element, int indice)
        {
            if (indice == 0)
            {
                if (Premier == null)
                    Premier = new Chainage<T> { Valeur = element };
                else
                {
                    Chainage<T> temp = Premier;
                    Premier = new Chainage<T> { Suivant = temp, Valeur = element };
                    temp.Precedent = Premier;
                }
            }
            else
            {
                Chainage<T> elementAIndice = ObtenirElement(indice);
                if (elementAIndice == null)
                    Ajouter(element);
                else
                {
                    Chainage<T> precedent = elementAIndice.Precedent;
                    Chainage<T> temp = precedent.Suivant;
                    precedent.Suivant = new Chainage<T> { Valeur = element, Precedent = precedent, Suivant = temp };
                    temp.Precedent = precedent.Suivant;
                }
            }
        }
    }
}
