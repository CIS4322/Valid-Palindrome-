using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ValidPalindrome
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string data = null;
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    data = File.ReadAllText(filePath);
                }
            }
            catch (Exception)
            {
                throw;
            }
            string[] words = data.Split('\r', '\n');

            foreach(string word in words)
            {
                if(!string.IsNullOrEmpty(word))
                {
                    if (isPalindrome(word))
                    {
                        palindromeList.Items.Add(new ListViewItem(new string[] { word, "true" }));
                    }
                    else
                    {
                        palindromeList.Items.Add(new ListViewItem(new string[] { word, "false" }));

                    }
                }
                
            }
        }
        public bool isPalindrome(string word)
        {
            int a = 0;
            int b = word.Length - 1;
            while (a < b)
            {
                char left = word[a];
                char right = word[b];
                if (!Char.IsLetterOrDigit(left))
                {
                    a++;
                    continue;
                }
                if (!Char.IsLetterOrDigit(right))
                {
                    b--; ;
                    continue;
                }
                if (char.ToLower(left) != char.ToLower(right))
                {
                    return false;
                }
                a++;
                b--;
            }
            return true;            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            palindromeList.Items.Clear();
            palindromeList.Columns.Add("Word:", 100);
            palindromeList.Columns.Add("isPalindrome:", 120);
            palindromeList.View = View.Details;
            palindromeList.GridLines = true;
            palindromeList.Sorting = SortOrder.Ascending;
        }
    }
}
