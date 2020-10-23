using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace LexAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<Tuple<int, char>, int> scanTable = new Dictionary<Tuple<int, char>, int>();
        Dictionary<int, string> tokenTable = new Dictionary<int, string>();
        StreamReader file;
        char currentchar;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReadTxt(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                file = new StreamReader(openFileDialog.FileName);
                TextTable.Text = File.ReadAllText(openFileDialog.FileName);
                currentchar = (char)file.Read();
            }
        }

        public void ReadToken(object sender, RoutedEventArgs e)
        {
            int currentstate = 0;
            string token = "";
            while(true)
            {

                int pastcurrentstate = currentstate;

                try
                {
                    currentstate = scanTable[new Tuple<int, char>(currentstate, currentchar)];
                }
                catch(System.Collections.Generic.KeyNotFoundException)
                {
                    try
                    {
                        finaltokentext.Text = tokenTable[pastcurrentstate];
                        tokentext.Text = token;
                        break;
                    }
                    catch (System.Collections.Generic.KeyNotFoundException)
                    {
                        finaltokentext.Text = "ERROR: The character \"" + currentchar + "\" is throwing an error. Please check your token.";
                        tokentext.Text = "BROKEN TOKEN: \"" + token + currentchar + "\"";
                        break;
                    }
                }
              
                if (currentstate == -1)
                {
                    if(token != "")
                    {
                        if (token == "+")
                        {
                            finaltokentext.Text = "keyword token: +";
                        }
                        else if (token == "-")
                        {
                            finaltokentext.Text = "keyword token: -";
                        }
                        else if (token == "*")
                        {
                            finaltokentext.Text = "keyword token: *";
                        }
                        else if (token == "/")
                        {
                            finaltokentext.Text = "keyword token: /";
                        }
                        else if (token == "=")
                        {
                            finaltokentext.Text = "keyword token: =";
                        }
                        else if (token == "<")
                        {
                            finaltokentext.Text = "keyword token: <";
                        }
                        else if (token == "<=")
                        {
                            finaltokentext.Text = "keyword token: <=";
                        }
                        else if (token == "append")
                        {
                            finaltokentext.Text = "keyword token: append";
                        }
                        else if (token == "car")
                        {
                            finaltokentext.Text = "keyword token: car";
                        }
                        else if (token == "cdr")
                        {
                            finaltokentext.Text = "keyword token: cdr";
                        }
                        else if (token == "cons")
                        {
                            finaltokentext.Text = "keyword token: cons";
                        }
                        else if (token == "define")
                        {
                            finaltokentext.Text = "keyword token: define";
                        }
                        else if (token == "list")
                        {
                            finaltokentext.Text = "keyword token: list";
                        }
                        else if (token == "boolean?")
                        {
                            finaltokentext.Text = "keyword token: boolean?";
                        }
                        else if (token == "equal?")
                        {
                            finaltokentext.Text = "keyword token: equal?";
                        }
                        else if (token == "list?")
                        {
                            finaltokentext.Text = "keyword token: list?";
                        }
                        else if (token == "null?")
                        {
                            finaltokentext.Text = "keyword token: null?";
                        }
                        else if (token == "number?")
                        {
                            finaltokentext.Text = "keyword token: number?";
                        }
                        else
                        {
                            if(tokenTable[pastcurrentstate] == ""){
                                finaltokentext.Text = "ERROR: The character \"" + currentchar + "\" was unexpected. Please check your token.";
                                tokentext.Text = "BROKEN TOKEN: \"" + token + currentchar + "\"";
                            }
                            else
                            {
                                finaltokentext.Text = tokenTable[pastcurrentstate];
                                if(tokenTable[pastcurrentstate] == "decimal" || tokenTable[pastcurrentstate] == "binary" || tokenTable[pastcurrentstate] == "octal" || tokenTable[pastcurrentstate] == "hexidecimal")
                                {
                                    if(currentchar != ')' && currentchar != ' ' && currentchar != '(')
                                    {
                                        finaltokentext.Text = "ERROR43: The character \"" + currentchar + "\" was unexpected. Please check your token.";
                                        tokentext.Text = "BROKEN TOKEN: \"" + token + currentchar + "\"";
                                    }
                                }
                            }
                        }
                        tokentext.Text = token;
                        break;
                    }
                    else
                    {
                        currentstate = 0;
                    }
                }
                else
                {
                    token += currentchar;
                }
                currentchar = (char)file.Read();

            }
        }

        public void ScanTokenTable(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                TokenTable.Text = File.ReadAllText(openFileDialog.FileName);

                reader.ReadLine();

                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        break;
                    string[] stringArray = line.Split(',');

                    int state = Convert.ToInt32(stringArray[0]);
                    string token = stringArray[1];

                    tokenTable[state] = token;
                }
            }
        }

        /**
         * ScanLexicalTable scans a csv file and gets all the transitions 
         * from one state to another given an input character and places 
         * those transitions in a dictionary.
         * The dictionary has a tuple as the key. Tuple[0] is the current state. 
         * Tuple[1] is the input character (ascii integer related to the character). 
         * The value of the dictionary is the state that you would end up at.
         */
        private void ScanLexicalTable(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                LexicalTable.Text = File.ReadAllText(openFileDialog.FileName);


                reader.ReadLine();

                string line = reader.ReadLine();

                Dictionary<int, int> columnDictionary = new Dictionary<int, int>();
                string[] stringArray = line.Split(',');
                for (int i = 1; i < stringArray.Length; i++)
                {
                    columnDictionary[i] = Convert.ToInt32(stringArray[i]);
                }

                bool noteof = true;
                while (noteof)
                {
                    line = reader.ReadLine();
                    if (line == null)
                        noteof = false;
                    else
                    {
                        stringArray = line.Split(',');

                        int curState = Convert.ToInt32(stringArray[0]);

                        for (int i = 1; i < stringArray.Length; i++)
                        {
                            int nextState = -1;
                            char inputChar = (char)columnDictionary[i];
                            if (stringArray[i] != "")
                                nextState = Convert.ToInt32(stringArray[i]);

                            scanTable[new Tuple<int, char>(curState, inputChar)] = nextState;
                        }
                    }
                }
            }
        }
    }
}
