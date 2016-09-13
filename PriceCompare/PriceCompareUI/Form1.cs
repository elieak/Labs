using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PriceCompare.Calculations;
using PriceCompare.Components;
using PriceCompare.XmlManipulation;

namespace PriceCompareUI
{
    public partial class Form1 : Form
    {
        private readonly PriceCalculator PriceCaluclator = new PriceCalculator();

        public Form1()
        {
            InitializeComponent();
        }

        private async void LoadItemsBtn_Click(object sender, EventArgs e)
        {
            XmlParser.ParseXml();
            listBox1.Items.Clear();

            var filteredList = await FilterXML.FilterXmlList();

            if (filteredList != null)
                listBox1.Items.AddRange(filteredList.ToArray());

            getMinMaxBtn.Enabled = true;
            searchBtn.Enabled = true;
        }

        private void addToCartBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null) listBox2.Items.Add(listBox1.SelectedItem);
        }
        private void RmvcartBtn_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }
        private void calcPricebtn_Click(object sender, EventArgs e)
        {
            var listboxItems = listBox2.Items.Cast<ItemInformation>();
            var priceList = PriceCaluclator.CalculatePrice(listboxItems);
            total1lbl.Font = new Font(total1lbl.Font.Name, 8, FontStyle.Bold | FontStyle.Underline);

            try
            {
                total1lbl.Text = priceList[0];
                total2lbl.Text = priceList[1];
                total3lbl.Text = priceList[2];
                listBox2.Items.Clear();
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeEx)
            {
                MessageBox.Show(@"Please Select Items First. " + argumentOutOfRangeEx, @"No Items Selected");
            }
        }
        private void getMinMaxBtn_Click(object sender, EventArgs e)
        {
            var minMaxItems = PriceCaluclator.CalculateMinMax();

            var minList = PriceCaluclator.GetMin(minMaxItems);
            var maxList = PriceCaluclator.GetMax(minMaxItems);
            minlbl.Text = minList;
            maxlbl.Text = maxList;
        }

       private void searchBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(SearchXML.Result(searchBox.Text).ToArray());
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            searchBtn_Click(this, new EventArgs());
            searchBox.Clear();
        }
    }
}