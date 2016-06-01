using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Tarea3_1
{
    class Reader {
    private static Thread inputThread;
    private static AutoResetEvent getInput, gotInput;
    private static string input;

    static Reader()
    {
        getInput = new AutoResetEvent(false);
        gotInput = new AutoResetEvent(false);
        inputThread = new Thread(reader);
        inputThread.IsBackground = true;
        inputThread.Start();
    }

    private static void reader()
    {
        while (true)
        {
            getInput.WaitOne();
            input = Console.ReadLine();
            gotInput.Set();
        }
    }

        public static string ReadLine(int timeOutMillisecs)
        {
            getInput.Set();
            bool success = gotInput.WaitOne(timeOutMillisecs);
            if (success)
                return input;
            else
                throw new TimeoutException("User did not provide input within the timelimit.");
        }
    }
class Program
    {


        static string [,]tabla = {{"0", "0000", "0", "0", "0000" },{"1","001","1","1", "001" },{"2","0010","2","2","0010" },{"3","0011","3","3", "0011" },{"4","0100","4","4", "0100" },{"5","0101","5","5", "0101" },{"6","0110","6","6", "0110" },{"7","0111","7","7", "0111" },{"8","1000","10","8", "1000" },{"9","1001","11","9", "1001" },{"10","1010","12","A", "1010" },{"11","1011","13","B", "1011" },{"12","1100","14","C", "1100" }, {"13","1101","15","D", "1101" }, {"14","1110","16","E", "1110" },{"15","1111","17","F", "1111" } };
       static Random r = new Random();


        static int buenas1 = 0;
        static int malas1 = 0;
        static int buenas2 = 0;
        static int malas2 = 0;
        static int option = 0;
        static void Main()
        {
            do
            {
                Console.Clear();
                //for (int x = 0; x < 15; x++)
               // {
                  //  for(int y = 0; y < 4; y++)
                 //   {

                      //  Console.Write(tabla[x,y]+"\t");
                    //    }

                    
                    //}
                    Console.WriteLine("­­Juego de agilidad numérica­­");
                Console.WriteLine("1.\tBinario ­ Octal o Octal­ Binario\n2.\tBinario ­ Hexadecimal o Hexadecimal ­ Binario\n3.\tVer notas\n4.\tNo jugar");
                option = int.Parse(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        //Binario ­ Octal o Octal­ Binario
                        Console.Clear();
                        opcion1();
                        break;


                    case 2:
                        //Binario ­ Hexadecimal o Hexadecimal ­ Binario
                        Console.Clear();
                        opcion2();
                        break;

                    case 3:
                        //Ver notas
                        Console.Clear();
                        opcion3();
                        break;

                    case 4:
                        //Salir
                        break;



                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Seleccione una opción válida..");
                            Console.ReadKey();
                            break;
                        }
                }


            } while (option != 4);

        }//fin main

        static void opcion1()
        {
            try { 
            for (int x = 0; x < 10; x++)
            {
                Console.WriteLine("Binario ­ Octal o Octal­ Binario");
                int aleatorio1 = r.Next(0, 16);
                int aleatorio2 = r.Next(1,3);
                // Console.WriteLine(aleatorio1);
                //Console.WriteLine(aleatorio2);
                
                    Console.Write(tabla[aleatorio1, aleatorio2]+"\tIngrese el resultado=");

                string result = Reader.ReadLine(8000);
                
               if (aleatorio2 == 1)
                {

                    if (result.Equals(tabla[aleatorio1 , aleatorio2 + 1]))
                    {
                        buenas1 = buenas1 + 1;
                    }
                    else
                    {
                        malas1 = malas1 + 1;
                    }
                }else
                {
                    if(result.Equals(tabla[aleatorio1 , aleatorio2 - 1]))
                    {
                        buenas1 = buenas1 + 1;
                    }
                    else
                    {
                        malas1 = malas1 + 1;
                    }

                }
            }
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Se acabo el tiempo.");
                
            }
            Console.ReadKey();
            
        }

        static void opcion2()
        {
            try
            {
                for (int x = 0; x < 10; x++)
            {
                Console.WriteLine("Binario ­ Hexadecimal o Hexadecimal ­ Binario");
                int aleatorio1 = r.Next(0, 16);
                int aleatorio2 = r.Next(3, 5);
                // Console.WriteLine(aleatorio1);
                //Console.WriteLine(aleatorio2);
                Console.Write(tabla[aleatorio1, aleatorio2] + "\tIngrese el resultado=");
                string result = Reader.ReadLine(8000);
                if (aleatorio2 == 3)
                {

                    if (result.Equals(tabla[aleatorio1, aleatorio2 + 1]))
                    {
                        buenas2 = buenas2 + 1;
                    }
                    else
                    {
                        malas2 = malas2 + 1;
                    }
                }
                else
                {
                    if (result.Equals(tabla[aleatorio1, aleatorio2 - 1]))
                    {
                        buenas2 = buenas2 + 1;
                    }
                    else
                    {
                        malas2 = malas2 + 1;
                    }

                }
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Se acabo el tiempo.");

            }
            Console.ReadKey();


        }

        static void opcion3()
        {
            Console.WriteLine("Binario ­ Octal o Octal­ Binario");
            Console.WriteLine("Buenas\tMalas");
            Console.WriteLine(buenas1 + "\t" + malas1);
            if (buenas1 >= 8)
            {
                Console.WriteLine("Gano");
            }else
            {
                Console.WriteLine("Perdio");
            }
            Console.WriteLine("");
            Console.WriteLine("Binario ­ Hexadecimal o Hexadecimal ­ Binario");
            Console.WriteLine("Buenas\tMalas");
            Console.WriteLine(buenas2 + "\t" + malas2);
            if (buenas2 >= 8)
            {
                Console.WriteLine("Gano");
            }
            else
            {
                Console.WriteLine("Perdio");
            }
            Console.ReadKey();


        }

    }   
}
