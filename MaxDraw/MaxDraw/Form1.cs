using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Globalization;

namespace MaxDraw
{
    public partial class MaxDraw : Form
    {

        Graphics g;
        Font font = new Font("Arial",10);
        float[] wartosci = new float[1000]; // wartosci
        float[] argumenty = new float[1000]; //argumenty

        Pen wsp = new Pen(new SolidBrush(Color.Black)); //pen dla skali
        Pen mesh = new Pen(Color.LightGray);
        Pen od = new Pen(Color.Black, 3);
        Pen wyk = new Pen(new SolidBrush(Color.Blue),2);

        
        float first_x; //pierwszy punkt
        float range_x; // cały zakres jesli ppierwszy punkt plus to
        float step_x; // skok co
        int point_number; //ilość punktów 
        float max_y; //maksymalna warosc
        float max_x; // argument dla wartosci maksymalnej

        string a;
        public MaxDraw()
        {
            InitializeComponent();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

             Siatka();

    
        }

        private void Siatka()
        {
            g = PanelG.CreateGraphics();
           
          

            //tworzymy linie przerywaną
            float[] dash = { 2, 2 };
           
            mesh.DashPattern = dash;


            //zmiana układu współrzędnych macierzami
            Matrix Mat = new Matrix(1, 0, 0, -1, 0, 0);
            g.Transform = Mat;
            g.TranslateTransform(50, 550, MatrixOrder.Append);

            //skala kreski i siatka//
            for (int i = 0; i <= 1000; i += 10) //pozioma
            {
                //siatka
                g.DrawLine(mesh, new Point(i, 10), new Point(i, 490));

                //kreska 
                g.DrawLine(wsp, new Point(i, 0), new Point(i, 10));//góra 
                g.DrawLine(wsp, new Point(i, 500), new Point(i, 490));//dół

                //punkty odniesienia
                g.DrawLine(od, new Point(i * 10, 0), new Point(i * 10, 15));//góra 
                g.DrawLine(od, new Point(i * 10, 500), new Point(i * 10, 485));//dół

                

            }
            for (int i = 0; i <= 500; i += 10)//pionowa
            {
                //siatka
                g.DrawLine(mesh, new Point(10, i), new Point(990, i));

                //Kreska
                g.DrawLine(wsp, new Point(0, i), new Point(10, i));//lewo
                g.DrawLine(wsp, new Point(990, i), new Point(1000, i));//prawo

                //punkty odniesienia
                g.DrawLine(od, new Point(0, i * 10), new Point(15, i * 10)); //lewo
                g.DrawLine(od, new Point(985, i * 10), new Point(1000, i * 10));//prawo

            }
            //ramka
            g.DrawLine(wsp, new Point(0, 0), new Point(0, 500));
            g.DrawLine(wsp, new Point(1000, 0), new Point(1000, 500));
            g.DrawLine(wsp, new Point(0, 0), new Point(1000, 0));
            g.DrawLine(wsp, new Point(0, 500), new Point(1000, 500));

            g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void wczytajToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //wczytywanie pliku z danymi
            OpenFileDialog plik = new OpenFileDialog();
            string[] s;
            int i = 0;
            int x = 0;
             
            string first;
            string range;
            string step;
            string points;


            if (plik.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(plik.FileName);
                s = File.ReadAllLines(plik.FileName);
                

                char[] przechowywyjąca = new char[25]; //tablice przechujące wartości
                char[] cała = new char[25];

                //wczytywanie pierwszego punktu                
                cała = s[15].ToCharArray();
                while (i < 20 )
                {
                    if (char.IsNumber(cała[i]) || cała[i] == '.') // zrobione tylko pamiętaj pokręcone musisz wychodzić z pętli breakiem pamiętaj o konwertacji globalize!!
                    {
                        while(x<=10)
                        {
                            przechowywyjąca[x] = cała[i];
                            break;
                        } 
                        i++;
                        x++;
                    }
                    else
                    {
                        i++;
                    }
                   
                }
                first = new string(przechowywyjąca);
                first_x = float.Parse(first, CultureInfo.InvariantCulture);// zmiana kropki na przecinek;

                //kasowanie tablicy 
                for(int b = 0; b <=8; b++)
                {
                    cała[b] = '0';
                    przechowywyjąca[b] = '0';
                }
                
                //wczytanie cały range
               i = 0;
               x = 0;
                cała = s[16].ToCharArray();
                while (i< 18)
                {
                    if (char.IsNumber(cała[i]) || cała[i] == '.')
                    {
                        while (x < 8)
                        {
                            przechowywyjąca[x] = cała[i];
                            break;
                        }
                        x++;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
                range = new string(przechowywyjąca);
                range_x = float.Parse(range, CultureInfo.InvariantCulture);// zmiana kropki na przecinek;

                
                //kasowanie tablicy 
                for (int b = 0; b <= 8; b++)
                {
                    cała[b] = '0';
                    przechowywyjąca[b] = '0';
                }
                // wczytywanie step
                i = 0;
                x = 0;
                cała = s[17].ToCharArray();
                while (i < 18)
                {
                    if (char.IsNumber(cała[i]) || cała[i] == '.')
                    {
                        while (x < 8)
                        {
                            przechowywyjąca[x] = cała[i];
                            break;
                        }
                        x++;
                        i++;
                    }
                    else
                    {
                        i++;
                    }
                }
                step = new string(przechowywyjąca); 
                step_x = float.Parse(step, CultureInfo.InvariantCulture);// zmiana kropki na przecinek;

                //kasowanie tablicy 
                for (int b = 0; b <= 10 ; b++)
                {
                    cała[b] = '0';
                }

                //wczytywanie ilości punktów

                i = 0;
                x = 0;
                cała = s[19].ToCharArray();
                while (i < 13)
                {
                    if (char.IsNumber(cała[i]))
                    {
                        while (x < 3)
                        {
                            przechowywyjąca[x] = cała[i];
                            break;
                        }
                        x++;
                        i++;
                    }
                    else if (char.IsLetter(cała[i]) || char.IsPunctuation(cała[i]) || char.IsWhiteSpace(cała[i]))
                    {
                        i++;
                    }
                    else 
                    {
                        break;
                    }
                    przechowywyjąca[3] = ',';
                }
                points = new string(przechowywyjąca); 
                float t = float.Parse(points);
                point_number = (int)t;

                //wczytywanie tablicy wartości
                for (int q = 0; q < s.Length - 21; q++)
                {
                    a = s[q + 21];
                    wartosci[q] = float.Parse(a, CultureInfo.InvariantCulture);
                }

                // szukanie najwięszej wartości
                int y = point_number;
                max_y = 0f;
               while(y!=0)
               {
                   if(wartosci[y]>=max_y)
                   {
                       max_y = wartosci[y];
                       y--;
                   }
                   else
                   {
                       y--;
                   }
               }

                //liczneie argumentów
                int z=0;
                for (y = point_number; y >= 0; y-- )
                {
                    argumenty[z] = first_x + step_x * z;
                    z++;
                }

                    //tekst box
                    richTextBox1.Text = "first point:" + first_x.ToString();
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText("range:" +range_x.ToString());
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText("step:" + step_x.ToString());
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText("points:" + point_number.ToString() );
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText("wartości:" + wartosci[0].ToString() );
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText("najwieksza wartosc:" + max_y.ToString());


                

            


                
            }
   
        }

        private void rysowanie(float first_x, float  range_x, float step_x, float[] tab, int point_number)
        {
            

            g.Clear(Color.White);
            //ramka
            g.DrawLine(wsp, new Point(0, 0), new Point(0, 500));
            g.DrawLine(wsp, new Point(1000, 0), new Point(1000, 500));
            g.DrawLine(wsp, new Point(0, 0), new Point(1000, 0));
            g.DrawLine(wsp, new Point(0, 500), new Point(1000, 500));


           

            float a=0f;
            float argumenty_x = 0f;
            float wartosci_y = 0f;
            int c=0;//tablicujacy punkty i linie
            int v = 0; //tablicujący siatke
            float skalar_x = 1000F / point_number; //skalar argumentów
            float skalar_y = max_y / 450F; // skalar wartosci
            


                for (int i = point_number; i > 0; i--)
                {
                    //punkty i linia wykresu
                    SizeF siz = new SizeF(3,-3);
                    PointF first = new PointF(a, wartosci[c] / skalar_y);
                    PointF second = new PointF(a +=skalar_x, wartosci[c + 1] /skalar_y);
                    RectangleF p = new RectangleF(first,siz);
                    g.FillEllipse(new SolidBrush(Color.Red), p);
                    g.DrawLine(wyk, first, second);
                    //siatka
                    while(argumenty_x<=990) //skalowanie siatki
                    {
                        if (point_number > 200)
                        {
                            g.DrawLine(mesh, new PointF(argumenty_x += skalar_x * 20, 0), new PointF(argumenty_x, 500));
                            g.DrawLine(od, new PointF(argumenty_x, 0), new PointF(argumenty_x, 15));
                        }
                        else if (point_number <= 150)
                        {
                            g.DrawLine(mesh, new PointF(argumenty_x += skalar_x*10, 0), new PointF(argumenty_x, 500));
                            g.DrawLine(od, new PointF(argumenty_x, 0), new PointF(argumenty_x, 15));
                          
                        }

 
                    }
                    while(wartosci_y<=490)
                    {
                       if(skalar_y>1)
                       {
                           g.DrawLine(mesh, new PointF(0, wartosci_y += wartosci[v] / skalar_y * 500), new PointF(1000, wartosci_y));
                           g.DrawLine(od, new PointF(0, wartosci_y), new PointF(15, wartosci_y));
                       }
                        if(skalar_y<1)
                        {
                            g.DrawLine(mesh, new PointF(0, wartosci_y += wartosci[v] / skalar_y*20), new PointF(1000, wartosci_y));
                            g.DrawLine(od, new PointF(0, wartosci_y), new PointF(15, wartosci_y));
                        }
                        
                    }
                    v++;
                    c++;

                    
                }
                g.SmoothingMode = SmoothingMode.AntiAlias;
                

                
                   

        }

        private void Draw_Click(object sender, EventArgs e)
        {
            rysowanie(first_x, range_x, step_x, wartosci, point_number);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Siatka();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float[] dash = { 4, 4 };
           Pen penmax =  new Pen(Color.Green, 2);
           penmax.DashPattern = dash;

            int a=0;
            float b = 0f;
            float skalar_y = max_y / 450F;
            float skalar_x = 1000F / point_number;

           while(a<=point_number)
           {
               
               if(max_y == wartosci[a])
               {
                   //linie pomocnicze
                   g.DrawLine(penmax, new PointF(b, wartosci[a]/skalar_y), new PointF(b, 0));
                   g.DrawLine(penmax, new PointF(0, wartosci[a] / skalar_y), new PointF(b, wartosci[a] / skalar_y));
                   // liczby
                  
                   Matrix mat2 = new Matrix(1, 0, 0, 1, 0, 0);
                   g.Transform = mat2;

                   
                   g.TranslateTransform(50, 550, MatrixOrder.Append);
                   g.DrawString(argumenty[a].ToString(), font, new SolidBrush(Color.Black), new PointF(b, 10f));
                   g.DrawString(wartosci[a].ToString(), font, new SolidBrush(Color.Black), new PointF(0f+10, -(wartosci[a] / skalar_y)));
                   max_x = b;
                   break;
               }
                b += skalar_x;
               a++;
               
               
           }
           g.SmoothingMode = SmoothingMode.AntiAlias;

        }

        private void szer_pol_Click(object sender, EventArgs e)
        {
            //napisać szerokość;
            //poprowadzić linia na długości
            //wygładzanie
            /*int a =0;
            int b = 0;
            point_number = point_number * 2;
            for (int i = point_number; i >0;i-- )
            {
                wartosci[a] = (wartosci[a] + wartosci[a + 1]) / 2;
                argumenty[a] = (argumenty[b] + argumenty[b + 1]) / 2;
                b++;
                a++;
            }
                */

            int a =0;
            int index_max = 0;
            int index_mniejszy_prawa = 0;
            int index_mniejszy_lewa = 0;
            int index_wiekszy_lewa = 0;
            int index_wiekszy_prawa = 0;

            float wartosc_mniejsza_lewa = 0f;
            float wartosc_wieksza_lewa = 0f;
            float wartosc_mniejsza_prawa = 0f;
            float wartosc_wieksza_prawa = 0f;

            float pol = max_y/2f;
            decimal dec_pol = Math.Round((decimal)pol, 0);
            pol = (float)dec_pol;
            float szuk = 0f;
            float szuk_lewa = 0f;
            float szuk_prawa =0f;
            while (a <= point_number)
           {
               if (max_y == wartosci[a])
               {
                   index_max = a;
                   break;
               }
               a++;

           }
            
           // while(pol == szuk)
            //{
                for(int b = a; b >= 0 ; b-- )//sprawdzanie lewej strony
                {
                    if( wartosci[b]>pol && wartosci[b-1]<pol) //lewa strona
                    {
                        wartosc_wieksza_lewa = wartosci[b];
                        wartosc_mniejsza_lewa = wartosci[b - 1];
                        index_mniejszy_lewa = b - 1;
                        index_wiekszy_lewa = b;
                    }
                    
                }
                for( int c = a; c<= point_number; c++) //prawa strona
                {
                    if(wartosci[c]> pol && wartosci[c+1]<pol)
                    {
                        wartosc_wieksza_prawa = wartosci[c];
                        wartosc_mniejsza_prawa = wartosci[c + 1];
                        index_mniejszy_prawa = c;
                        index_wiekszy_prawa = c + 1;
                    }

                }
                // szukanie najbliższej wartosci max/2 i odszukanie skalaru tej wartosci;
                // ok wartosc 1.15;
            
                // szukanie skalaru lewej strony;
           /* szuk_lewa =  wartosc_wieksza_lewa;
           float skal = 1f;
            while (szuk_lewa != pol)
            { 
                if(szuk_lewa < pol)
                {
                    szuk_lewa *= skal;
                }
                if(szuk_lewa > pol)
                {
                    szuk_lewa /= skal;
                }
                skal += 0.1f;
                decimal dec_szuk = Math.Round((decimal)szuk_lewa, 0);
                szuk_lewa =(float)dec_szuk;
            }*/
         

                
            
            richTextBox1.Text = "index max = " + index_max.ToString();
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("wartosc_wieksza_lewa: " + wartosc_wieksza_lewa.ToString());
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("wartosc_mniejsza_lewa: " + wartosc_mniejsza_lewa.ToString());
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("wartosc_wieksza_prawa: " + wartosc_wieksza_prawa.ToString());
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("wartosc_mniejsza_prawa: " + wartosc_mniejsza_prawa.ToString());
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("szu klewa = " + szuk_lewa.ToString());
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("max_y/2 = " + pol.ToString());

            
            
        }
        
    }
}
