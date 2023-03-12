using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace GayaProject
{
    public partial class CalculationForm : Form
    {
        public CalculationForm()
        {
            InitializeComponent();
            List<string> items = new List<string>() { "+", "-", "/" ,"*", "CONCAT", "REMOVE" };
          
            this.comboBox1.DataSource = items;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var inputstr1 = this.textBox1.Text; //= double.Parse(this.textBox1.Text);
            var inputstr2 = this.textBox2.Text; // = double.Parse(this.textBox2.Text);

            //double input1;
           // double input2;

            bool isNumber = true;

            string operation = this.comboBox1.SelectedItem.ToString();
            operation = HttpUtility.UrlEncode(operation);
            HttpClient client = new HttpClient();
            
            //client.BaseAddress = new Uri("http://localhost:44314/api/");
            HttpResponseMessage response = new HttpResponseMessage();
            if (double.TryParse(this.textBox1.Text, out double input1) && double.TryParse(this.textBox2.Text, out double input2))
            {
                response = await client.GetAsync($"https://localhost:44314/api/Operations?input1={input1}&input2={input2}&operation={operation}");
            }
            else 
            {
                response = await client.GetAsync($"https://localhost:44314/api/Operations?inputstr1={inputstr1}&inputstr2={inputstr2}&operation={operation}");
                isNumber = false;
            }
            

            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                resultString = resultString.Trim('"');
                if (isNumber)
                {
                    double result = double.Parse(resultString);
                    this.textBox3.Text = result.ToString();
                }
                else
                    this.textBox3.Text = resultString;
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                this.textBox3.Text = errorMessage;
            }
        }

    }
}
