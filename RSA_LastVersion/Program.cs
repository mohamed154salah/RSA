using System;
using System.IO;
using System.Text;

namespace RSA_project
{
    class Program
    {
        static void Main(string[] args)
        {
            #region compare with test case

            Console.WriteLine("               RSA:\n  ");
            StreamReader sr;
            StreamReader srOut;
            StreamWriter sw;
            while (true)
            {
                Console.WriteLine("[1] AddTestCases \n[2] SubtractTestCases\n[3] MultiplyTestCases\n[4] DivisionTestCases\n[5] Modofpower\n[0] Exit\n");
                Console.Write("Enter your choice [1-2-3-4-5-0]: ");
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (choice == '0')
                {
                    break;
                }
                switch (choice)
                {
                    case '1':
                        sr = new StreamReader("AddTestCases.txt");
                        sw = new StreamWriter(@"MyRun/AddTestCases.txt");
                        srOut = new StreamReader("AddTestCases_Output.txt");
                        int nCases = int.Parse(sr.ReadLine());
                        long x = System.Environment.TickCount;
                        for (int i = 0; i < nCases; i++)
                        {
                            sr.ReadLine();
                            string FirstNum = sr.ReadLine();
                            string SecandNum = sr.ReadLine();
                            string Output = srOut.ReadLine();
                            Console.Write("Case " + (i + 1).ToString() + ": ");
                            Hnum num1 = new Hnum(FirstNum);
                            Hnum num2 = new Hnum(SecandNum);

                            string R = HugeNum.addition(num1, num2).getnum().ToString();
                            sw.WriteLine(R);
                          
                            if (Output == R)
                            {
                                Console.WriteLine(" COMPLETELY succeed");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice!");
                                return;
                            }
                            srOut.ReadLine();
                            sw.WriteLine();
                        }
                        long y = System.Environment.TickCount;
                        long time = (y - x) * 1000;
                        
                        Console.WriteLine("Time ="+time);
                        srOut.Close();
                        sr.Close();
                        sw.Close();

                        Console.WriteLine("Sample cases are COMPLETELY succeed");
                        Console.WriteLine("\n");
                        break;
                    case '2':
                        long x1 = System.Environment.TickCount;
                        sr = new StreamReader("SubtractTestCases.txt");
                        srOut = new StreamReader("SubtractTestCases_Output.txt");
                        sw = new StreamWriter(@"MyRun/SubtractTestCases.txt");
                        int nCases2 = int.Parse(sr.ReadLine());
                        for (int i = 0; i < nCases2; i++)
                        {
                            sr.ReadLine();
                            string FirstNum = sr.ReadLine();
                            string SecandNum = sr.ReadLine();
                            string Output = srOut.ReadLine();
                            
                            Console.Write("Case " + (i + 1).ToString() + ": ");
                            Hnum num1 = new Hnum(FirstNum);
                            Hnum num2 = new Hnum(SecandNum);
                            String  r = HugeNum.Subtract(num1, num2).getnum().ToString();
                            sw.WriteLine(r);
                            if (Output == r)
                            {
                                Console.WriteLine(" COMPLETELY succeed");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice!");

                            }
                            
                            sw.WriteLine();
                            srOut.ReadLine();
                        }
                        long y1 = System.Environment.TickCount;
                        long time1 = (y1 - x1) * 1000;

                        Console.WriteLine("Time ="+ time1);
                        srOut.Close();
                        sr.Close();
                        sw.Close();
                        Console.WriteLine("Sample cases are COMPLETELY succeed");
                        Console.WriteLine("\n");
                        break;
                    case '3':
                        sr = new StreamReader("MultiplyTestCases.txt");
                        srOut = new StreamReader("MultiplyTestCases_Output.txt");
                        sw = new StreamWriter(@"MyRun/MultiplyTestCases.txt");
                        long x2 = System.Environment.TickCount;
                        int nCases3 = int.Parse(sr.ReadLine());
                        for (int i = 0; i < nCases3; i++)
                        {
                            sr.ReadLine();
                            string FirstNum = sr.ReadLine();
                            string SecandNum = sr.ReadLine();
                            string Output = srOut.ReadLine();
                          
                            Console.Write("Case " + (i + 1).ToString() + ": ");
                            Hnum num1 = new Hnum(FirstNum);
                            Hnum num2 = new Hnum(SecandNum);
                            string  r2 = HugeNum.Multiply(num1, num2).getnum().ToString();

                            sw.WriteLine(r2);
                        
           
                            if (Output == r2)
                            {
                                Console.WriteLine(" COMPLETELY succeed");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice!");
                                return;
                            }
                            srOut.ReadLine();
                            sw.WriteLine();
                        }
               
                        srOut.Close();
                        sr.Close();
                        sw.Close();
                        long y2 = System.Environment.TickCount;
                        long time2 = (y2 - x2) * 1000;

                        Console.WriteLine("Time ="+ time2);
                        Console.WriteLine("Sample cases are COMPLETELY succeed");
                        Console.WriteLine("\n");
                        break;
                   
                    case '4':
                        sr = new StreamReader("DivisionTestCases.txt");
                        srOut = new StreamReader("DivisionTestCases_Output.txt");
                        sw = new StreamWriter(@"MyRun/DivisionTestCases.txt");
                        long x3 = System.Environment.TickCount;
                        int nCases4 = int.Parse(sr.ReadLine());
                        for (int i = 0; i < nCases4; i++)
                        {
                            sr.ReadLine();
                            string FirstNum = sr.ReadLine();
                            string SecandNum = sr.ReadLine();
                            string Output1 = srOut.ReadLine();
                            string Output2 = srOut.ReadLine();

                            Console.Write("Case " + (i + 1).ToString() + ": ");
                            Hnum num1 = new Hnum(FirstNum);
                            Hnum num2 = new Hnum(SecandNum);
                            Hnum[] arr = new Hnum[2];
                            arr= HugeNum.Division(num1, num2);
                            string r2 = arr[0].getnum().ToString();
                            string r3 = arr[1].getnum().ToString();

                            sw.WriteLine(r2);
                            sw.WriteLine(r3);
      

                            if (Output1 == r2 && Output2 == r3)
                            {
                                Console.WriteLine(" COMPLETELY succeed");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice!");
                                return;
                            }
                            srOut.ReadLine();
                            sw.WriteLine();
                        }

                        srOut.Close();
                        sr.Close();
                        sw.Close();
                        long y3 = System.Environment.TickCount;
                        long time3 = (y3 - x3) * 1000;

                        Console.WriteLine("Time =" + time3);
                        Console.WriteLine("Sample cases are COMPLETELY succeed");
                        Console.WriteLine("\n");
                        break;
                    case '5':
                        sr = new StreamReader("SampleRSA.txt");
                        srOut = new StreamReader("SampleRSA_Output.txt");
                        sw = new StreamWriter(@"MyRun/DivisionTestCases.txt");
                        long x4 = System.Environment.TickCount;
                        int nCases5 = int.Parse(sr.ReadLine());
                        for (int i = 0; i < nCases5; i++)
                        {
                       
                            string FirstNum = sr.ReadLine();
                            string SecandNum = sr.ReadLine();
                            string thirNum = sr.ReadLine();
                            sr.ReadLine();
                            string Output1 = srOut.ReadLine();

                            Console.Write("Case " + (i + 1).ToString() + ": ");
                            Hnum num1 = new Hnum(FirstNum);
                            Hnum num2 = new Hnum(SecandNum);
                            Hnum num3 = new Hnum(thirNum);
                            Hnum res= new Hnum();
                            
                         
                            res = HugeNum.ModOfPoewer(num3, num2, num1);
                            string r2 =res.getnum().ToString();
                            Console.WriteLine(Output1);
                            Console.WriteLine(r2);

                            sw.WriteLine(r2);
                          


                            if (Output1 == r2 )
                            {
                                Console.WriteLine(" COMPLETELY succeed");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice!");
                                
                            }
                        
                            sw.WriteLine();
                        }

                        srOut.Close();
                        sr.Close();
                        sw.Close();
                        long y4 = System.Environment.TickCount;
                        long time4 = (y4 - x4) * 1000;

                        Console.WriteLine("Time =" + time4);
                        Console.WriteLine("Sample cases are COMPLETELY succeed");
                        Console.WriteLine("\n");
                        break;
                    default:
                        Console.WriteLine("Please choies the correct choies");
                        break;
                }
            }
            #endregion
        }
    }
}
