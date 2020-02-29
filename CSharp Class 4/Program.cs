using System;
using System.Linq.Expressions;
using System.Net;

namespace CSharp_Class_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Írjuk ki egy tömb elemeit vesszővel elválasztva úgy,
            //hogy az utolsó elem után ne legyen vessző
            var tomb = new int[10];

            for (int i = 0; i < tomb.Length; i++)
            {
                if (i <= tomb.Length - 2)
                    Console.Write(tomb[i] + ", ");
                else
                    Console.WriteLine(tomb[i]);
            }

            //Mit csinálunk ha később megint ki kell írni?
            //Másoljuk a kódot:

            for (int i = 0; i < tomb.Length; i++)
            {
                if (i <= tomb.Length - 2)
                    Console.Write(tomb[i] + ", ");
                else
                    Console.WriteLine(tomb[i]);
            }

            //És ha később megint ki kell írni?
            //Másoljuk

            for (int i = 0; i < tomb.Length; i++)
            {
                if (i <= tomb.Length - 2)
                    Console.Write(tomb[i] + ", ");
                else
                    Console.WriteLine(tomb[i]);
            }

            //És ha megint ki kell írni?
            //Másoljuk megint?
            //És ha vessző helyett pontosvesszővel kell kiírni?
            //Mindenhol átírjuk?
            //Mi van ha valahol elfelejtjük?
            //Kell egy jobb megoldás!

            //Megoldás: metódusok
            //Metódus: utasítások sorozata, melyeknek adunk egy nevet
            //Hozzunk létre egy PrintArray metódust (PrintArray1 és PrintArray2)

            //Ahhoz, hogy egy metódusban levő utasítások lefussanak, ahhoz a metódust meg kell hívni
            //Hívjuk meg a PrintArray2 metódust:
            PrintArray2(tomb);

            //Mi van ha később ismét ki kell írni a tömböt?
            //Hívjuk meg megint
            PrintArray2(tomb);

            //Milyen utasításokat használhatunk egy metódusban?
            //Lásd: Example1
            Example1();

            //Fontos: a metódus paraméterének neve és a változó neve független egymástól
            //A paraméternek bármi lehet a neve (legyen beszédes!), mivel csak a metódusban lesz érvényes
            //Lásd: PrintArray3
            PrintArray3(tomb);

            //Vegyük észre: a Write egy metódus, a WriteLine egy metódus, a Parse egy metódus stb.
            //Sőt, a Main (amiben most vagyunk) is egy metódus, csak egy speciális metódus,
            //mivel ez a program belépési pontja

            //Mi van ha pontosvesszővel kell kiírni a tömb elemeit vessző helyett?
            //Létrehozhatunk egy új metódust, mely pontosvesszővel írja ki vagy ennél jobb megoldás,
            //ha az elválasztó karakter a metódus egyik paramétere
            PrintArray4(tomb, ',');
            PrintArray4(tomb, ';');

            //Mi van, akkor ha én nem szeretném minden metódushívásnál megadni az elválasztó karaktert,
            //hiszen általában vesszővel elválasztva szoktunk elemeket felsorolni?
            //Használjunk alapértelmezett értékkel rendelkező paramétereket (PrintArray5)

            //Nem adok meg elválasztó karaktert, így az alapértelmezetten megadott értéket (vessző) kapja meg a paraméter
            PrintArray5(tomb);

            //De megadhatok mást is és akkor azt az értéket kapja meg a paraméter
            PrintArray5(tomb, ';');

            //Fontos, hogy az alapértelmezett értékkel rendelkező paramétereknek a paraméterlista végén kell szerepelniük,
            //különben a fordító nem tudja kitalálni, hogy melyik paraméternek adunk vagy nem adunk értéket
            //Lásd: PrintArray6

            //Mi van akkor, ha azt is el szeretném dönteni, hogy legyen-e szóköz az elválasztó karakter előtt és mögött
            //Megoldás: hozzunk létre még két paramétert
            //Lásd: PrintArray7
            PrintArray7(tomb, true, true, ';');

            //Sőt, általában az elválasztó karakter előtt nem szokott szóköz lenni, utána viszont igen
            //Legyenek a szóközöket kezelő paraméterek is alapértelmezett értékkel rendelkezőek
            //Lásd: PrintArray8
            PrintArray8(tomb);

            //Mi van akkor, ha az alapértelmezett paraméterek közül csak egynek szeretnék értéket adni?
            //Használjuk a "paraméterNév:" szintaxist
            PrintArray8(tomb, hasSpaceAfter: false);

            //Ha a "paraméterNév:" szintaxist használjuk, akkor tetszőleges sorrendben adhatunk értéket a paramétereknek
            PrintArray8(tomb, hasSpaceAfter: false, hasSpaceBefore: true);

            //----------------------------------------------------------------------------------------------------

            //Eddig nem volt szó arról, hogy mit jelent a "void" a metódusok létrehozásánál
            //Ennek megértéséhez nézzük meg a ReadLine metódust:
            var line = Console.ReadLine();

            //A ReadLine visszaad nekünk egy értéket
            //Az eddig létrehozott metódusaink nem adtak vissza semmit
            //Ez azért van, mert mi magunk mondtuk azt, hogy nem adnak vissza semmit
            //Ezt jelenti a "void"

            //Hozzunk létre egy olyan metódust, amely miután befejezte a futását, visszaad egy értéket
            //Például készítsünk egy olyan metódust, amely generál nekünk egy megadott intervallumban levő véletlenekkel feltöltött, megadott méretű tömböt:
            CreateArray(10, 0, 10);

            //A Sum visszaadott egy értéket, de mi nem mentettük el (eldobtuk)
            //Mentsük el a visszaadott értéket:
            var ujTomb = CreateArray(20, 0, 100);

            //Tehát foglaljuk össze:
            //Egy metódusnak lehet visszatérési értéke
            //A visszatérési értéket a metódusban a "return" kulcsszó utáni értékkel tudjuk megadni
            //A megadott visszatérési értéket a metódushívás helyén kapjuk vissza
            //Azaz, mintha a metódushívás kicserélődne a metódus által visszaadott értékre

            //Egy metódusban több "return" utasítást is használhatunk
            //Például keressük meg két szám maximumát:
            var maximum = Max(2, 3);

            //Fontos: ha egy metódusnak van visszatérési értéke, akkor az adott metódusnak minden esetben vissza kell térnie valamilyen értékkel
            //Lásd: Example2

            //"void" metódusban is használhatjuk a "return" utasítást arra az esetre, ha korábban be szeretnénk fejezni a metódust
            Example3(-1);

            //----------------------------------------------------------------------------------------------------

            //Kérdés:
            //Van egy változónk:
            var a = 0;
            //Mi lesz az értéke azután, hogy meghívjuk ezt a metódus?
            //0 vagy 2?
            Example4(a);
            //Válasz: 0

            //Oka: C#-ban (és a legtöbb programozási nyelvben) a paraméterek átadása érték szerint történik
            //Ez azt jelenti, hogy amikor meghívjuk a metódust, akkor nem a megadott változót (annak memóriacímét) adjuk át,
            //hanem a változó által tartalmazott érték másolódik át
            //Tehát ha a metódusban módosítjuk a paraméter értékét, akkor az az eredeti változóra semmilyen hatással sincs

            //Mi van akkor, ha mi mégis szeretnénk, hogy a metódus módosítsa az átadott változó által tárolt értéket?
            //Adjuk át a változót referencia szerint, azaz adjuk át a változó memóriacímét
            //Ehhez jelöljük a metódusban a paramétert a "ref" kulcsszóval, illetve a metódus meghívásakor is jelöljük az átadott változót a "ref" kulcsszóval
            Example5(ref a);

            //Ekkor mivel a változó memóriacímét adtuk át, ezért a metódus valójában az eredeti változó által tárolt értéket fogja módosítani
            //Tehát az érték 2 lesz a metódus lefutása után
            //Vegyük észre: valójában ebben az esetben is érték szerinti paraméterátadás történik, csak ebben az esetben az érték nem a változó által tárolt érték,
            //hanem a változó memóriacímének értéke (tehát ugyanúgy másolódik az érték)

            //Előfordulhat az is, hogy azt szeretnénk elérni, hogy egy metódusnak több visszatérési értéke legyen vagy
            //a metódus maga adjon értéket a paraméternek
            //Ekkor a "ref" kulcsszó helyett használjuk az "out" kulcsszót
            //Ekkor a változónak még csak értéket sem kötelező adnunk
            int b;
            var eredmeny = Example6(out b);

            //Fontos: több érték visszaadására más módszer is van, melyet később fogunk tanulni

            //----------------------------------------------------------------------------------------------------

            //Van egy probléma az eddigi metódusainkkal, mint például a PrintArray-el
            //Csak int tömböt adhatunk át neki
            //Hiba:
            /*var t = new double[10];
            PrintArray8(t);*/

            //Létrehozhatnánk több metódust, amely különféle tömböket vesz át
            //Például: PrintIntArray, PrintDoubleArray stb.
            //Azonban elég zavaró, hogy ezek a metódusok ugyanazt csinálják, mégis más a nevük
            //Továbbá én nem akarok azon gondolkozni, hogy éppen melyik metódust kell meghívnom
            //Egyszerűen csak szeretném meghívni a PrintArray metódust
            //Szerencsére van lehetőségünk arra, hogy ugyanolyan nevű metódust hozzunk létre mint egy másik,
            //amennyiben a metódus paraméterlistája különbözik az előzőtől
            //Lásd: PrintArray9
            var t1 = new int[10];
            var t2 = new double[10];
            var t3 = new string[10];

            PrintArray9(t1);
            PrintArray9(t2);
            PrintArray9(t3);

            //Ezt hívják metódus túlterhelésnek (method overload)
            //Ameddig két vagy több metódusnak ugyanaz a neve, de más a paraméterlistája (más típusú paraméter(ek) és/vagy kevesebb vagy több paraméter),
            //addig a metódusoknak lehet ugyanaz a nevük

            //----------------------------------------------------------------------------------------------------

            //Fontos: egy metódus képes önmagát is meghívni
            //Azonban ha ezt a technikát nem használjuk megfelelően (túl sokszor hívja önmagát vagy egymást egy vagy több metódus),
            //akkor úgynevezett stack overflow fog bekövetkezni:
            //Example7();

            //Viszont ha helyesen használjuk, akkor egy erőteljes eszköz lehet:
            var fiveFactorial = Factorial(5);

            //----------------------------------------------------------------------------------------------------

            //Debuggolás: https://docs.microsoft.com/en-us/visualstudio/debugger/debugger-feature-tour?view=vs-2019
        }

        //Létrehoztuk a metódust, viszont hibás
        //A tomb változó nem látszik a metóduson belül, csak a Main-ben
        /*static void PrintArray1()
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                if (i <= tomb.Length - 2)
                    Console.Write(tomb[i] + ", ");
                else
                    Console.WriteLine(tomb[i]);
            }
        }*/

        //A metódus létrehozásakor a zárójelek között paramétereket definiálhatunk
        //Amikor meghívjuk a metódust, akkor átadjuk a tömbünket a metódusnak ami immáron tud vele dolgozni
        //Fontos: egy metódus paramétere nem lehet "var", mivel a fordítónak tudnia kell, hogy a paraméter milyen típusú, ahhoz
        //hogy ellenőrizni tudja, helyesen használjuk-e (a C# erősen típusos)
        static void PrintArray2(int[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                if (i <= tomb.Length - 2)
                    Console.Write(tomb[i] + ", ");
                else
                    Console.WriteLine(tomb[i]);
            }
        }

        static void PrintArray3(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i <= array.Length - 2)
                    Console.Write(array[i] + ", ");
                else
                    Console.WriteLine(array[i]);
            }
        }

        static void Example1()
        {
            //A metódusokban mindent használhatunk amit eddig tanultunk

            //Változókat hozhatunk létre
            var a = 0;

            //Egy metódusban létrehozott változó az adott metódus lokális változója,
            //azaz csak az adott metóduson belül létezik és látható

            //Vegyük észre: a metódus paraméterei lényegében a metódus lokális változói amelyeknek híváskor értéket adunk

            //Ciklusokat és elágazásokat használhatunk stb.
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                    Console.WriteLine(i);
            }
        }

        static void PrintArray4(int[] array, char separator)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i <= array.Length - 2)
                    Console.Write(array[i] + separator.ToString() + " ");
                else
                    Console.WriteLine(array[i]);
            }
        }

        static void PrintArray5(int[] array, char separator = ',')
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i <= array.Length - 2)
                    Console.Write(array[i] + separator.ToString() + " ");
                else
                    Console.WriteLine(array[i]);
            }
        }

        //Hiba: az alapértelmezett értékkel rendelkező paramétereknek a paraméterlista végén kell lenniük
        /*static void PrintArray6(char separator = ',', int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i <= array.Length - 2)
                    Console.Write(array[i] + separator.ToString() + " ");
                else
                    Console.WriteLine(array[i]);
            }
        }*/

        static void PrintArray7(int[] array, bool hasSpaceBefore, bool hasSpaceAfter, char separator = ',')
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i <= array.Length - 2)
                    Console.Write(array[i] + (hasSpaceBefore ? " " : "") + separator + (hasSpaceAfter ? " ": ""));
                else
                    Console.WriteLine(array[i]);
            }
        }

        static void PrintArray8(int[] array, char separator = ',', bool hasSpaceBefore = false, bool hasSpaceAfter = true)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i <= array.Length - 2)
                    Console.Write(array[i] + (hasSpaceBefore ? " " : "") + separator + (hasSpaceAfter ? " " : ""));
                else
                    Console.WriteLine(array[i]);
            }
        }

        //A "void" helyett azt mondjuk, hogy ez a metódus egy int[] típusú értékkel tér vissza
        //Ez a metódus visszatérési típusa
        static int[] CreateArray(int size, int min, int max)
        {
            var random = new Random();
            var array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max);
            }

            //A return azt mondja, hogy ezen a ponton vége a metódusnak és visszaadunk egy a visszatérési típusnak megfelelő értéket
            return array;
        }

        //Egy metódus, több "return" utasítás
        //vegyük észre: egy metódusból bármikor visszatérhetünk, nem csak a legvégén
        static int Max(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;

            //Egyszerűbben, egy "return"-el:
            //return a > b ? a : b;
        }

        //Hiba: mivel a metódsnak van visszatérési értéke, ezért minden lehetséges lefutáskor vissza kell adnia valamit
        /*static int Example2(int a)
        {
            if (a > 0)
                return 0;
        }*/

        static void Example3(int a)
        {
            //Ha itt lenne ez a "return", akkor a metódus többi része soha nem futna le
            //return;

            if (a < 0)
                return;

            for (int i = 0; i < a; i++)
            {
                Console.WriteLine(a);
            }
        }

        static void Example4(int x)
        {
            x = 2;
        }

        static void Example5(ref int x)
        {
            x = 2;
        }

        static int Example6(out int x)
        {
            x = 2;

            return 0;
        }

        static void PrintArray9(int[] array, char separator = ',', bool hasSpaceBefore = false, bool hasSpaceAfter = true)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i <= array.Length - 2)
                    Console.Write(array[i] + (hasSpaceBefore ? " " : "") + separator + (hasSpaceAfter ? " " : ""));
                else
                    Console.WriteLine(array[i]);
            }
        }

        static void PrintArray9(double[] array, char separator = ',', bool hasSpaceBefore = false, bool hasSpaceAfter = true)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i <= array.Length - 2)
                    Console.Write(array[i] + (hasSpaceBefore ? " " : "") + separator + (hasSpaceAfter ? " " : ""));
                else
                    Console.WriteLine(array[i]);
            }
        }

        static void PrintArray9(string[] array, char separator = ',', bool hasSpaceBefore = false, bool hasSpaceAfter = true)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i <= array.Length - 2)
                    Console.Write(array[i] + (hasSpaceBefore ? " " : "") + separator + (hasSpaceAfter ? " " : ""));
                else
                    Console.WriteLine(array[i]);
            }
        }

        static void Example7()
        {
            Example7();
        }

        static int Factorial(int n)
        {
            if (n == 1)
                return 1;

            return n * Factorial(n - 1);
        }
    }
}
