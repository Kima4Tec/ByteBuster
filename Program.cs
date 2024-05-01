using ByteBuster;
using System;
using System.Timers;    
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using System.Media;

namespace ByteBuster
{
    internal class Program//Programmet er skrevet af Kim Massesson. Mit mål er at bruge det meste af, hvad jeg har lært i dette modul.
    {
        static void Main(string[] args)                
        {
            Grafik Pos = new Grafik();

            int antalRigtige = 0;
            int antalForkerte = 0;

            //Grafikken sættes op bl.a. ved at hente metoder, som jeg har lavet, fra anden klasse. Men først vælger jeg tekst- og baggrundsfarve
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            
            Pos.ByteBusterLogo(12, 1);
            Pos.Rammer();
            Console.ResetColor();

            //her kalder jeg introteksten frem fra Grafik-klassen. Der kommer en sætning frem ad gangen ved et tids-delay. Jeg bruger både et delay, som jeg selv har lavet og Thread.Sleep
            Pos.IntroTekst(34, 18);
            Console.Beep(400,1000);
            //SystemSounds.Asterisk.Play();
            /*Jeg laver en menu med et do-while loop og med en switch, hvor man kan vælge sværhedsgrad.
             *Variablen "maks" bruger jeg til at sætte max-værdien i RandomObj(min,max) og "valg" til 
             *at indholde brugerens valg. Man kan vælge mellem "let" som er 32, "øvet" 128 eller "avanceret" 255.*/
            string valg;
            int maks=32;
            do
            {

                Pos.Skriv(46,15,"* Vælg sværhedsgrad *");
                Pos.Skriv(46, 17, "Let:         [Tast 1]");
                Pos.Skriv(46, 18, "Øvet         [Tast 2]");
                Pos.Skriv(46, 19, "Avanceret:   [Tast 3]");
                Pos.Skriv(46, 20,$"                     ");
                Console.SetCursorPosition(65, 20);
                var enTast = Console.ReadKey();
                valg = enTast.KeyChar.ToString();
                
            }
            while (valg != "1" && valg != "2" && valg != "3");
            {
                switch (valg)
                {
                    case "1":
                        {
                            maks = 33;
                            break;
                        }
                    case "2":
                        {
                            maks = 129;
                            break;
                        }
                    case "3":
                        {
                            maks = 256;
                            break;
                        }

                    default:
                        {
                            Pos.Skriv(32, 22, "Du skal vælge en sværhedsgrad.");
                            break;
                        }
                }
            }

            //lav et tilfældigt binært tal, som bruger skal gætte
            for (int i = 1; i < 6; i++)                                             //loop, der tæller forsøgene. Der må max være fem forsøg
            {
                Random RandomObj = new Random();                                        //her laver prog en ny instans så der kan findes en tilfældig byte
                int nummer = RandomObj.Next(1, maks); 
                Int32 svar = 0;                                                     //svar får en værdi
                string bin = Convert.ToString(nummer, 2);
                /*Jeg omdanner det binære tal, som har type string til integer for så
                 * kan jeg formatere den med D8, og dermed få 0 foran det binære tal.
                 * jeg kunne have gjort det samme med Padleft(8,'0'). Det bruger jeg i min
                 * anden opgave*/
                Int32 nytnr = Convert.ToInt32(bin);                           

                //fang andre indtastninger end integer - tal og fortæl bruger, at denne skal skrive et tal. Man bruger et forsøg på fejlen
                try
                {
                    Pos.EmptyBox(13, 14);
                    Pos.Skriv(32, 22, $"Antal rigtige svar: {antalRigtige}");
                    Pos.Skriv(55, 22, $"Antal forkerte svar: {antalForkerte}");
                    Pos.Skriv(32, 15, $"Forsøg nr: {i}: ");
                    Pos.Skriv(32, 16, "Omskriv det nedenstående binære tal til et decimaltal.");
                    Pos.Skriv(32, 17, $"{nytnr:D8}");                                //det binære tal bliver fyldt ud med nuller pga D8 (Fra Microsoft:"The precision specifier indicates the minimum number of digits desired in the resulting string. If required, the number is padded with zeros to its left to produce the number of digits given by the precision specifier")
                    Pos.Skriv(32, 18, "Indtast dit svar: ");                        //brugerindtastning
                    svar = Convert.ToInt32(Console.ReadLine());                     //{svar}s type skal gerne passe til {nummer}s type og bliver derfor konverteret til Int32
                }
                catch
                {
                    Pos.Skriv(32, 18, $"Du skal skrive et tal. ");                    //udskrift hvis bruger skriver andet end integer-tal
                }

            if (svar == nummer)                                                 //sandt eller falsk
                {
                    antalRigtige++;                                                 //hvis sandt lægges der en værdi til i variablen antalRigtige
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Pos.Skriv(32, 19,"Det var rigtigt! Tryk [ENTER] for at gå videre");
                    Console.ResetColor();
                    
                    if (antalRigtige >= 3)                                          //undersøg om bruger har haft tre vellykkede forsøg
                    {
                        Pos.EmptyBox(13, 14);
                        Pos.Win(34, 16);
                        i = 6;
                    }
                    Console.ReadKey();
                }
                else
                {
                    antalForkerte++;
                    if (antalForkerte >= 3)
                    {
                        Pos.EmptyBox(13, 14);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Pos.Skriv(32, 15 + 1, $"Du ramte rigtigt {antalRigtige} gange og mangler derfor {3 - antalRigtige} rigtige");
                        Pos.Skriv(32, 15 + 2, "svar for at vinde. Tak fordi du spillede med. Fortsat");
                        Pos.Skriv(32, 15 + 3, "god festival!");
                        Console.ResetColor();
                        do
                        {
                            Pos.Skriv(32, 20, "Tryk på [ENTER] for at gå videre");
                        }
                        while (Console.ReadKey().Key != ConsoleKey.Enter);
                        i = 6;
                    }
                    else
                    {
                        //Pos.EmptyBox(13, 14);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Pos.Skriv(32, 19,$"Det var desværre forkert. Det rigtige tal var: ");
                        Console.ResetColor();
                        Console.WriteLine(nummer);
                        Pos.Skriv(32, 20,"Tryk på [ENTER] for at gå videre");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
