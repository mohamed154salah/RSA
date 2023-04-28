using System;
using System.Collections.Generic;
using System.Text;

namespace RSA_project
{
    /// <summary>
    /// <description>  this class repersent the huge number lager than int and long </description>
    /// </summary>
    class Hnum
    {
        private StringBuilder num;
        public StringBuilder getnum() { return num; }

        public int getlength() { return num.Length; }
        public void setnum(StringBuilder value) { num = value; }

        public Hnum(string num)
        {
            this.num =new StringBuilder(num);
        }
        public Hnum(StringBuilder num)
        {
            this.num = num;
        }
        public Hnum()
        {
            this.num = new StringBuilder();
        }
    }
    class HugeNum
    {
        /// <summary>
        /// add two huge number
        /// </summary>
        /// <param name="num1">very larg number define in class </param>
        /// <param name="num2">other very larg number define in class</param>
        /// <returns>The sumation of 2 numbers</returns>
        public static Hnum addition(Hnum num1, Hnum num2)
        {
            StringBuilder total = new StringBuilder();
            /*if (num1.Length >= num2.Length)
            {
                loop = num1;
            }
            else
                loop = num2;*/
            int a = 0;
            int t = 0;
            // bool z= false;

            for (int i = num1.getlength() - 1, j = num2.getlength() - 1; i >= 0 && j >= 0; i--, j--)
            {
                t = 0;
                if ((int)num1.getnum()[i] - '0' + (int)num2.getnum()[j] - '0' + a >= 10)
                {

                    t = (int)num1.getnum()[i] - '0' + (int)num2.getnum()[j] - '0' + a - 10;
                    total.Append((char)((char)t + '0'));
                    //Console.WriteLine(t);
                    // Console.WriteLine(a);
                    a = 1;
                }
                else
                {

                    t = (int)num1.getnum()[i] - '0' + (int)num2.getnum()[j] - '0' + a;
                    //Console.WriteLine(t);
                    total.Append((char)((char)t + '0'));
                    //Console.WriteLine(2);
                    a = 0;
                }
            }
            t = 0;
            if (num1.getlength() == num2.getlength())
            {
                if (a == 1) total.Append('1');
            }
            else 
            {
               int length=Math.Abs( num1.getlength() - num2.getlength());
                bool num2isg = true;
                if (num1.getlength() >num2.getlength())
                {
                    num2isg = false;
                }
                for (int i =length- 1; i >= 0; i--)
                {
                    if (a == 1)
                    {
                        if (!num2isg)
                            t = (int)num1.getnum()[i] - '0' + a;
                        else
                            t = (int)num2.getnum()[i] - '0' + a;
                        total .Append( (char)((char)t + '0'));

                        a = 0;
                    }
                    else
                    {
                        if(!num2isg)
                             t = (int)num1.getnum()[i] - '0';
                        else
                            t = (int)num2.getnum()[i] - '0';
                        total .Append((char)((char)t + '0'));
                    }
                }
            }
           
            StringBuilder tot =new StringBuilder();
            for (int i = total.Length - 1; i >= 0; i--)
            {
                tot .Append(total[i]);

            }
            
            Hnum totalnum = new Hnum(tot);
            return totalnum;
        }
        /// <summary>
        /// Subtract two huge number
        /// </summary>
        /// <param name="num1"> First very larg number define in class </param>
        /// <param name="num2">Secand very larg number define in class</param>
        /// <returns>The Subtraction of 2 numbers</returns>
        public static Hnum Subtract(Hnum num1, Hnum num2)
        {
            StringBuilder total = new StringBuilder();

            /*if (num1.Length >= num2.Length)
            {
                loop = num1;
            }
            else
                loop = num2;*/
            int t = 0;
            // bool z= false;


            if (IsGreater(num2,num1))
            {
                StringBuilder temp = num1.getnum();
                num1 = num2;
                num2.setnum(temp);
            }

            bool z = false;
            for (int i = num1.getlength() - 1, j = num2.getlength() - 1; i >= 0 && j >= 0; i--, j--)
            {
                t = ((int)num1.getnum()[i] - '0') - ((int)num2.getnum()[j] - '0');
                if (t < 0)
                {
                    if (z == false)
                    {
                        z = true;
                        t += 10;
                    }
                    else
                    {
                        t += 9;
                    }
                }
                else if (t > 0)
                {
                    if (z == true)
                    {
                        z = false;
                        t--;
                    }
                }
                else if (t == 0)
                {
                    if (z == true)
                    {
                        t += 9;
                    }
                }
                total .Append( (char)((char)t + '0'));
            }

            if (num1.getlength() > num2.getlength())
            {
                for (int i = num1.getlength() - num2.getlength() - 1; i >= 0; i--)
                {
                    t = (int)num1.getnum()[i] - '0';
                    if (z == true)
                    {
                        z = false;
                        t--;
                    }
                    total .Append( (char)((char)t + '0'));
                }
            }
           StringBuilder tot =new StringBuilder();
            bool zf = true;
            for (int i = total.Length - 1; i >= 0; i--)
            {
                if (total[i] == '0' && zf)
                {
                    continue;
                }
                else
                {
                    tot .Append(total[i]);
                    zf = false;
                }


            }
            if (zf)
            {
                tot.Append(0);
            }
            Hnum h = new Hnum(tot);

            return h;
        }
        /// <summary>
        /// Multiply two huge number
        /// </summary>
        /// <param name="num1">very larg number define in class </param>
        /// <param name="num2">other very larg number define in class</param>
        /// <returns>The Multiplication Resulat of 2 numbers</returns>
        public static Hnum Multiply(Hnum num1, Hnum num2)
        {
            int size1 = num1.getlength();
            int size2 = num2.getlength();

            int N = Math.Max(size1, size2);
            if (N % 2 == 1 && N > 2)
            {

                N++;

            }

            int subst = N - num1.getlength();
                num1.setnum(num1.getnum().Insert(0, "0",subst)); /// O(N)
            int subst2 = N - num2.getlength();
                num2.setnum(num2.getnum().Insert(0, "0",subst2));


            if (N == 1)
            {
                return (new Hnum(Convert.ToString(((int)num1.getnum()[0] - '0') * ((int)num2.getnum()[0] - '0'))));
            }

            //A
            

            string X1 = num1.getnum().ToString(0, N / 2);

            //B
            string X2 = num1.getnum().ToString(N / 2, N / 2);



            //c
            string Y1 = num2.getnum().ToString(0,N/2);
           

            string Y2 = num2.getnum().ToString(N / 2, N / 2);

            //d
            Hnum z0 = Multiply(new Hnum(X1), new Hnum(Y1));
            Hnum z1 = Multiply(new Hnum(X2), new Hnum(Y2));

            Hnum z2 = Multiply(addition(new Hnum(X2), new Hnum(X1)), addition(new Hnum(Y1), new Hnum(Y2)));

            Hnum sub1 = Subtract(z2, z1);
            Hnum thir = Subtract(sub1, z0);

            //  double fir = Math.Pow(10, N );
            //     Hnum sec = Multiply(new Hnum(Convert.ToString(fir)), z1);
                z0.getnum().Append( '0',N);
            //  long m = (long)Math.Pow(10, N/2);
            //Hnum fiv = Multiply(four, new Hnum(Convert.ToString(m)));
            thir.getnum().Append('0', N/2);
          

            Hnum fin2 = addition(addition(z0,thir ), z1);
            // result = ((long)Math.Pow(10, N * 2) * z0) + z1 + ((z2 - z1 - z0) * m);

            Hnum finalRes =new Hnum();
            bool zf = true;
            for (int i = 0; i < fin2.getlength(); i++)
            {
                if (fin2.getnum()[i] == '0' && zf)
                {
                    continue;
                }
                else
                {
                   finalRes.getnum().Append(fin2.getnum()[i]);
                    zf = false;
                }
            }
            if (zf)
            {
                finalRes.getnum().Append(0);
            }

            return finalRes;

        }
        /// <summary>
        /// Division two huge number
        /// </summary>
        /// <param name="num1">very larg number define in class </param>
        /// <param name="num2">other very larg number define in class</param>
        /// <returns>The Division Resulat of 2 numbers and reminder of the division </returns>
        public static  Hnum[] Division(Hnum num1, Hnum num2)
        {
            Hnum []arr = new Hnum[2];
            if (IsGreater(num2,num1))
            {              
                arr[0] = new Hnum("0");
                arr[1] = num1;
                return arr;
            }

            
            arr =Division(num1,addition(num2,num2));

            arr[0] = addition(arr[0], arr[0]);

            if (IsGreater(num2, arr[1]))
            {
                return arr;
            }
            else
            {
                arr[0] = addition(arr[0],new Hnum("1"));
                arr[1] = Subtract(arr[1],num2);
                return arr;
            }

        }
        /// <summary>
        /// Division two huge number
        /// </summary>
        /// <param name="num1">very larg number define in class </param>
        /// <param name="num2">other very larg number define in class</param>
        /// <returns>The Division Resulat of 2 numbers and reminder of the division </returns>
        public static Hnum ModOfPoewer(Hnum num1, Hnum powe,Hnum mode){
            Hnum []remin;// mode of the base
            remin = Division(num1, mode);
          
            Hnum pe = Power(remin[1], powe,mode);// multiply of power
        
            Hnum[] remin2;// mode of the base
            remin2 = Division(pe, mode);

            return remin2[1];
           // return pe;
        }
        /// <summary>
        /// Division two huge number
        /// </summary>
        /// <param name="num1">very larg number define in class </param>
        /// <param name="num2">other very larg number define in class</param>
        /// <returns>The Division Resulat of 2 numbers and reminder of the division </returns>
        public static Hnum Power(Hnum num1, Hnum num2, Hnum modelr) {



            //mod = div(new big_int(b), sec);
            //mod = div(new big_int(multiply(new big_int(mod[1]), new big_int(mod[1]))), sec);
            //return mod[1];



            if (num2.getnum().Equals("1")) {

                return num1;

            }
            Hnum pow = Power(num1, Division(num2, new Hnum("2"))[0],modelr);
            StringBuilder h = Division(num2, new Hnum("2"))[1].getnum();
            if (h.Equals("0")) {

                return Division( Multiply(pow, pow),modelr)[1];
            }
            else
            {
                return Division(Multiply(num1,Division(Multiply(pow, pow),modelr)[1]),modelr)[1];
            }
            
        }
            /// <summary>
            /// compare two huge number 
            /// </summary>
            /// <param name="num1">very larg number define in class </param>
            /// <param name="num2">other very larg number define in class</param>
            /// <returns>true if first num greater than secand</returns>
        public static bool IsGreater(Hnum num1, Hnum num2) {
            if (num2.getlength() > num1.getlength())
                return false;

            else if (num1.getlength() > num2.getlength())
                return true;
            else
                for (int i = 0; i < num1.getlength(); i++)
                {
                    if ((int)num1.getnum()[i]< (int)num2.getnum()[i])
                    {
                        return false;
                    }
                    else if ((int)num1.getnum()[i] > (int)num2.getnum()[i])
                    {
                        return true;
                    }
                }
            return false;
                
            ///1254
            ///1254
            ///1554
            ///5444
            ///
            ///
            ///
            ///
            ///
            ///
        }

    }
}

