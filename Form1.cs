using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Pexeso
{
    public partial class Form1 : Form
    {
        enum STAV { START, HRA, JEDNA, DVE, VYHRA };
        STAV stav;
        public int Score = 0;
        public int Pokusy = 0;
        public List<MyButton> BList = new List<MyButton>();
        public class MyButton : Button
        {
            public int ID
            {
                get; set ;
            }
            public enum SET { ON, OFF };
            public SET set;
            public void Turn(Form1 form, SET set)
            {
                switch (set)
                {
                    case SET.ON:
                        this.Click += form.KartickaClick;
                        break;
                    case SET.OFF:
                        this.Click -= form.KartickaClick;
                        break;
                }
            }
            public void ChangeText(string text)
            {
                this.Text = text;
            }
        }
        public static class Selected
        {
            public static int ID;
            public static string Tag;
        }
        void Randomize()
        {
            Random rand = new Random();
            int[] numbers = Enumerable.Range(0, 36).OrderBy(x => rand.Next()).ToArray();

            for (int i = 0; i < 36; i++)
            {
                if (numbers[i] > 17)
                {
                    numbers[i] = numbers[i] % 18;
                }
                BList[i].Tag = (numbers[i] + 1).ToString();
            }
        }
        void VytvorKarticky()
        {
            int N = 6;
            int sx = ClientRectangle.Width / N;
            int sy = (ClientRectangle.Height - 50) / N;
            int ID = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MyButton b = new MyButton();
                    b.Width = sx - 1;
                    b.Height = sy - 1;
                    b.Left = i * sx;
                    b.Top = j * sy;
                    b.Text = "PEXESO";
                    b.Parent = this;
                    b.ID = ID;
                    ID++;
                    b.Click += KartickaClick;
                    BList.Add(b);
                }
            }
            Randomize();
        }
        void NastavStav(STAV novy)
        {
            switch (novy)
            {
                case STAV.START:
                    TStart.Visible = true;
                    TRestart.Visible = false;
                    LNavod.Visible = true;
                    LNavod.Text = "Návod";
                    LSkore.Visible = false;
                    LFinal.Visible = false;
                    LPokusy.Visible = false;

                    break;
                case STAV.HRA:
                    TStart.Visible = false;
                    TRestart.Visible = false;
                    LNavod.Visible = false;
                    LFinal.Visible = false;
                    LSkore.Visible = false;
                    if (stav == STAV.START)
                    {
                        VytvorKarticky();
                        LPokusy.Visible = false;
                    }
                    else
                    {
                        LPokusy.Visible = true; 
                        LPokusy.Text = "Pokusy: " + Pokusy.ToString();
                        LSkore.Visible = true;
                        LSkore.Text = "Skóre: " + Score.ToString();
                    }
                    break;
                case STAV.JEDNA:
                    TStart.Visible = false;
                    TRestart.Visible = false;
                    LNavod.Visible = false;
                    //LSkore.Visible = true;
                    
                    LFinal.Visible = false;
                    break;
                case STAV.DVE:
                    TStart.Visible = false;
                    TRestart.Visible = false;
                    LNavod.Visible = false;
                    LSkore.Visible = true;
                    LFinal.Visible = false;
                    LPokusy.Visible = true;
                    break;
                case STAV.VYHRA:
                    TStart.Visible = true;
                    TRestart.Visible = true;
                    LNavod.Visible = true;
                    LSkore.Visible = false;
                    //LFinal.Visible = true;
                    LPokusy.Visible = false;
                    //LFinal.Tag = "Skvìle! Podaøilo se vám hru dokonèit s " + Pokusy + " pokusy! Neváhejte a zaènìte novou hru!";
                    MessageBox.Show("Skvìle! Podaøilo se vám hru dokonèit s " + Pokusy + " pokusy! Neváhejte a zaènìte novou hru!");
                    break;
            }
            stav = novy;
        }

        public Form1()
        {
            InitializeComponent();
            NastavStav(STAV.START);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NastavStav(STAV.HRA);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void CompareButtons(MyButton button)
        {
            await Task.Delay(1000);
            Pokusy++;              

            if ((string)button.Tag == Selected.Tag)
            {
                this.Controls.Remove(button);
                this.Controls.Remove(BList[Selected.ID]);
                Score++;
                NastavStav(STAV.HRA);
                if (Score == 18)
                {
                    NastavStav(STAV.VYHRA);
                }
            }
            else
            {
                BList[Selected.ID].Turn(this, MyButton.SET.ON);
                BList[Selected.ID].ChangeText("PEXESO");
                button.Turn(this, MyButton.SET.ON);
                button.ChangeText("PEXESO");
                NastavStav(STAV.HRA);
            }
            for (int i = 0; i < 36; i++)
            {
                if (i != Selected.ID && i != button.ID)
                {
                    BList[i].Turn(this, MyButton.SET.ON);
                }
            }
        }
        private void KartickaClick(object sender, EventArgs e)
        {
            MyButton button = (MyButton)sender;

            if (stav == STAV.HRA)
            {
                Selected.ID = button.ID;
                Selected.Tag = (string)button.Tag;
                
                button.Turn(this, MyButton.SET.OFF);
                button.ChangeText((string)button.Tag);
                
                NastavStav(STAV.JEDNA);
            }
            else
            {
                button.Turn(this, MyButton.SET.OFF);
                button.ChangeText((string)button.Tag);

                for (int i = 0; i < 36; i++)
                {
                    if (i != Selected.ID && i != button.ID)
                    {
                        BList[i].Turn(this, MyButton.SET.OFF);
                    }
                }
                CompareButtons(button);
            }   
        }

        private void TRestart_Click(object sender, EventArgs e)
        {
            foreach (MyButton b in BList)
            {
                this.Controls.Remove(b);
            }
            BList = new List<MyButton>();
            Score = 0;
            Pokusy = 0;
            NastavStav(STAV.START);
        }
        private void LNavod_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vítejte v Pexesu! Pro zaèátek hry stisknìte tlaèítko START. Pro otoèení karty na ní kliknìte. Mùžete otoèit 2 karty po sobì, poté se karty po 1 sekundì samy otoèí. Jakmile uhádnete všechny dvojice, hra konèí a mùžete se kliknutím na tlaèítko RESTART vrátit na úvod hry a hrát znovu. Pøíjemnou zábavu!");
        }
    }
}