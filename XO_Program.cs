using System;
using System.Threading;
namespace OX
{  
    class XO_Program
    {
 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Main()
        {
            int lg = 0; string xo = "X";
            int ff = 0, win = 0;
            string[] actor = { "Player", "Computer" };
            string[] b = { "_", "_", "_", "_", "_", "_", "_", "_", "_", "_",};
            XO_Program pr = new XO_Program(); 
            Console.WriteLine("Tic Tac Toe!!! ");
            Console.WriteLine("Start Game(Press 1):  ");
            String response = Console.ReadLine();
            if (response == "1")
            {
                Console.Clear();
                actor[1] = "Computer";
                pr.run(b,actor, lg, ff,xo,response,win);
            }else{
				Console.WriteLine("Bye!!!"); 
				System.Environment.Exit(1); 
			}
            Console.ReadKey();
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void run(string[] b,string[] g,int lg,int ff,string xo,string response,int win ) 
        {   int a1 = 0; 
            String placeHolder ; 
			XO_Program pr = new XO_Program();
            Console.Clear();
			if(lg == 0){Console.WriteLine("Your Turn!");}
			else{Console.WriteLine("Let opponent choose!");}			
            Console.WriteLine("-------["+b[1]+ "]-------[" + b[2] + "]-------[" + b[3] + "]-------");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-------[" + b[4] + "]-------[" + b[5] + "]-------[" + b[6] + "]-------");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-------[" + b[7] + "]-------[" + b[8] + "]-------[" + b[9] + "]-------");
            if (win == 1) { Thread.Sleep(2000); System.Environment.Exit(1); }
            Console.WriteLine("Enter a place from 1 to 9: ");
            Console.WriteLine("You are: "+ xo);
            if (response == "1" && xo == "O")
            {
                pr.bot(b, g, lg, ff, xo, response, win);
            }
            else {
                placeHolder = Console.ReadLine(); 
                a1 = Int32.Parse(placeHolder);
                pr.wp(b, g, lg, ff, xo, response, win,a1);
                 }              
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void runLogic(string[] b, string[] g, int lg, int ff, string xo, string response, int win) 
        {
                XO_Program pr = new XO_Program();
                int f1 = 1, f2 = 2, f3 = 3, spot = 0; string[] c = { "X", "O" };
                for (int s = 0; s < 2; s++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (b[f1] == c[spot] && b[f2] == c[spot] && b[f3] == c[spot]) 
                        {
                            b[f1] = "."; b[f2] = "."; b[f3] = ".";
                            Console.WriteLine(g[spot] + " WON!!!");
                            Thread.Sleep(2000);
                            win = 1;
                            pr.runLogic(b, g, lg, ff, xo, response, win);
                        }
                        f1 += 3; f2 += 3; f3 += 3;
                    }
                    f1 = 1; f2 = 2; f3 = 3;
                    spot = 1;
                }
                f1 = 1; f2 = 4; ; f3 = 7; spot = 0;
                for (int s = 0; s < 2; s++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (b[f1] == c[spot] && b[f2] == c[spot] && b[f3] == c[spot]) 
                    {
                            b[f1] = "."; b[f2] = "."; b[f3] = ".";
                            Console.WriteLine(g[spot] + " WON!!!");
                            Thread.Sleep(2000);
                            win = 1;
                            pr.runLogic(b, g, lg, ff, xo, response, win);
                        }
                        f1 += 1; f2 += 1; f3 += 1;
                    }
                    f1 = 1; f2 = 4; f3 = 7;
                    spot = 1;
                }
                f1 = 1; f2 = 5; ; f3 = 9; spot = 0;
                for (int s = 0; s < 2; s++)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (b[f1] == c[spot] && b[f2] == c[spot] && b[f3] == c[spot])  
                        {
                            b[f1] = "."; b[f2] = "."; b[f3] = ".";
                            Console.WriteLine(g[spot] + " WON!!!");
                            Thread.Sleep(2000);
                            win = 1;
                            pr.runLogic(b, g, lg, ff, xo, response, win);
                        }
                        f1 = 3; f2 = 5; f3 = 7;
                    }
                    f1 = 1; f2 = 4; f3 = 9;
                    spot = 1;
                }       
            pr.run(b, g, lg, ff, xo, response, win);
        }
 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public  void bot(string[] b, string[] g, int lg, int ff, string xo, string response, int win) 
        {
            XO_Program pr = new XO_Program();
            int a1 = 0;
            Random rnd = new Random();
            int ck = rnd.Next(1, 9);
            Console.WriteLine("Computer's Turn:");
            Thread.Sleep(1000);
            Console.WriteLine(ck);
            Thread.Sleep(500);
            a1 = ck;
            pr.wp(b, g, lg, ff, xo, response, win,a1);
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void wp(string[] b, string[] g, int lg, int ff, string xo, string response, int win,int a1) 
        {   XO_Program pr = new XO_Program();
            for (int i = 1; i < 10; i++)
            {
                if (i == a1)
                {
                    if (b[i] == "_")
                    {
                        if (xo == "o" || xo == "O")
                        {
                            b[i] = "O";
                            xo = "X";
                        }
                        else
                        {
                            b[i] = "X";
                            xo = "O";
                        }
                        if (lg == 0)
                        {
                            lg++;
                        }
                        else lg--;
                        ff++;
                    }
                    else
                    {
                        Console.WriteLine("Already Filled Choose something else");
                        Thread.Sleep(2000);
                        break;
                    }
                }
            }
            if (ff >= 3)
                pr.runLogic(b, g, lg, ff, xo, response, win);
            else pr.run(b, g, lg, ff, xo, response, win);
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }  
}
