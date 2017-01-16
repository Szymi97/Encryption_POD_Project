using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POD_PROG2
{
    public partial class Form1 : Form
    {
        public static Random rnd;

        public static int numberOfDefPicBase; //ilosc domyslnych obrazow bazowych
        public static int numberOfDefPicMess; //ilosc domyslnych obrazow widomości

        static int iiMessage; //min 0 max dlugosc message, potrzebne do iteracji

        static Bitmap EncryptPicture; //zaszyfrowany obrazek

        public Form1()
        {
            rnd = new Random();
            numberOfDefPicBase = 10; //przy rnd +1 by losowalo z np z 1 2 3 a nie z 1 2 mimo że sa 3 obrazki
            numberOfDefPicMess = 5;
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            buttonDefPictureMessage_Click(null, null);
            buttonDefPictureBase_Click(null, null);

            textBoxDecryption = new TextBox();
            textBoxDecryption.Multiline = true;
            textBoxDecryption.Font = new Font(textBoxDecryption.Font.FontFamily,10);
            textBoxDecryption.MaxLength = 3000;
            textBoxDecryption.Dock = DockStyle.Fill;
            textBoxDecryption.ReadOnly = false;
            textBoxDecryption.Text = "";
        }

        ///////////////////////////////////////// PICTURE MESSAGE /////////////////////////////////////////
        private void buttonDefPictureMessage_Click(object sender, EventArgs e)
        {
            pictureBoxMessage.Image = new Bitmap(@"DefaultPictures\DefPicMessage" + rnd.Next(1, numberOfDefPicMess + 1) + ".bmp");
        }

        private void buttonAddPictureMessage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxMessage.Image = new Bitmap(dlg.FileName);
                }
            }
        }

        private void pictureBoxMessage_Click(object sender, EventArgs e)
        {
            buttonAddPictureMessage_Click(sender, e);
        }

        ///////////////////////////////////////// TEXT MESSAGE /////////////////////////////////////////
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxMessage.Text = "";
        }
 
        private void buttonDefText_Click(object sender, EventArgs e)
        {
            switch(rnd.Next(1,11))
            {
                case 1:
                    textBoxMessage.Text = "Zostaw diamenty w skrytce C354. Hasło: Ptaki latają kluczem. Odpowiedź: Lepiej kluczem niż zamkiem." +
                                            " Spotkajmy się jutro o 18 na tarasie VIP hotelu Pearl.";
                    break;
                case 2:
                    textBoxMessage.Text = "A co po czyjej wielkości, jak nie ma w głowie mądrości";
                    break;
                case 3:
                    textBoxMessage.Text = "Litwo! Ojczyzno moja! ty jesteś jak zdrowie. " + Environment.NewLine +
                        "Ile cię trzeba cenić, ten tylko się dowie, " + Environment.NewLine +
                        "Kto cię stracił. Dziś piękność twą w całej ozdobie " + Environment.NewLine +
                        "Widzę i opisuję, bo tęsknię po tobie. ";
                    break;
                case 4:
                    textBoxMessage.Text = "To wódka? (słabym głosem zapytała Małgorzata.(...)) " + Environment.NewLine +
                        "Na litość boską, królowo (zachrypiał) czy ośmieliłbym się nalać damie wódki? To czysty spirytus.";
                    break;
                case 5:
                    textBoxMessage.Text = "Wiesz co to jest reinkarnacja? Słyszałeś w swoim życiu taki długi wyraz? Śmieszy cię reinkarnacja " + 
                        "twoja broszka, ale to stara i mądra religia, nie dla takich matołów jak ty. To kim będziesz w kolejnym życiu zależy od tego " +
                        "jakie życie prowadziłeś do tej pory. Jedni po śmierci przyjmują postać tygrysa, sokoła albo lamparta. " + Environment.NewLine +
                        "A inni?" + Environment.NewLine +
                        "Jeżeli o ciebie chodzi, nie wróżę ci żadnych rewelacji. KACZKA to max, co może z ciebie być. ";
                    break;
                case 6:
                    textBoxMessage.Text = "May the Force be with you. And you. And you. And you. And you. And you. And you.";
                    break;
                case 7:
                    textBoxMessage.Text = "Wszyscy wielcy uczeni byli mężczyznami" + Environment.NewLine +
                        "Konkretnie, nazwiska." + Environment.NewLine +
                        "No, choć by Kopernik!!" + Environment.NewLine +
                        "Nie prawda Kopernik była kobieta" + Environment.NewLine +
                        "No to Einstein" + Environment.NewLine +
                        "Einstein tez była kobieta" + Environment.NewLine +
                        "Maria Skłodowska Curie tez?" + Environment.NewLine +
                        "To chyba nie najlepszy przykład." + Environment.NewLine +
                        "Bo mnie zmyliły…";
                    break;
                case 8:
                    textBoxMessage.Text = "Żaden dzień się nie powtórzy, " + Environment.NewLine +
                        "nie ma dwóch podobnych nocy, " + Environment.NewLine +
                        "dwóch tych samych pocałunków, "+ Environment.NewLine +
                        "dwóch jednakich spojrzeń w oczy. ";
                    break;
                case 9:
                    textBoxMessage.Text = "Moja mama zawsze mówiła: ''Życie jest jak pudełko czekoladek. Nigdy nie wiesz, co ci się trafi.'' ";
                    break;
                case 10:
                    textBoxMessage.Text = "Dlatego dwie uszy, jeden język dano, iżby mniej mówiono, a więcej słuchano";
                    break;
                default:
                    textBoxMessage.Text = "Wiadomość do zaszyfrowania. Min 50, Max 1000 znaków.";
                    break;
            }
        }

        private void buttonAddTextFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Txt File";
                dlg.Filter = "txt files (*.txt)|*.txt";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string text = System.IO.File.ReadAllText(dlg.FileName);

                    if (text.Length > 49 && text.Length < 1001)
                        textBoxMessage.Text = text;
                    else
                        textBoxMessage.Text = "Tekst wejsciowy jest nie poprawny. Min 50, Max 1000 znaków";

                }
            }
        }
        private void textBoxMessage_TextChanged(object sender, EventArgs e)
        {

        }

        ////////////////////////////////////////// BASE PICTURE //////////////////////////////////////////////
        private void buttonDefPictureBase_Click(object sender, EventArgs e)
        {
            pictureBoxBase.Image = new Bitmap(@"DefaultPictures\DefPicBase" + rnd.Next(1, numberOfDefPicBase + 1) + ".bmp");  
        }

        private void buttonAddPictureBase_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxBase.Image = new Bitmap(dlg.FileName);
                }
            }
        }

        private void pictureBoxBase_Click(object sender, EventArgs e)
        {
            buttonAddPictureBase_Click(sender, e);
        }

        /////////////////////////////////// PARAMETERS TO ENCRYPT ///////////////////////////////////////
        private void buttonDefValue_Click(object sender, EventArgs e)
        {
            SetAllErrorsClear();

            trackBarRed.Value = 3;
            trackBarGreen.Value = 2;
            trackBarBlue.Value = 3;

            trackBarRed_Scroll(sender, e);
            trackBarGreen_Scroll(sender, e);
            trackBarBlue_Scroll(sender, e);
        }

        private void buttonRandValue_Click(object sender, EventArgs e)
        {
            SetAllErrorsClear();

            trackBarRed.Value = rnd.Next(0,8); //na stale przypisane 8 bo od 0 do 255 wartosc koloru
            trackBarGreen.Value = rnd.Next(0, 8);
            trackBarBlue.Value = rnd.Next(0, 8);

            if (trackBarRed.Value == 0 && trackBarGreen.Value == 0 && trackBarBlue.Value == 0) //Gdy rnd da wszedzie zera
                buttonRandValue_Click(sender, e);
            else
            {
                trackBarRed_Scroll(sender, e);
                trackBarGreen_Scroll(sender, e);
                trackBarBlue_Scroll(sender, e);
            }
        }

        private void labelRed_Click(object sender, EventArgs e)
        {
            trackBarRed.Value = rnd.Next(0, 8);
            trackBarRed_Scroll(sender, e);
            IsAllZero();
        }

        private void labelGreen_Click(object sender, EventArgs e)
        {
            trackBarGreen.Value = rnd.Next(0, 8);
            trackBarGreen_Scroll(sender, e);
            IsAllZero();
        }

        private void labelBlue_Click(object sender, EventArgs e)
        {
            trackBarBlue.Value = rnd.Next(0, 8);
            trackBarBlue_Scroll(sender, e);
            IsAllZero();
        }

        private void trackBarRed_Scroll(object sender, EventArgs e)
        {
            textBoxRed.Text = "" + trackBarRed.Value.ToString();
            IsAllZero();
        }

        private void trackBarGreen_Scroll(object sender, EventArgs e)
        {
            textBoxGreen.Text = "" + trackBarGreen.Value.ToString();
            IsAllZero();
        }

        private void trackBarBlue_Scroll(object sender, EventArgs e)
        {
            textBoxBlue.Text = "" + trackBarBlue.Value.ToString();
            IsAllZero();
        }

        private void textBoxRed_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRed.Text == "9" || textBoxRed.Text == "" || textBoxRed.Text == null)
            {
                trackBarRed_Scroll(sender, e);
            }

            if (Char.IsNumber(textBoxRed.Text, 0))
            {
                trackBarRed.Value = Convert.ToInt32(textBoxRed.Text); //jezeli wartosc ok to przypisz
                IsAllZero();
            }
            else
            {
                trackBarRed_Scroll(sender, e); //jezeli nie to wez obecnie ustawiona wartosc w trackBar wpisz do textBox
            }
        }

        private void textBoxGreen_TextChanged(object sender, EventArgs e)
        {
            if (textBoxGreen.Text == "9" || textBoxGreen.Text == "" || textBoxGreen.Text == null)
            {
                trackBarGreen_Scroll(sender, e);
            }

            if (Char.IsNumber(textBoxGreen.Text, 0))
            {
                trackBarGreen.Value = Convert.ToInt32(textBoxGreen.Text);
                IsAllZero();
            }
            else
            {
                trackBarGreen_Scroll(sender, e);
            }
        }

        private void textBoxBlue_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBlue.Text == "9" || textBoxBlue.Text == "" || textBoxBlue.Text == null)
            {
                trackBarBlue_Scroll(sender, e);
            }

            if (Char.IsNumber(textBoxBlue.Text, 0))
            {
                trackBarBlue.Value = Convert.ToInt32(textBoxBlue.Text);
                IsAllZero();
            }
            else
            {
                trackBarBlue_Scroll(sender, e);
            }
        }

        ///////////////////////////////// LOGIC FOR PARAMETERS //////////////////////////////////////////

        private void SetAllErrorsClear()
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
        }

        private void IsAllZero()
        {
            SetAllErrorsClear();

            if (trackBarRed.Value == 0 && trackBarGreen.Value == 0 && trackBarBlue.Value == 0)
            {
                errorProvider1.SetError(textBoxRed, "Conajmniej jedna wartość musi być nie zerowa");
                errorProvider2.SetError(textBoxGreen, "Conajmniej jedna wartość musi być nie zerowa");
                errorProvider3.SetError(textBoxBlue, "Conajmniej jedna wartość musi być nie zerowa");

                return;
            }
        }

        ////////////////////////////////////////// ENCRYPTION //////////////////////////////////////////

        private void buttonEncryptText_Click(object sender, EventArgs e)
        {
            if (textBoxMessage.Text.Length < 50)
            {
                MessageBox.Show("Tekst wejściowy jest za krótki.","Tekst wejsciowy", MessageBoxButtons.OK);
                return;
            }
            else
                Encrypt(ConvertText());
        }

        private void buttonEncryptPicture_Click(object sender, EventArgs e)
        {
            Encrypt(ConvertPicture());
        }

        private void buttonSavePicFromEncrypt_Click(object sender, EventArgs e)
        {
            if (pictureBoxEncrypt.Image == null)
            {
                ShowErrorMessageBox();
                return;
            }


            Bitmap fileOut = (Bitmap)pictureBoxEncrypt.Image;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Bitmap Image|*.bmp";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

                fileOut.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                       
                fs.Close();

                ShowOkMessageBox();
            }
        }

        ///////////////////////////////// LOGIC FOR ENCRYPTION //////////////////////////////////////////

        /// <summary>
        /// Main function of encrypt part of program
        /// </summary>
        /// <param name="message"></param>
        private void Encrypt(string strMess)
        {
            string message = strMess;
            iiMessage = 0;

            picture = (Bitmap)pictureBoxBase.Image; //Dostep do GetPixel
            EncryptPicture = new Bitmap(picture.Width, picture.Height);

            for (int x = 0; x < picture.Width; x++)
                for (int y = 0; y < picture.Height; y++)
                {
                    if (iiMessage < message.Length)
                    {
                        Color hashColor = newColorUsingMessage(x, y, message);
                        EncryptPicture.SetPixel(x, y, hashColor);
                    }
                    else
                    {
                        if (checkBoxAddNoise.Checked == false)
                        {
                            Color color = Color.FromArgb(picture.GetPixel(x, y).A, picture.GetPixel(x, y).R, picture.GetPixel(x, y).G, picture.GetPixel(x, y).B);
                            EncryptPicture.SetPixel(x, y, color);
                        }
                        else 
                        {
                            message = GenerateNoise();
                            iiMessage = 0;
                            y--; //bo musimy nadpisac ten pixel który teraz by był pominięty.
                        }
                    }
                }

            //DateTime dt = DateTime.Now;
            //wyjscie.Save("Szyfrogram_" + dt.Day + "_" + dt.Month + "__" + dt.Hour + "_" + dt.Minute + ".bmp");

            pictureBoxEncrypt.Image = EncryptPicture;
            ShowEndOfEncryptMessageBox();
        }

        private string ConvertText()
        {
            string text = textBoxMessage.Text;
            text = CleanText(text);

            string textToEncrypt = "";

            for (int i = 0; i < text.Length; i++)
                textToEncrypt += Convert.ToString(text[i], 2).PadLeft(8, '0');

            return textToEncrypt;
        }

        private string CleanText(string textToClean)
        {
            string textAfterClean = "";

            for(int i = 0; i < textToClean.Length; i++)
                switch(textToClean[i])
                {
                    case 'ą':
                        textAfterClean += 'a';
                        break;
                    case 'ć':
                        textAfterClean += 'c';
                        break;
                    case 'ę':
                        textAfterClean += 'e';
                        break;
                    case 'ł':
                        textAfterClean += 'l';
                        break;
                    case 'ń':
                        textAfterClean += 'n';
                        break;
                    case 'ó':
                        textAfterClean += 'o';
                        break;
                    case 'ś':
                        textAfterClean += 's';
                        break;
                    case 'ź':
                        textAfterClean += 'z';
                        break;
                    case 'ż':
                        textAfterClean += 'z';
                        break;
                    //////////////////////////////////////////////
                    case 'Ą':
                        textAfterClean += 'A';
                        break;
                    case 'Ć':
                        textAfterClean += 'C';
                        break;
                    case 'Ę':
                        textAfterClean += 'E';
                        break;
                    case 'Ł':
                        textAfterClean += 'L';
                        break;
                    case 'Ń':
                        textAfterClean += 'N';
                        break;
                    case 'Ó':
                        textAfterClean += 'O';
                        break;
                    case 'Ś':
                        textAfterClean += 'S';
                        break;
                    case 'Ź':
                        textAfterClean += 'Z';
                        break;
                    case 'Ż':
                        textAfterClean += 'Z';
                        break;
                    ////////////////////////////////////////////
                    case '-':
                        textAfterClean += ' ';
                        break;
                    default:
                        textAfterClean += textToClean[i];
                        break;
                }

            return textAfterClean;
        }

        private string ConvertPicture()
        {
            Bitmap pictureIn = (Bitmap)pictureBoxMessage.Image;

            //dodawanie wymiaru obrazka na poczatku wiadomosci, miejsce 16 bitow na kazdy wymiar
            string textToEncrypt = ConvertHeightAndWidth(pictureIn.Height, pictureIn.Width);

            for (int x = 0; x < pictureIn.Width; x++)
                for (int y = 0; y < pictureIn.Height; y++)
                {
                    if (pictureIn.GetPixel(x, y).R < 100 && pictureIn.GetPixel(x, y).G < 100 && pictureIn.GetPixel(x, y).B < 100) //true uznajemy za czarny
                    {
                        textToEncrypt += "0";
                    }
                    else //false uznajemy za biały
                    {
                        textToEncrypt += "1";
                    }
                }

            return textToEncrypt;
        }

        private string ConvertHeightAndWidth(int picHeight, int picWidth)
        {
            var height = Convert.ToString(picHeight, 2).PadLeft(16, '0');
            var width = Convert.ToString(picWidth, 2).PadLeft(16, '0');

            return height + width;
        }

        public Bitmap picture; //Bitmap from pictureBoxBase
        private Color newColorUsingMessage(int x, int y, string message) //generowanie nowego koloru , głowna funkcja programu
        {
            Color Nowy;

            var tempR = picture.GetPixel(x, y).R; 
            var tempG = picture.GetPixel(x, y).G;
            var tempB = picture.GetPixel(x, y).B;

            string ConvertRed = Convert.ToString(picture.GetPixel(x, y).R, 2).PadLeft(8, '0');
            string ConvertGreen = Convert.ToString(picture.GetPixel(x, y).G, 2).PadLeft(8, '0');
            string ConvertBlue = Convert.ToString(picture.GetPixel(x, y).B, 2).PadLeft(8, '0');

            char[] bazaCRed = new char[ConvertRed.Length];
            char[] bazaCGreen = new char[ConvertGreen.Length];
            char[] bazaCBlue = new char[ConvertBlue.Length];

            for (int i = 0; i < bazaCRed.Length; i++)
            {
                bazaCRed[i] = ConvertRed[i];
                bazaCGreen[i] = ConvertGreen[i];
                bazaCBlue[i] = ConvertBlue[i];
            }

            for (int j = bazaCRed.Length - trackBarRed.Value; j < bazaCRed.Length; j++)
            {
                if (iiMessage < message.Length)
                {
                    bazaCRed[j] = message[iiMessage];
                    iiMessage++;
                }
                else
                    break;
            }

            for (int j = bazaCGreen.Length - trackBarGreen.Value; j < bazaCGreen.Length; j++)
            {
                if (iiMessage < message.Length)
                {
                    bazaCGreen[j] = message[iiMessage];
                    iiMessage++;
                }
                else
                    break;
            }

            for (int j = bazaCBlue.Length - trackBarBlue.Value; j < bazaCBlue.Length; j++)
            {
                if (iiMessage < message.Length)
                {
                    bazaCBlue[j] = message[iiMessage];
                    iiMessage++;
                }
                else
                    break;
            }

            //budujemy z tablicy charów string do zamiany na int
            string newStrRed = "";
            string newStrGreen = "";
            string newStrBlue = "";

            foreach (char elem in bazaCRed)
                newStrRed += elem;

            foreach (char elem in bazaCGreen)
                newStrGreen += elem;

            foreach (char elem in bazaCBlue)
                newStrBlue += elem;

            int newRed = String8ToInt(newStrRed);
            int newGreen = String8ToInt(newStrGreen);
            int newBlue = String8ToInt(newStrBlue);

            Nowy = Color.FromArgb(picture.GetPixel(x, y).A, newRed, newGreen, newBlue);

            return Nowy;
        }
        private int String8ToInt(string str)
        {
            int[] wartosc = new int[str.Length];
            int wynik = 0;

            for (int j = 0; j < str.Length; j++)
                wartosc[j] = str[j] - '0'; //zamiana z char na int

            wynik = (int)Math.Pow(2, 7) * wartosc[0] + (int)Math.Pow(2, 6) * wartosc[1] +
                (int)Math.Pow(2, 5) * wartosc[2] + (int)Math.Pow(2, 4) * wartosc[3] +
                (int)Math.Pow(2, 3) * wartosc[4] + 2 * 2 * wartosc[5] +
                2 * wartosc[6] + wartosc[7]; //obliczamy wartosc DEC dla wektora BIN

            return wynik;
        }

        ///////////////////////////////////////////// NOISE ///////////////////////////////////////////

        static bool IsPrime(long candidate)
        {
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                    return true;
                else
                    return false;
            }

            for (int i = 3; (i * i) <= candidate; i += 2)
                if ((candidate % i) == 0)
                    return false;

            return candidate != 1;
        }

        static long NWD(long a, long b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }

            return a;
        }

        public static int PowerModuloFast(long a, long b, long m)
        {
            int i;
            long result = 1;
            long x = a % m;

            for (i = 1; i <= b; i <<= 1)
            {
                x %= m;
                if ((b & i) != 0)
                {
                    result *= x;
                    result %= m;
                }
                x *= x;
            }

            return (int)result;
        }


        private static int MAX_BASE = 36;
        private static String pattern = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static char convertTo(long n, int newBase)
        {
            String result = "";

            //base is too big or too small
            if ((newBase > MAX_BASE) || (newBase < 2))
                return 'A';

            //n is equal to 0, do not process, return "0"
            if (n == 0)
                return 'B';

            //process until n > 0
            while (n > 0)
            {
                result = pattern[(int)n % newBase] + result;
                n /= newBase;
            }
            if (result == "")
                return '0';
            return result[result.Length - 1];
        }


        private string GenerateNoise()
        {
            long p = 0;
            long q = 0;
            long x = 0;
            long N = 0;

            do
            {
                p = rnd.Next(100000, 500000);
            }
            while (!IsPrime(p) && !(p % 4 == 3));

            do
            {
                q = rnd.Next(100000, 500000);
            }
            while (!IsPrime(q) && !(q % 4 == 3));

            N = p * q;

            do
            {
                x = rnd.Next(100000, 500000);
            }
            while (NWD(x, N) != 1);

            long n = 100000; //dlugosc ciagu

            long[] xtab = new long[n];

            xtab[0] = PowerModuloFast(x, 2, N);
            for (long i = 1; i < n; i++)
                xtab[i] = PowerModuloFast(xtab[i - 1], 2, N);
                
            string noise = "";

            for (long j = 0; j < n; j++)
                noise += convertTo(xtab[j], 2).ToString();

            return noise;
        }

        ////////////////////////////////////////// DECRYPTION //////////////////////////////////////////

        private Bitmap pictureToDecryption;
        private TextBox textBoxDecryption;
        private void buttonDecryptionText_Click(object sender, EventArgs e)
        {
            if (pictureBoxEncrypt.Image == null)
                return;

            pictureBoxDecryption.Image = null;
            tableLayoutPanel7.Controls.Remove(pictureBoxDecryption);
            tableLayoutPanel7.Controls.Remove(textBoxDecryption);

            tableLayoutPanel7.Controls.Add(textBoxDecryption);
            pictureToDecryption = (Bitmap)pictureBoxEncrypt.Image;

            textBoxDecryption.Text = DecriptionText();

            if(textBoxDecryption.Text != null || textBoxDecryption.Text != "")
                ShowEndOfDecryptionMessageBox();
        }

        private void buttonDecryptionPicture_Click(object sender, EventArgs e)
        {
            if (pictureBoxEncrypt.Image == null)
                return;

            textBoxDecryption.Text = null;
            tableLayoutPanel7.Controls.Remove(textBoxDecryption);
            tableLayoutPanel7.Controls.Remove(pictureBoxDecryption);

            tableLayoutPanel7.Controls.Add(pictureBoxDecryption);
            pictureToDecryption = (Bitmap)pictureBoxEncrypt.Image;

            pictureBoxDecryption.Image = DecryptionPicture();

            if(pictureBoxDecryption.Image != null)
                ShowEndOfDecryptionMessageBox();
        }

        private void buttonSavePicFromDecryption_Click(object sender, EventArgs e)
        {
            if (pictureBoxDecryption.Image != null)
            {
                Bitmap fileOut = pictureFromDecryption;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Bitmap Image|*.bmp";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

                    fileOut.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);

                    fs.Close();

                    ShowOkMessageBox();
                }
            }

            if (textBoxDecryption.Text != "" || textBoxDecryption.Text != null)
            {
                string fileOut = deMessage;

                if(fileOut == null || fileOut == "")
                {
                    ShowErrorMessageBox();
                    return;
                }

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Txt file|*.txt";
                saveFileDialog1.Title = "Save a Txt File";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    TextWriter tw = new StreamWriter(saveFileDialog1.FileName);
                    tw.WriteLine(fileOut);
                    tw.Close();
                    ShowOkMessageBox();
                }
            }
            
        }

        private void buttonAddPicToDecryption_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxEncrypt.Image = new Bitmap(dlg.FileName);
                    pictureToDecryption = (Bitmap)pictureBoxEncrypt.Image;
                }
            }
        }

        private void pictureBoxDecryption_Click(object sender, EventArgs e)
        {
            buttonAddPicToDecryption_Click(sender, e);
        }

        ////////////////////////////////////////// LOGIC FOR DECRYPTION //////////////////////////////////////////

        private string deMessage;
        private string DecriptionText()
        {
            string textFromPix = "";
            for(int x = 0; x < pictureToDecryption.Width; x++)
                for (int y = 0; y < pictureToDecryption.Height; y++)
                {
                    Color deColor = pictureToDecryption.GetPixel(x, y);
                    textFromPix += DecriptionPixel(deColor);
                }

            deMessage = "";
            for(int i = 7; i < textFromPix.Length; i+=8)
            {
                string temp = 
                    textFromPix[i - 7].ToString() + //najbardziej znaczacy bit
                    textFromPix[i - 6].ToString() + 
                    textFromPix[i - 5].ToString() + 
                    textFromPix[i - 4].ToString() + 
                    textFromPix[i - 3].ToString() + 
                    textFromPix[i - 2].ToString() + 
                    textFromPix[i - 1].ToString() + 
                    textFromPix[i].ToString();      //najmniej znaczacy bit

                deMessage += (char)String8ToInt(temp); //zamianana z 101010 na int a potem na char
            }

            return deMessage;
        }

        private string DecriptionPixel(Color deColor)
        {
            string text = "";

            var Red = Convert.ToString(deColor.R, 2).PadLeft(8, '0');
            var Green = Convert.ToString(deColor.G, 2).PadLeft(8, '0');
            var Blue = Convert.ToString(deColor.B, 2).PadLeft(8, '0');

            for (int i = Red.Length - trackBarRed.Value; i < Red.Length; i++)
                text += Red[i];

            for (int i = Green.Length - trackBarGreen.Value; i < Green.Length; i++)
                text += Green[i];

            for (int i = Blue.Length - trackBarBlue.Value; i < Blue.Length; i++)
                text += Blue[i];

            return text;
        }

        private Bitmap pictureFromDecryption;
        private Bitmap DecryptionPicture()
        {
            string textFromPix = "";
            for (int x = 0; x < pictureToDecryption.Width; x++)
                for (int y = 0; y < pictureToDecryption.Height; y++)
                {
                    Color deColor = pictureToDecryption.GetPixel(x, y);
                    textFromPix += DecriptionPixel(deColor);
                }

            int jj = 0;
            string hTemp = "";
            for(jj = 0; jj < 16; jj++) //ustaelnie wysokosci obrazka
                hTemp += textFromPix[jj];

            string wTemp = "";
            for (jj = 16; jj < 32; jj++)
                wTemp += textFromPix[jj];

            int hPicture = String16ToInt(hTemp);
            int wPicture = String16ToInt(wTemp);

            if(hPicture == 0 || wPicture == 0)
            {
                ShowErrorMessageBox();
                return null;
            }

            pictureFromDecryption = new Bitmap(wPicture,hPicture);

            for (int x = 0; x < pictureFromDecryption.Width; x++)
                for (int y = 0; y < pictureFromDecryption.Height; y++)
                {
                    if (jj < textFromPix.Length)
                    {
                        if (textFromPix[jj] == '0')
                            pictureFromDecryption.SetPixel(x, y, Color.Black);
                        else
                            pictureFromDecryption.SetPixel(x, y, Color.White);

                        jj++; //to bardzo wazne :)
                    }
                    else
                        break;
                }

            return pictureFromDecryption;
        }

        private int String16ToInt(string str)
        {
            int[] wartosc = new int[str.Length];
            int wynik = 0;

            for (int j = 0; j < str.Length; j++)
                wartosc[j] = str[j] - '0'; //zamiana z char na int

            wynik =
                (int)Math.Pow(2, 15) * wartosc[0] + (int)Math.Pow(2, 14) * wartosc[1] +
                (int)Math.Pow(2, 13) * wartosc[2] + (int)Math.Pow(2, 12) * wartosc[3] +
                (int)Math.Pow(2, 11) * wartosc[4] + (int)Math.Pow(2, 10) * wartosc[5] +
                (int)Math.Pow(2, 9) * wartosc[6] + (int)Math.Pow(2, 8) * wartosc[7] +
                (int)Math.Pow(2, 7) * wartosc[8] + (int)Math.Pow(2, 6) * wartosc[9] +
                (int)Math.Pow(2, 5) * wartosc[10] + (int)Math.Pow(2, 4) * wartosc[11] +
                (int)Math.Pow(2, 3) * wartosc[12] + (int)Math.Pow(2, 2) * wartosc[13] +
                (int)Math.Pow(2, 1) * wartosc[14] + (int)Math.Pow(2, 0) * wartosc[15];

            return wynik;
        }

        //////////////////////////////////////// ANOTHER FUNCTIONS ///////////////////////////////////////
        private void ShowOkMessageBox()
        {
            MessageBox.Show("Pomyślnie zapisano plik", "Zapis pliku", MessageBoxButtons.OK);
        }

        private void ShowEndOfEncryptMessageBox()
        {
            MessageBox.Show("Pomyślnie zaszyfrowano plik wejsciowy", "Szyfrowanie pliku", MessageBoxButtons.OK);
        }

        private void ShowEndOfDecryptionMessageBox()
        {
            MessageBox.Show("Pomyślnie zdeszyfrowano zaszyfrowany plik", "Deszyfrowanie pliku", MessageBoxButtons.OK);
        }

        private void ShowErrorMessageBox()
        {
            MessageBox.Show("Wystąpił błąd. Sprawdź wybrane opcje oraz parametry i spróbuj ponownie", "Error", MessageBoxButtons.OK);
        }
    }
}
