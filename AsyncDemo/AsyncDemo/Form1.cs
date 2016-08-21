using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemo
{
    public partial class Form1 : Form
    {
        private delegate IEnumerable<int> PrimeDelegate(int firstNumber, int secondNumber);
        private delegate void ListUpdatedDelegate(IEnumerable<int> list);

        public Form1()
        {
            InitializeComponent();
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            PrimeDelegate primeDelegate = CalcPrimes;
            listBox1.DataSource = null;
            listBox1.Items.Clear();

            primeDelegate.BeginInvoke(int.Parse(firstNumberTB.Text), int.Parse(secondNumberTB.Text), delegate (IAsyncResult iAsyncResult)
             {
                 var list = primeDelegate.EndInvoke(iAsyncResult);

                 BeginInvoke(new Action(() =>
                 {
                     listBox1.Items.Clear();
                     foreach (var number in list)
                     {
                         listBox1.Items.Add(number);
                     }
                 }));
             }, primeDelegate);
        }
        private static IEnumerable<int> CalcPrimes(int fNumber, int sNumber)
        {
            var primes = new List<int>();

            for (var i = fNumber; i <= sNumber; i++)
            {
                var isPrime = true;

                if ((i & 1) == 0)
                {
                    if (i != 2)
                    {
                        isPrime = false;
                    }
                }

                for (var j = 3; (j * j) <= i; j += 2)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                    }
                }

                if (isPrime)
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
        private void UpdateList(IEnumerable<int> list)
        {
            listBox1.Items.Clear();
            listBox1.BeginUpdate();

            foreach (var n in list)
            {
                listBox1.Items.Add(n);
            }

            listBox1.DataSource = list;
            listBox1.Refresh();
            listBox1.EndUpdate();
        }
        private void OnCompleted(IAsyncResult result)
        {
            var primeDel = (PrimeDelegate)result.AsyncState;
            var list = primeDel.EndInvoke(result);
            BeginInvoke(new ListUpdatedDelegate(UpdateList), list);
        }
    }
}
