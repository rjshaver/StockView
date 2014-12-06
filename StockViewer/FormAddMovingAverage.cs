using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockViewer
{
    public partial class FormAddMovingAverage : Form
    {
        static int movingAverage = 0;//s = new int[4];
        private static bool retval = false;
        private static FormAddMovingAverage instance;


        public FormAddMovingAverage()
        {
            InitializeComponent();
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            retval = true;
            this.DialogResult = DialogResult.OK;
        }

        
  

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            retval = false;
        }

        public static bool Show(out int newmovaves)
        {

            // todo put in the show function
            instance = new FormAddMovingAverage();
            

            //instance.FormClosing = new FormClosingEventHandler()
            newmovaves = movingAverage;
            instance.ShowDialog();

            if (instance.DialogResult == DialogResult.OK)
            {
                newmovaves = movingAverage;
                instance.Hide();
                instance.Dispose();
                return true;
            }
            else {
                newmovaves = 0;
                instance.Hide();
                instance.Dispose();
                return false;
            }
            
                //movingAverage;
            // todo correct for return value
           // return retval;
        }

        private void FormAddMovingAverage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

  

        private void textMA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                movingAverage = int.Parse(textMA.Text);
            }
            catch (Exception ex)
            {
                movingAverage = 0;
                textMA.Text = "0";
                Console.WriteLine("Stacktrace: '{0}'", ex.StackTrace);
                
            }
            
        }

        private void FormAddMovingAverage_Load(object sender, EventArgs e)
        {

        }
    }
}
