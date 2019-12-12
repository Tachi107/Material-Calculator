using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2019_11_29___CalcolatriceCsharp
{
    public partial class Calcolatrice : Form
    {
        private readonly double[] numbers = new double[100];//Pur essendo un campo readonly,
        private readonly char[] operations = new char[100]; //esso può essere modificato dato che
        private int numbersLength = 0;                      //gli viene assegnato un valore
        private int operationsLength = 0;                   //in fase di dichiarazione.
        private char[] number = new char[100];              //Ha senso farlo? Non credo.
        private char[] numberBackup = new char[100];        //Lo faccio così magari mi dice
        private int numberLength = 0;                       //perché ha/non ha senso
        private int numberLengthBackup = 0;
        private bool cleared = false;
        private readonly int panelMaxWidth;
        private bool closed = false;
        public Calcolatrice()
        {
            InitializeComponent();
            panelMaxWidth = panelOpen.Width;
        }

        private void Calcolatrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            object obj = 0;
            MouseEventArgs eventArgs = new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0);   //MouseEvent nullo necessario per 
            MouseEventArgs rightClick = new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0); //chiamare le funzioni sui bottoni
            if (e.KeyChar == '0') button0_MouseClick(obj, eventArgs);
            if (e.KeyChar == '1') button1_MouseClick(obj, eventArgs);
            if (e.KeyChar == '2') button2_MouseClick(obj, eventArgs);
            if (e.KeyChar == '3') button3_MouseClick(obj, eventArgs);
            if (e.KeyChar == '4') button4_MouseClick(obj, eventArgs);
            if (e.KeyChar == '5') button5_MouseClick(obj, eventArgs);
            if (e.KeyChar == '6') button6_MouseClick(obj, eventArgs);
            if (e.KeyChar == '7') button7_MouseClick(obj, eventArgs);
            if (e.KeyChar == '8') button8_MouseClick(obj, eventArgs);
            if (e.KeyChar == '9') button9_MouseClick(obj, eventArgs);
            if (e.KeyChar == ',') buttonComma_MouseClick(obj, eventArgs);
            if (e.KeyChar == '.') buttonComma_MouseClick(obj, eventArgs);
            if (e.KeyChar == '/') buttonDivision_MouseClick(obj, eventArgs);
            if (e.KeyChar == '*') buttonMultiplication_MouseClick(obj, eventArgs);
            if (e.KeyChar == 'x') buttonMultiplication_MouseClick(obj, eventArgs);
            if (e.KeyChar == '-') buttonSubtraction_MouseClick(obj, eventArgs);
            if (e.KeyChar == '+') buttonAddition_MouseClick(obj, eventArgs);
            if (e.KeyChar == '^') buttonPow_MouseClick(obj, eventArgs);
            if (e.KeyChar == 'v') buttonSqrt_MouseClick(obj, eventArgs);
            if (e.KeyChar == 'p') buttonPi_MouseClick(obj, eventArgs);
            if (e.KeyChar == (char)Keys.Back) buttonBackspace_MouseDown(obj, eventArgs);
            if (e.KeyChar == (char)Keys.Escape) buttonBackspace_MouseDown(obj, rightClick);
            if (e.KeyChar == (char)Keys.Enter) buttonEquals_Click(obj, eventArgs);
            if (e.KeyChar == '=') buttonEquals_Click(obj, eventArgs);
        }

        private void button0_MouseClick(object sender, MouseEventArgs e)
        {
            buttonNumber('0');
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            buttonNumber('1');
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            buttonNumber('2');
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            buttonNumber('3');
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            buttonNumber('4');
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            buttonNumber('5');
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            buttonNumber('6');
        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            buttonNumber('7');
        }

        private void button8_MouseClick(object sender, MouseEventArgs e)
        {
            buttonNumber('8');
        }

        private void button9_MouseClick(object sender, MouseEventArgs e)
        {
            buttonNumber('9');
        }

        private void buttonNumber(char digit)
        {
            if (cleared == true) textBoxResult.Text = string.Empty;
            cleared = false;
            textBoxResult.Text += digit;
            number[numberLength] = digit;
            numberLength++;
        }

        private void buttonComma_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxResult.Text))
            {
                if (textBoxResult.Text[textBoxResult.Text.Length - 1] != ',')
                {
                    textBoxResult.Text += ",";
                    number[numberLength] = ',';
                    numberLength++;
                }
                //else MessageBox.Show("Non puoi mettere più di una virgola");
            }
        }

        private void buttonDivision_MouseClick(object sender, MouseEventArgs e)
        {
            buttonOperation('÷');
        }

        private void buttonMultiplication_MouseClick(object sender, MouseEventArgs e)
        {
            buttonOperation('×');
        }

        private void buttonSubtraction_MouseClick(object sender, MouseEventArgs e)
        {
            if (cleared == true) textBoxResult.Text = string.Empty;
            cleared = false;
            if (!string.IsNullOrEmpty(textBoxResult.Text))
            {
                int textBoxResultLastCharPosition = textBoxResult.Text.Length - 1;
                buttonOperation('−');
                if (textBoxResult.Text.Length > 1)
                {
                    if (((textBoxResult.Text[textBoxResultLastCharPosition] == '+') || (textBoxResult.Text[textBoxResultLastCharPosition] == '−') || (textBoxResult.Text[textBoxResultLastCharPosition] == '×') || (textBoxResult.Text[textBoxResultLastCharPosition] == '÷') || (textBoxResult.Text[textBoxResultLastCharPosition] == ',') || (textBoxResult.Text[textBoxResultLastCharPosition] == '^') || (textBoxResult.Text[textBoxResultLastCharPosition] == '√')) && (textBoxResult.Text[textBoxResultLastCharPosition - 1] != '−'))
                    {
                        textBoxResult.Text += "−";
                        number[numberLength] = '-';
                        numberLength++;
                    }
                }
                else
                {
                    if (((textBoxResult.Text[textBoxResultLastCharPosition] == '+') || (textBoxResult.Text[textBoxResultLastCharPosition] == '−') || (textBoxResult.Text[textBoxResultLastCharPosition] == '×') || (textBoxResult.Text[textBoxResultLastCharPosition] == '÷') || (textBoxResult.Text[textBoxResultLastCharPosition] == ',') || (textBoxResult.Text[textBoxResultLastCharPosition] == '^') || (textBoxResult.Text[textBoxResultLastCharPosition] == '√')) && (textBoxResult.Text[textBoxResultLastCharPosition] != '−'))
                    {
                        textBoxResult.Text += "−";
                        number[numberLength] = '-';
                        numberLength++;
                    }
                }
            }
            else
            {
                textBoxResult.Text += "−";
                number[numberLength] = '-';
                numberLength++;
            }
        }

        private void buttonAddition_MouseClick(object sender, MouseEventArgs e)
        {
            buttonOperation('+');
        }

        private void buttonPow_MouseClick(object sender, MouseEventArgs e)
        {
            buttonOperation('^');
        }

        private void buttonOperation(char operation)
        {//Cambiare con textboxResult.Text.Lenght == 0 per prestazioni migliori in modalità Release
            if (!string.IsNullOrEmpty(textBoxResult.Text))
            {
                int textBoxResultLastCharPosition = textBoxResult.Text.Length - 1;
                if ((textBoxResult.Text[textBoxResultLastCharPosition] != '+') && (textBoxResult.Text[textBoxResultLastCharPosition] != '−') && (textBoxResult.Text[textBoxResultLastCharPosition] != '×') && (textBoxResult.Text[textBoxResultLastCharPosition] != '÷') && (textBoxResult.Text[textBoxResultLastCharPosition] != ',') && (textBoxResult.Text[textBoxResultLastCharPosition] != '^') && (textBoxResult.Text[textBoxResultLastCharPosition] != '√') && (cleared == false))
                {
                    textBoxResult.Text += operation;
                    string numberString = new string(number);
                    numbers[numbersLength] = Double.Parse(numberString);    //Dopo aver raccolto le cifre necessarie a formare un numero in number,
                    numbersLength++;                                        //lo metto in numbers quando clicco su un pulsante operazione, cioè
                    Array.Copy(number, 0, numberBackup, 0, numberLength);   //quando ho finito di inserire quel numero e sono pronto a inserirne un altro.
                    numberLengthBackup = numberLength;                      //Pulisco quindi number e inserisco il segno d'operazione all'interno del
                    Array.Clear(number, 0, numberLength);                   //rispettivo array, incrementando l'indice dei numeri e dei segni
                    numberLength = 0;
                    operations[operationsLength] = operation;
                    operationsLength++;
                }
            }
        }

        private void buttonSqrt_MouseClick(object sender, MouseEventArgs e)
        {
            if (cleared == true) textBoxResult.Text = string.Empty;
            cleared = false;
            if (!string.IsNullOrEmpty(textBoxResult.Text))
            {
                int textBoxResultLastCharPosition = textBoxResult.Text.Length - 1;
                if ((textBoxResult.Text[textBoxResultLastCharPosition] == '+') || (textBoxResult.Text[textBoxResultLastCharPosition] == '−') || (textBoxResult.Text[textBoxResultLastCharPosition] == '×') || (textBoxResult.Text[textBoxResultLastCharPosition] == '÷') || (textBoxResult.Text[textBoxResultLastCharPosition] == '^'))
                {
                    textBoxResult.Text += "√";
                    operations[operationsLength] = '√';
                    operationsLength++;
                }
            }
            else
            {
                textBoxResult.Text += "√";
                operations[operationsLength] = '√';
                operationsLength++;
            }
        }

        private void buttonPi_MouseClick(object sender, MouseEventArgs e)
        {//PI compreso 3 e . sono 16 cifre
            if (!string.IsNullOrEmpty(textBoxResult.Text))
            {
                int textBoxResultLastCharPosition = textBoxResult.Text.Length - 1;
                if ((textBoxResult.Text[textBoxResultLastCharPosition] == '+') || (textBoxResult.Text[textBoxResultLastCharPosition] == '−') || (textBoxResult.Text[textBoxResultLastCharPosition] == '×') || (textBoxResult.Text[textBoxResultLastCharPosition] == '÷') || (textBoxResult.Text[textBoxResultLastCharPosition] == '^'))
                {
                    if (cleared == true) textBoxResult.Text = "";
                    cleared = false;
                    textBoxResult.Text += "𝜋";
                    string PI = Math.PI.ToString();
                    number = PI.ToCharArray();
                    numberLength += 16;
                }
            }
            else
            {
                textBoxResult.Text += "𝜋";
                string PI = Math.PI.ToString();
                number = PI.ToCharArray();
                numberLength += 16;
            }
        }

        private void buttonBackspace_MouseDown(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxResult.Text))
            {
                if ((e.Button == MouseButtons.Right) || (cleared == true))
                {
                    Array.Clear(number, 0, numberLength);
                    numberLength = 0;
                    Array.Clear(numbers, 0, numbersLength);
                    numbersLength = 0;
                    Array.Clear(operations, 0, operationsLength);
                    operationsLength = 0;
                    numberLength = 0;
                    textBoxResult.Text = string.Empty;
                    cleared = true;
                }
                else
                {
                    int textBoxResultLastCharPosition = textBoxResult.Text.Length - 1;
                    if ((textBoxResult.Text[textBoxResultLastCharPosition] == '+') || (textBoxResult.Text[textBoxResultLastCharPosition] == '−') || (textBoxResult.Text[textBoxResultLastCharPosition] == '×') || (textBoxResult.Text[textBoxResultLastCharPosition] == '÷') || (textBoxResult.Text[textBoxResultLastCharPosition] == '^'))
                    {//dovrei annullare il salvataggio di number in numbers, e ripristinare quindi lo stato precedente di number
                        operations[operationsLength - 1] = '\0';
                        operationsLength--;
                        numbers[numbersLength - 1] = 0;
                        numbersLength--;
                        Array.Copy(numberBackup, 0, number, 0, numberLengthBackup);
                        numberLength = numberLengthBackup;
                    }
                    else
                    {
                        numberLength--;
                        number[numberLength] = '\0';
                    }
                    textBoxResult.Text = textBoxResult.Text.Remove(textBoxResult.Text.Length - 1);
                }
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxResult.Text))
            {
                int textBoxResultLastCharPosition = textBoxResult.Text.Length - 1;
                if ((textBoxResult.Text[textBoxResultLastCharPosition] != '+') && (textBoxResult.Text[textBoxResultLastCharPosition] != '−') && (textBoxResult.Text[textBoxResultLastCharPosition] != '×') && (textBoxResult.Text[textBoxResultLastCharPosition] != '÷') && (textBoxResult.Text[textBoxResultLastCharPosition] != ',') && (textBoxResult.Text[textBoxResultLastCharPosition] != '^') && (textBoxResult.Text[textBoxResultLastCharPosition] != '√') && (cleared == false))
                {
                    string numberString = new string(number);
                    numbers[numbersLength] = Double.Parse(numberString);
                    numbersLength++;
                    Array.Clear(number, 0, number.Length);
                    numberLength = 0;
                    for (int i = 0; i < operationsLength; i++)
                    {
                        if (operations[i] == '^' || operations[i] == '√')
                        {
                            if (operations[i] == '^')
                            {
                                numbers[i] = Math.Pow(numbers[i], numbers[i + 1]);
                                for (int j = i + 1; j < operationsLength; j++) numbers[j] = numbers[j + 1];
                                for (int j = i; j < operationsLength; j++) operations[j] = operations[j + 1];
                                numbersLength--;
                                operationsLength--;
                            }
                            if (operations[i] == '√')   //La parte relativa al calcolo della radice quadrata è unica, in quanto il calcolo
                            {                           //è effettuato su un solo numero, il radicando. Non devo quindi ridurre il numero di numbers dell'equazione
                                numbers[i] = Math.Sqrt(numbers[i]);
                                for (int j = i; j < operationsLength; j++) operations[j] = operations[j + 1];
                                operationsLength--;
                            }
                        }
                    }
                    for (int i = 0; i < operationsLength; i++)                   //Scorro tutto l'array delle operazioni per vedere se ci sono
                    {                                                           //moltiplicazioni o divisioni, ed eventualmente le eseguo
                        if ((operations[i] == '×') || (operations[i] == '÷'))
                        {
                            if (operations[i] == '×') numbers[i] = numbers[i] * numbers[i + 1];
                            if (operations[i] == '÷') numbers[i] = numbers[i] / numbers[i + 1];
                            for (int j = i + 1; j < operationsLength; j++) numbers[j] = numbers[j + 1];      //Shifto i numeri e le operazioni, in modo
                            for (int j = i; j < operationsLength; j++) operations[j] = operations[j + 1];    //da avere il risultato in i e il secondo
                            numbersLength--;                                                                 //numero al quale operazionarlo in i + 1
                            operationsLength--;
                            i--;    //Necessario, dato che, sostituendo il risultato al numbers[i] dovrò effettuare nuovamente il calcolo
                        }           //sul numero alla stessa posizione, e non alla successiva
                    }
                    for (int i = 0; i < operationsLength; i++)                   //Scorro di nuovo alla ricerca di addizioni/sottrazioni
                    {                                                           //e in pratica è la stessa cosa che c'è sopra.
                        if ((operations[i] == '+') || (operations[i] == '−'))   //In realtà questo if è superfluo, in quanto una volta arrivato al
                        {                                                       //terzo scorrimento le operazioni rimaste saranno per forza somme e sottrazioni; L'ho mantenuto per una questione di leggibilità e coerenza.
                            if (operations[i] == '+') numbers[i] = numbers[i] + numbers[i + 1];
                            if (operations[i] == '−') numbers[i] = numbers[i] - numbers[i + 1];
                            for (int j = i + 1; j < operationsLength; j++) numbers[j] = numbers[j + 1];
                            for (int j = i; j < operationsLength; j++) operations[j] = operations[j + 1];
                            numbersLength--;
                            operationsLength--;
                            i--;
                        }
                    }
                    textBoxResult.Text = numbers[operationsLength].ToString();
                    Array.Clear(numbers, 0, numbers.Length);
                    numbersLength = 0;
                    Array.Clear(operations, 0, operations.Length);
                    operationsLength = 0;
                    numberLength = 0;
                    cleared = true;
                }
            }
        }

        private void labelPanelClosed_MouseClick(object sender, MouseEventArgs e)
        {
            if (closed) labelPanelClosed.Text = ">";
            else labelPanelClosed.Text = "<";
            timerPanel.Start();
        }

        private void panelClosed_MouseClick(object sender, MouseEventArgs e)
        {
            object obj = 0;
            MouseEventArgs eventArgs = new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0);
            labelPanelClosed_MouseClick(obj, eventArgs);
        }

        private void timerPanel_Tick(object sender, EventArgs e)
        {
            if (closed)
            {
                panelOpen.Width += 26;
                if (panelOpen.Width >= panelMaxWidth)
                {
                    timerPanel.Stop();
                    closed = false;
                    Refresh();      //Aggiorna lo stato del form, quindi la posizione
                }                   //visualizzata del pannello
            }
            else
            {
                panelOpen.Width -= 26;
                if (panelOpen.Width <= 0)
                {
                    timerPanel.Stop();
                    closed = true;
                    Refresh();
                }
            }
        }
    }
}
/* vecchio codice, approccio diverso
 * string operation = textBoxResult.Text;
 * char[] separators = {'+', '−', '÷', '×'};
 * string[] operations = operation.Split(separators);
 * if (operation.Contains('×'))
 * {
 *     //int indexX = operation[operation.IndexOf('×')];
 *     for (int i = 0; i >= 0; i++)
 *     {
 *         string numero = "";
 *         numero += operation[operation.IndexOf('×') - i].ToString();
 *     }
 *     //textBoxResult.Text = numero;
 * }
 */