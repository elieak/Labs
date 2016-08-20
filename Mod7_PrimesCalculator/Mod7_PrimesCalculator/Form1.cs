using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Mod7_PrimesCalculator
{
    public partial class Form1 : Form
    {
        private int number1 { get; set; }
        private int number2 { get; set; }
        private Thread _calculateThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                number1 = int.Parse(textBox1.Text);
                number2 = int.Parse(textBox2.Text);

            }
            catch (Exception)
            {
                MessageBox.Show($"Please enter a number between 0 and {int.MaxValue}");
            }

            listBox1.Items.Clear();
            button1.Enabled = false;
            _calculateThread = new Thread(() => { CalculatePrimes(number1, number2); });
            _calculateThread.Start();
        }

        private void CalculatePrimes(int firstNumber, int secondNumber)
        {
            var calculationResult = new List<int>();
            if (secondNumber < 2 || secondNumber < firstNumber) return;

            if (firstNumber < 3)
            {
                calculationResult.Add(2);
                firstNumber = 3;
            }

            if (firstNumber%2 == 0)
            {
                firstNumber++;
            }
                
            for (var i = firstNumber; i < secondNumber; i += 2)
            {
                if (i.isPrime())
                {
                    calculationResult.Add(i);
                }
            }
            foreach (var prime in calculationResult)
            {
                Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add(prime);
                    button1.Enabled = true;
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _calculateThread.Abort();
            button1.Enabled = true;
        }
    }
}
