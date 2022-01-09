using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriYapılarıFinal_1Proje
{
    public partial class Form1 : Form
    {
 
        public Form1()
        {
            InitializeComponent();
        }

        public class Node
        {
            public String processName;
            public Node next;

            public Node(String processName)
            {
                this.processName = processName;
            }
        }

        Random rnd = new Random();

        Node process1Ilk = null;
        Node process1Son = null;
        Node stackIlk1 = null;

        Node process2Ilk = null;
        Node process2Son = null;
        Node stackIlk2 = null;

        Node process3Ilk = null;
        Node process3Son = null;
        Node stackIlk3 = null;

        Node islemciKuyrukIlk = null;
        Node islemciKuyrukSon = null;

       

        private void btnStartProcess_Click(object sender, EventArgs e)
        {
            tmrIslemci.Enabled = true;
          

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public void listeYazdir(RichTextBox richTextBox, Node whatProceesIlk)
        {
            richTextBox.Text = null;
            Node gecici = whatProceesIlk;

            while(gecici != null)
            {
                if(richTextBox == rchTxtProcessKuyrugu)
                {
                    richTextBox.Text += gecici.processName + "=>";
                }
                else
                {
                    richTextBox.Text += gecici.processName + "\n";
                }
               

                gecici = gecici.next;
            }
        }

        private void trkBarProcess1_Scroll(object sender, EventArgs e)
        {
            
                trkBarAyar(trkBarProcess1, tmrProcess1);
            
        
           

        }

        private void trkBarProcess2_Scroll(object sender, EventArgs e)
        {
            trkBarAyar(trkBarProcess2, tmrProcess2);
  
        }

        private void trkBarProcess3_Scroll(object sender, EventArgs e)
        {
            trkBarAyar(trkBarProcess3, tmrProcess3);
   
        }

        private void trkBarIslemci_Scroll(object sender, EventArgs e)
        {
            trkBarAyar(trkBarIslemci, tmrIslemci);
        }

        public void trkBarAyar(TrackBar trkBar, Timer timer )
        {
            int hızAyarValue = trkBar.Value;


            switch (hızAyarValue)
            {
              
                case 1:
                    timer.Interval = 2000;
                    break;
                case 2:
                    timer.Interval = 1000;
                    break;
                case 3:
                    timer.Interval = 600;
                    break;
                case 4:
                    timer.Interval = 300;
                    break;
                case 5:
                    timer.Interval = 200;
                    break;
                
                default:
                    timer.Interval = 2000;
                    break;
            }
        }



        private void tmrProcess2_Tick(object sender, EventArgs e)
        {
            String processIsim = "P 2-" + Convert.ToString(rnd.Next(0, 6));

            Node yeni = new Node(processIsim);

            yeni.next = null;
            if (process2Ilk == null)
            {
                process2Ilk = yeni;
                process2Son = yeni;
            }
            else
            {
                process2Son.next = yeni;
                process2Son = yeni;
            }


            listeYazdir(rchTxtProcess2, process2Ilk);
        }

        private void tmrProcess1_Tick(object sender, EventArgs e)
        {

            String processisim = "P 1-" + Convert.ToString(rnd.Next(0, 6));

            Node yeni = new Node(processisim);

            yeni.next = null;
            if (process1Ilk == null)
            {
                process1Ilk = yeni;
                process1Son = yeni;
            }
            else
            {
                process1Son.next = yeni;
                process1Son = yeni;
            }

            listeYazdir(rchTxtProcess1, process1Ilk);

        }

        private void tmrProcess3_Tick(object sender, EventArgs e)
        {
            String processIsim = "P 3-" + Convert.ToString(rnd.Next(0, 6));

            Node yeni = new Node(processIsim);
            yeni.next = null;
            if (process3Ilk == null)
            {
               
                process3Ilk = yeni;
                process3Son = yeni;
            }
            else
            {
                process3Son.next = yeni;
                process3Son = yeni;

            }

            listeYazdir(rchTxtProcess3, process3Ilk);
        }

        private void tmrIslemci_Tick(object sender, EventArgs e)
        {
            islemcikuyrugundanCikar();
            int process1;
            int process2;
            int process3;

          
            String pro1Name = "";
            String pro2Name = "";
            String pro3Name = "";
            if (process1Ilk != null && process3Ilk != null && process2Ilk != null)
            {
               process1 = Convert.ToInt32((process1Ilk.processName.Split("-"))[1]);
                process2 = Convert.ToInt32((process2Ilk.processName.Split("-"))[1]);
                process3 =Convert.ToInt32( (process3Ilk.processName.Split("-"))[1]);

                pro1Name = process1Ilk.processName;
                pro2Name = process2Ilk.processName;
                pro3Name = process3Ilk.processName;
                
                if (process1 > process2 && process1 > process3)
                {                    
               
                    islemciKuyrugaEkle(pro1Name);
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro3Name);

                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);

                }
                else if(process3 > process1 && process3 > process2)
                {
                    
                    islemciKuyrugaEkle(pro3Name);
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro1Name);
                   
                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);

                }
                else if (process2 > process1 && process2 > process3)
                {
                  
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro1Name);
                    islemciKuyrugaEkle(pro3Name);

                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);

                }
                else if(process1 ==process2 && process1 > process3)
                {
                    
                    islemciKuyrugaEkle(pro1Name);
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro3Name);

                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                }
                else if (process1 == process3 && process1 > process2)
                {
                    islemciKuyrugaEkle(pro1Name);
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro3Name);

                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                }
                else if (process2 == process3 && process2 > process1)
                {
                  
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro3Name);
                    islemciKuyrugaEkle(pro1Name);

                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                   
                }
                else if(process2 == process1 && process2 > process3)
                {
                   
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro3Name);
                    islemciKuyrugaEkle(pro1Name);

                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);

                }
                else if(process3 == process1 && process3 > process2)
                {
                   
                    islemciKuyrugaEkle(pro3Name);
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro1Name);

                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);

                }
                else if(process3 == process2 && process3 > process1)
                {
                    islemciKuyrugaEkle(pro3Name);
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro1Name);

                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                }
                else if (process1 == process2 && process1 == process3)
                {
                
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro1Name);
                    islemciKuyrugaEkle(pro3Name);


                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                }
            }else if(process1Ilk == null && process2Ilk!=null && process3Ilk!=null)
            {
                process2 = Convert.ToInt32((process2Ilk.processName.Split("-"))[1]);
                process3 = Convert.ToInt32((process3Ilk.processName.Split("-"))[1]);

                if (process2 > process3)
                {
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro3Name);

                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                }
                else if (process2 == process3)
                {
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro3Name);

                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                }
                else
                {
                    islemciKuyrugaEkle(pro3Name);
                    islemciKuyrugaEkle(pro2Name);
                  

                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                }
            }
            else if (process1Ilk != null && process2Ilk == null && process3Ilk != null)
            {
                process1 = Convert.ToInt32((process1Ilk.processName.Split("-"))[1]);
                process3 = Convert.ToInt32((process3Ilk.processName.Split("-"))[1]);

                if (process1 > process3)
                {

                    islemciKuyrugaEkle(pro1Name);
                    islemciKuyrugaEkle(pro3Name);
                   
                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                }
                else if (process1 == process3)
                {
                    islemciKuyrugaEkle(pro1Name);
                    islemciKuyrugaEkle(pro3Name);

                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                }
                else
                {
                    islemciKuyrugaEkle(pro3Name);
                    islemciKuyrugaEkle(pro1Name);
                   

                    stackEkle(ref stackIlk3, pro3Name, process3Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                }
            }
            else if (process1Ilk != null && process2Ilk != null && process3Ilk == null)
            {
                process1 = Convert.ToInt32((process1Ilk.processName.Split("-"))[1]);
                process2 = Convert.ToInt32((process2Ilk.processName.Split("-"))[1]);

                if (process1 > process2)
                {
                    islemciKuyrugaEkle(pro1Name);
                    islemciKuyrugaEkle(pro2Name);
         
                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                }
                else if (process1 == process2)
                {
                    islemciKuyrugaEkle(pro1Name);
                    islemciKuyrugaEkle(pro2Name);

                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                }
                else
                {
                    islemciKuyrugaEkle(pro2Name);
                    islemciKuyrugaEkle(pro1Name);
                   

                    stackEkle(ref stackIlk2, pro2Name, process2Ilk);
                    stackEkle(ref stackIlk1, pro1Name, process1Ilk);
                }
            }
            else if (process1Ilk == null && process2Ilk == null && process3Ilk != null)
            {
                islemciKuyrugaEkle(pro3Name);

                stackEkle(ref stackIlk3, pro3Name, process3Ilk);
            }

           
           
        }

        public void stackEkle(ref Node stackIlkDeger, String eklenecek, Node kuyrukIlkDeger)
        {

            Node yeni = new Node(eklenecek);

            if(stackIlkDeger == null)
            {
                yeni.next = null;
                stackIlkDeger = yeni;
            }
            else
            {
                yeni.next = stackIlkDeger;
                stackIlkDeger = yeni;
            }

            kuyruktanCıkar(kuyrukIlkDeger); /* Burası prooces 1 ,2 ,3 deki islemci kuyruguna
                                             * aldığımız değerleri gecerli prooces kuyrugundan çıkarır. */

        }

        public void kuyruktanCıkar(Node kuyrukIlkdeger)
        {
            if(kuyrukIlkdeger == process1Ilk)
            {
                process1Ilk = process1Ilk.next;
                listeYazdir(rchTxtProcess1, process1Ilk);
            }else if(kuyrukIlkdeger == process2Ilk)
            {
                process2Ilk = process2Ilk.next;
                listeYazdir(rchTxtProcess2, process2Ilk);
            }
            else if(kuyrukIlkdeger == process3Ilk)
            {
                process3Ilk = process3Ilk.next;
                listeYazdir(rchTxtProcess2, process2Ilk);
            }



        }

        public void islemciKuyrugaEkle(String eklenecekIsim)
        {
            Node yeni = new Node(eklenecekIsim);

            yeni.next = null;
            if(islemciKuyrukIlk == null)
            {
                islemciKuyrukIlk = yeni;
                islemciKuyrukSon = yeni;
            }
            else
            {
                islemciKuyrukSon.next = yeni;
                islemciKuyrukSon = yeni;
            }

            listeYazdir(rchTxtProcessKuyrugu, islemciKuyrukIlk);
        }

        public void islemcikuyrugundanCikar()
        {
            Node gecici = islemciKuyrukIlk;

            while(gecici != null)
            {

                islemciKuyrukIlk = islemciKuyrukIlk.next;

                gecici = gecici.next;
                listeYazdir(rchTxtProcessKuyrugu, islemciKuyrukIlk);
            }

           

        }

        private void btnStopProcess_Click(object sender, EventArgs e)
        {
            tmrIslemci.Enabled = false;

            
        }

        private void btnShowEndedProcess_Click(object sender, EventArgs e)
        {
            bool chck1 = chkProcess1.Checked;
            bool chck2 = chkProcess2.Checked;
            bool chck3 = chkProcess3.Checked;

           

            if (chck1)
            {
                yazdırStackleri(stackIlk1, rchTxtEndedProces1);
            }
            
            if (chck2)
            {
                yazdırStackleri(stackIlk2, rchTxtEndedProcess2);
            }

            if (chck3)
            {

                yazdırStackleri(stackIlk3, rchTxtEndedProcess3);
            }
            
        }

        public void yazdırStackleri(Node stackIlk, RichTextBox rchTextBox)
        {
            rchTextBox.Text = null;
            Node gecici = stackIlk;

            while (gecici != null)
            {
                rchTextBox.Text += gecici.processName + "\n";
                gecici = gecici.next;
            }
        }
    }
}
