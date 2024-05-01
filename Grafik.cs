using ByteBuster;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ByteBuster //Programmet er skrevet af Kim Massesson
{
    internal class Grafik
    {
        public void Skriv(int x, int y, string tekst) //en metode, hvor jeg kan positionere en tekst
        {
            Console.SetCursorPosition(x, y);
            Console.Write(tekst);
        }
        public void ByteBusterLogo(int x, int y) //jeg har lavet et logo tegnet med x'er, som jeg kan positionere med Skriv-metoden
        {
            Skriv(x, y + 0, "                                                                                              ");
            Skriv(x, y + 1, "  xxxxxxxxxxx  xxx        xxx  xxxxxxxxxxx xxxxxxxxxxx                                        ");
            Skriv(x, y + 2, "  xxx   xxxxxx  xxx      xxx   xxxxxxxxxxx xxxxxxxxxxx                                        ");
            Skriv(x, y + 3, "  xxx     xxxxx  xxx    xxx        xxx     xxx                                                ");
            Skriv(x, y + 4, "  xxx    xxxx     xxx  xxx         xxx     xxx                                                ");
            Skriv(x, y + 5, "  xxxxxxxxxxxx     xxxxx           xxx     xxxxxxxxxxx                                        ");
            Skriv(x, y + 6, "  xxxxxxxxxxxx      xxx            xxx     xxxxxxxxxxx  xxx                                   ");
            Skriv(x, y + 7, "  xxx      xxxx     xxx            xxx     xxx          x  x  x  x xxxx xxxxx xxxx xx         ");
            Skriv(x, y + 8, "  xxx      xxxxx    xxx            xxx     xxx          xxx   x  x x      x   x    x x        ");
            Skriv(x, y + 9, "  xxx   xxxxxxx     xxx            xxx     xxx          x  x  x  x xxxx   x   xxx  xx         ");
            Skriv(x, y + 10, "  xxxxxxxxxxxxx     xxx            xxx     xxxxxxxxxxx  x   x x  x    x   x   x    x x        ");
            Skriv(x, y + 11, "  xxxxxxxxxxxx      xxx            xxx     xxxxxxxxxxx  xxxx  xxxx xxxx   x   xxxx x  x ©CMIS ");
            Skriv(x, y + 12, "                                                                                              ");
        }
        public void EmptyBox(int x, int y) //denne kan jeg bruge som en clear af det tekst-område som jeg bruger
        {
            Skriv(x, y + 0, "                                                                                             ");
            Skriv(x, y + 1, "                                                                                             ");
            Skriv(x, y + 2, "                                                                                             ");
            Skriv(x, y + 3, "                                                                                             ");
            Skriv(x, y + 4, "                                                                                             ");
            Skriv(x, y + 5, "                                                                                             ");
            Skriv(x, y + 6, "                                                                                             ");
            Skriv(x, y + 7, "                                                                                             ");
            Skriv(x, y + 8, "                                                                                             ");
            Skriv(x, y + 9, "                                                                                             ");
        }
        /*introtekst med time-delay. Jeg brugte meget tid på at finde ud af, 
         *hvordan jeg kunne lave et daly i tid og fandt på at lave et loop med DateTime,
         *inden jeg fandt ud af, at man kan bruge Thread.Sleep() til at pause prog. Derfor anvender jeg først loopet, 
         *for at vise det, og dernæst bruger jeg Thread.Sleep()*/
        public void IntroTekst(int x, int y) 
        {
            Skriv(x + 5, y + 0, "Christian Mørk er altid på talentjagt");

            int tid = 2;
            //Første tidsforløb
            DateTime a = DateTime.Now;
            DateTime b = a.AddSeconds(tid);
            for (int i = 0; i < 100000000; i++) // for-løkken skal hele tiden opdatere sekundNu og gå ud af løkken, når der er gået {tid} sekunder
            {
                DateTime c = DateTime.Now;     //prog henter tiden lige nu og smider ind i variablen c1
                int sekundNu1 = c.Second;      //jeg skal kun bruge sekunder og smider dem i integer variablen sekundNu1
                int nytSekund1 = b.Second;     //nytSekund1 danner jeg ved at lægge to sekunder til vha: DateTime b1 = a1.AddSeconds(tid)

                if (sekundNu1 != nytSekund1)    //når sekundNu1 == nytSekund1 er der gået {tid} sekunder
                {
                    Console.SetCursorPosition(0, 0);//jeg flytter cursoren op i venstre top hjørne så den ikke tager opmærksomhed fra teksten
                }
                else
                {
                    i = 100000000;
                    Console.BackgroundColor = ConsoleColor.Black;
                    EmptyBox(13, 14);
                }
            }

            Skriv(x - 1, y + 0, "Christian Mørk ønsker dig held og lykke med spillet.");
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(2000);
                Console.BackgroundColor = ConsoleColor.Black;
                EmptyBox(13, 14);

            Skriv(x + 7, y + 0, "Vinder du, får du en lille præmie.");
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(2000);
                Console.BackgroundColor = ConsoleColor.Black;
                EmptyBox(13, 14);
 
            Skriv(x + 5, y + 0, "De bedste hilsener fra Christian Mørk.");
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(2000);
                Console.BackgroundColor = ConsoleColor.Black;
                EmptyBox(13, 14);

            Skriv(x + 45, y + 4, "Og så er vi i gang... ");
                Thread.Sleep(2000);
                Console.BackgroundColor = ConsoleColor.Black;
                EmptyBox(13, 14);
        }

        public void Win(int x, int y) //Vinderteksten
        {
            Skriv(x, y + 0, "Tillykke, du har vundet!");
            Skriv(x, y + 1, "Kontakt mig på telefon 0x24688E8"); //Bonusinfo: Hvis man omdanner nummeret bliver det: 38177000

            Skriv(x, y + 3, "Venlig hilsen Christian");

            Skriv(x, y + 5, "Fortsat god festival og husk nu at få din præmie!");
        }

        public void Rammer() //rammerne omkring logo og tekstfeltet
        {
            //Her tegner jeg et rektangel

            //første vandrette streg
            for (int i = 0; i < 93; i++)
            {
                Skriv(13 + i, 1, "─");
            }
            //anden vandrette stribe
            for (int i = 0; i < 93; i++)
            {
                Skriv(13 + i, 13, "─");
            }
            //tredje vandrette stribe
            for (int i = 0; i < 93; i++)
            {
                Skriv(13 + i, 24, "─");
            }
            //venstre lodret streg
            for (int i = 0; i < 22; i++)
            {
                Skriv(12, 2 + i, "│");
            }
            //højre lodret streg
            for (int i = 0; i < 22; i++)
            {
                Skriv(106, 2 + i, "│");
            }
            //venstre top hjørne
            Skriv(12, 1, "┌");

            //Højre top hjørne
            Skriv(106, 1, "┐");

            //Venstre ml hjørne
            Skriv(12, 13, "├");

            //Højre ml hjørne
            Skriv(106, 13, "┤");

            //Venstre ml hjørne
            Skriv(12, 24, "└");

            //Højre nedre hjørne
            Skriv(106, 24, "┘");

        }
    }
}
