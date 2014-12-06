using System;
//using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockViewer
{
    public partial class Form1 : Form
    {

        private int zoomcount = 0;
        private UInt32 initialnumIndicators;
        private Indicators myIndicators;
        Stack<ChartYValues> stockchartyvalues = new Stack<ChartYValues>();
        EventListener listener;

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stocksDataSet.ALLSTOCKLIST' table. You can move, or remove it, as needed.
            this.aLLSTOCKLISTTableAdapter.Fill(this.stocksDataSet.ALLSTOCKLIST);


            DataRowView drv = (DataRowView) comboBoxSymbol.SelectedItem;
            // TODO: This line of code loads data into the 'stocksDataSet.ALLSTOCKDATA' table. You can move, or remove it, as needed.
            this.aLLSTOCKDATATableAdapter.Fill(this.stocksDataSet.ALLSTOCKDATA, drv.Row.ItemArray[0].ToString());
            this.aLLSTOCKDATATableAdapter.Adapter.FillLoadOption = LoadOption.OverwriteChanges;


            chartStock.DataBind();



            // read the number of indicators from the previous run of the program
            this.initialnumIndicators = (UInt32)Properties.Settings.Default.numberIndicators;

            // generate a new list of indicators
            try { 
                
                
                this.myIndicators = new Indicators( chartStock );
                listener = new EventListener(myIndicators);
                myIndicators.Symbol = drv.Row.ItemArray[0].ToString();
                myIndicators.readIndicators(initialnumIndicators);
                
                
            }
            catch (NotImplementedException ex) { Console.WriteLine("Stacktrace: '{0}'", ex.StackTrace); }

            

            foreach (System.Int64 i in myIndicators.Keys)
            {
                System.Int64 indType = i >> 56;
                System.Int64 value = i - indType << 56;


                switch (indType)
                {
                    case ((System.Int64) indicatorType.SimpleMovingAverage):
                        switch (value)
                        {
                            case 8:
                                EightDayToolStripMenuItem.Checked = true;
                                break;
                            case 40:
                                FortyDayToolStripMenuItem.Checked = true;
                                break;
                            case 200:
                                TwoHundredDayToolStripMenuItem.Checked = true;
                                break;
                            default:
                                // add a toolstrip menu item for value of simple moving average
                                String menuItemString = value.ToString() + " - day moving average";
                                ToolStripMenuItem newMenuItem = new ToolStripMenuItem(menuItemString);
                                simpleMovingAveragesToolStripMenuItem.DropDownItems.Add(newMenuItem);
                                newMenuItem.Checked = true;
                                newMenuItem.Click += new System.EventHandler(newSMAStripMenuItem_Click);

                                break;
                        }


                        break;
                    default:
                        break;
                }
                //TODO : put in the ToolStripMenuItems
                
            }

            // read the indicators and add them to the list of indicators
            //readIndicators(initialnumIndicators);

            
        }

       

        private void resetYAxis()
        {
            double xmax = this.chartStock.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            double xmin = this.chartStock.ChartAreas[0].AxisX.ScaleView.ViewMinimum;


            if (xmax != this.chartStock.ChartAreas[0].AxisX.Maximum || xmin != this.chartStock.ChartAreas[0].AxisX.Minimum)
            {
                double priceymax = this.chartStock.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
                double priceymin = this.chartStock.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                double volumeymax = this.chartStock.ChartAreas[1].AxisY.ScaleView.ViewMaximum;
                double volumeymin = this.chartStock.ChartAreas[1].AxisY.ScaleView.ViewMinimum;

                ChartYValues yvals = new ChartYValues();
                yvals.priceymaximum = priceymax;
                yvals.priceyminimum = priceymin;
                yvals.volumeymaximum = volumeymax;
                yvals.volumeyminimum = volumeymin;

                stockchartyvalues.Push(yvals);
                zoomcount++;
            }

            else
            {
                zoomcount = 0;
                while (stockchartyvalues.Count > 0)
                    stockchartyvalues.Pop();
            }


            var allPoints = chartStock.Series.SelectMany(x => x.Points);
            //x => (x.YValuesPerPoint == 4));
            //x => x.Points && x.YValuesPerPoint == 4);
            var candidatePoints = allPoints.Where(x => x.XValue >= xmin && x.XValue <= xmax && x.YValues.Count() == 4); //   && x.XValue <= xmax);


            // get max/min y values in bounded set
            double maxY = candidatePoints.Max(x => x.YValues.Max());
            //.First());

            double minY = candidatePoints.Min(x => x.YValues.Min());

            double padding = (maxY - minY) * .08;

            // pad max/min y values
            chartStock.ChartAreas[0].AxisY.Maximum = maxY + padding;
            chartStock.ChartAreas[0].AxisY.Minimum = minY - padding;

            var volPoints = allPoints.Where(x => x.XValue >= xmin && x.XValue <= xmax && x.YValues.Count() == 1);

            maxY = volPoints.Max(x => x.YValues.First());



            chartStock.ChartAreas[1].AxisY.Maximum = maxY * 1.05;


        }

        private void chartStock_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                double xmax = this.chartStock.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double xmin = this.chartStock.ChartAreas[0].AxisX.ScaleView.ViewMinimum;

                if (xmax != this.chartStock.ChartAreas[0].AxisX.Maximum || xmin != this.chartStock.ChartAreas[0].AxisX.Minimum)
                {

                    zoomcount--;
                    chartStock.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
                    //chartStock.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
                    //var allPoints = chartStock.Series.SelectMany(x => x.Points);

                    ChartYValues yvals = stockchartyvalues.Pop();
                    chartStock.ChartAreas[0].AxisY.Maximum = yvals.priceymaximum;
                    chartStock.ChartAreas[0].AxisY.Minimum = yvals.priceyminimum;
                    chartStock.ChartAreas[1].AxisY.Maximum = yvals.volumeymaximum;
                    chartStock.ChartAreas[1].AxisY.Minimum = yvals.volumeyminimum;




                    //var candidatePoints = allPoints.Where(x => x.XValue >= xmin && x.XValue <= xmax && x.YValues.Count() == 4); 


                    // get max/min y values in bounded set
                    //double maxY = candidatePoints.Max(x => x.YValues.Max());

                    //double minY = candidatePoints.Min(x => x.YValues.Min());

                    //double padding = (maxY - minY) * .08;

                    // pad max/min y values
                    //chartStock.ChartAreas[0].AxisY.Maximum = maxY + padding;
                    //chartStock.ChartAreas[0].AxisY.Minimum = minY - padding;

                    //var volPoints = allPoints.Where(x => x.XValue >= xmin && x.XValue <= xmax && x.YValues.Count() == 1);

                    //maxY = volPoints.Max(x => x.YValues.First());



                    //chartStock.ChartAreas[1].AxisY.Maximum = maxY * 1.05;
                }

            }
        }

        private void chartStock_AxisViewChanged(object sender, System.Windows.Forms.DataVisualization.Charting.ViewEventArgs e)
        {
            resetYAxis();
        }

        private void comboBoxSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRowView drv = (DataRowView) comboBoxSymbol.SelectedItem;



                if (drv != null)
                {
                    //DataRowView drv = (DataRowView)comboBox1.SelectedItem;
                    //textBox1.Text = drv.Row.ItemArray[0].ToString();
                    // chartStock.DataSource = this.aLLSTOCKDATATableAdapter.GetData(drv.Row.ItemArray[0].ToString());
                    // this.aLLSTOCKDATATableAdapter.Fill(stocksDataSet.ALLSTOCKDATA, drv.Row.ItemArray[0].ToString());

                    //dataGridView1.DataSource = this.aLLSTOCKDATATableAdapter.GetData(drv.Row.ItemArray[0].ToString());
                    //(stocksDataSet.ALLSTOCKDATA, drv.Row.ItemArray[0].ToString());
                    //textBox1.Text = drv.Row.ItemArray[0].ToString();



                    //MessageBox.Show("Selected Item is " + drv.Row.ItemArray[0].ToString());   
                    //this.aLLSTOCKDATATableAdapter.ClearBeforeFill = true;
                    //this.aLLSTOCKDATATableAdapter.FillBySymbol(this.stocksDataSet.ALLSTOCKDATA, drv.Row.ItemArray[0].ToString());
                    chartStock.DataSource = this.aLLSTOCKDATATableAdapter.GetData(drv.Row.ItemArray[0].ToString());
                    chartStock.DataBind();
                    myIndicators.Symbol = drv.Row.ItemArray[0].ToString();
                    if (zoomcount < 0) zoomcount = 0;

                    chartStock.ChartAreas[0].AxisX.ScaleView.ZoomReset(zoomcount);
                    // chartStock.ChartAreas[0].AxisY.ScaleView.IsZoomed = false;
                    //chartStock.ChartAreas[0].Axes.
                    //MessageBox.Show("Stuck here at breakpoint");

                    while (stockchartyvalues.Count > 0)
                        stockchartyvalues.Pop();


                    zoomcount = 0;
                    resetYAxis();
                }



            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(
                    "\nStackTrace ---\n{0}", ex.StackTrace);


            }

            //drv.Delete();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           

            listener.Detach();
            

            Properties.Settings.Default.numberIndicators =(UInt32) myIndicators.Count;
            Properties.Settings.Default.Save();
            
            //removeOldIndicators();
            //writeCurrentIndicators();
            myIndicators.writeIndicators();
        }



        /*
        private void writeCurrentIndicators()
        {
            Properties.Settings.Default.numberIndicators = myIndicators.Count;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\STOCKVIEW", RegistryKeyPermissionCheck.ReadWriteSubTree);
            String ind = "Indicator";
            String indi;

            for (int i = 0; i < myIndicators.Count; i++)
            {
                indi = ind + i.ToString();
                // put in writing of an indicator
                key.SetValue(indi, myIndicators[i].GetIndType);
                myIndicators[i].saveIndicatorDatatoRegistry(i);
            }

        }

        */  
         
         /*
        private void removeOldIndicators()
        {

            int numberToRemove = Properties.Settings.Default.numberIndicators;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\STOCKVIEW", RegistryKeyPermissionCheck.ReadWriteSubTree);
            String ind = "Indicator";
            String indi;

            
            for (int i = 0; i < numberToRemove; i++)
            {
                indi = ind + i.ToString() + "Type";
                indicatorType indType = (indicatorType) key.GetValue(indi);


                switch (indType)
                {
                    case indicatorType.SimpleMovingAverage:
                        SimpleMovingAverage.removeIndicatorDatafromRegistry(i);
                        break;
                    default:
                        break;
                }
                key.DeleteValue(indi);
                
                

            }



        }

        */

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chartStock_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);



            chartStock.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            //chartStock.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);
            HitTestResult result = chartStock.HitTest(e.X, e.Y);

            double xval = chartStock.ChartAreas[0].AxisX.PixelPositionToValue(e.X);

            //float chartpixelwidth = (float)chartStock.Width * (chartStock.ChartAreas[0].InnerPlotPosition.Width)/100;
            //float chartpixelleft = (float) (chartStock.ChartAreas[0].InnerPlotPosition.X)* chartStock.Width /100 + chartStock.Left;
            //double mousepercentxposition = (double) (e.X - chartpixelleft) / chartpixelwidth;
            //Double xval = (double)mousepercentxposition * (chartStock.ChartAreas[0].AxisX.ScaleView.ViewMaximum - chartStock.ChartAreas[0].AxisX.ScaleView.ViewMinimum) + chartStock.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
            //DataPoint pt =   chartStock.Series[0].Points.FindByValue(xval);

            try
            {
                DataPoint pt = chartStock.Series[0].Points.First(x => x.XValue >= xval);
                if (pt != null)
                {
                    //double coercedPosition = chartStock.Series[0].Points.Aggregate((x, y) => Math.Abs(x.XValue - e.X) < Math.Abs(y.XValue - e.Y) ? x : y).XValue;

                    DateTime xpoint = DateTime.FromOADate(pt.XValue);
                    String statusstring = "Date = " + xpoint.ToString("MM/dd/yyyy") + " Open = " + pt.YValues[2].ToString("C2") + ", High = " + pt.YValues[0].ToString("C2");
                    statusstring += ", Low = " + pt.YValues[1].ToString("C2") + ", Close = " + pt.YValues[3].ToString("C2");
                    //   statusStripStockView.Text = statusstring;
                    // statusStripStockView.Refresh();
                    toolStripStatusStockView.Text = statusstring;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Stacktrace: '{0}'", ex.StackTrace);
            }
            
        }
        /*
        private void and200DayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (myIndicators)
            if (EightDayToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                EightDayToolStripMenuItem.Checked = true;
                //if (myIndicators
                //if (myIndicators.Contains()
                if (myIndicators.ContainsType(indicatorType.SimpleMovingAverage))
                {
                    int index = myIndicators.FindIndex(r => r.GetIndType.Equals(indicatorType.SimpleMovingAverage));
                    myIndicators.RemoveAt(index);
                }
                myIndicators.Add(new SimpleMovingAverage());

            }
            else
            {
                int index = myIndicators.FindIndex(r => r.GetIndType.Equals(indicatorType.SimpleMovingAverage));
                myIndicators.RemoveAt(index);
            }

        }
*/


        private void addNewSimpleMovingAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int movavg;
            System.Int64 key = (System.Int64) indicatorType.SimpleMovingAverage << 56;
            
            if (FormAddMovingAverage.Show(out movavg) == true)
            {
                // todo check if simple moving average is in myIndicators and remove, uncheck the 8, 40, 200 day SimpleMovingAverage
                
                if (movavg > 0)
                {
                    key += (System.Int64) movavg;
                    if (!myIndicators.ContainsKey(key))
                    {
                        myIndicators.Add(key, new SimpleMovingAverage(key));
                        // TODO  :  add toolstripmenuitem for new indicator
                    }
                    else
                    {
                        MessageBox.Show(string.Format(  "Simple moving average of {0} is already displayed!", movavg));

                        
                    }
                    
                }
            }
            // TODO  :   add the control functions for new moving average

        }
        



        private void newSMAStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Int64 key = ((System.Int64) indicatorType.SimpleMovingAverage << 56) + 8;
            if (EightDayToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                EightDayToolStripMenuItem.Checked = true;
                //  todo check if already in list/dictionary
                //if (myIndicators
                //if (myIndicators.Contains()
                if (myIndicators.ContainsKey(key))
                //(myIndicators.ContainsType(indicatorType.SimpleMovingAverage))
                {
                    if (!myIndicators.Remove(key))
                        throw new Exception("Indicator not in List");
                }
                myIndicators.Add(key, new SimpleMovingAverage(key));

            }
            else
            {
                EightDayToolStripMenuItem.Checked = false;
                if (myIndicators.ContainsKey(key))
                //(myIndicators.ContainsType(indicatorType.SimpleMovingAverage))
                {
                    if (!myIndicators.Remove(key))
                        throw new Exception("Indicator not in List");
                }
                else throw new Exception("Indicator not in List");

            }
        }






        private void EightDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Int64 key = ((System.Int64) indicatorType.SimpleMovingAverage << 56) + 8;
            if (EightDayToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                EightDayToolStripMenuItem.Checked = true;
                //  todo check if already in list/dictionary
                //if (myIndicators
                //if (myIndicators.Contains()
                if (myIndicators.ContainsKey(key))
                    //(myIndicators.ContainsType(indicatorType.SimpleMovingAverage))
                {
                   if (!myIndicators.Remove(key))
                       throw new Exception("Indicator not in List");
                }
                myIndicators.Add(key, new SimpleMovingAverage(key));

            }
            else
            {
                EightDayToolStripMenuItem.Checked = false;
                if (myIndicators.ContainsKey(key))
                //(myIndicators.ContainsType(indicatorType.SimpleMovingAverage))
                {
                    if (!myIndicators.Remove(key))
                        throw new Exception("Indicator not in List");
                }
                else throw new Exception("Indicator not in List");
                
                }
        }

        private void FortydayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Int64 key = ((System.Int64) indicatorType.SimpleMovingAverage << 56) + 40;
            if (FortyDayToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                FortyDayToolStripMenuItem.Checked = true;
                
                //  todo check if already in list/dictionary
                //if (myIndicators
                //if (myIndicators.Contains()
                if (myIndicators.ContainsKey(key))
                //(myIndicators.ContainsType(indicatorType.SimpleMovingAverage))
                {
                    if (!myIndicators.Remove(key))
                        throw new Exception("Indicator not in List");
                }
                myIndicators.Add(key, new SimpleMovingAverage(key));

            }
            else
            {
                FortyDayToolStripMenuItem.Checked = false;
                if (myIndicators.ContainsKey(key))
                //(myIndicators.ContainsType(indicatorType.SimpleMovingAverage))
                {
                    if (!myIndicators.Remove(key))
                        throw new Exception("Indicator not in List");
                }
                else throw new Exception("Indicator not in List");

            }
        }

        private void TwoHundreddayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Int64 key = ((System.Int64) indicatorType.SimpleMovingAverage << 56) + 200;
            if (TwoHundredDayToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                TwoHundredDayToolStripMenuItem.Checked = true;
                //  todo check if already in list/dictionary
                //if (myIndicators
                //if (myIndicators.Contains()
                if (myIndicators.ContainsKey(key))
                //(myIndicators.ContainsType(indicatorType.SimpleMovingAverage))
                {
                    if (!myIndicators.Remove(key))
                        throw new Exception("Indicator not in List");
                }
                myIndicators.Add(key, new SimpleMovingAverage(key));

            }
            else
            {
                TwoHundredDayToolStripMenuItem.Checked = false;
                if (myIndicators.ContainsKey(key))
                //(myIndicators.ContainsType(indicatorType.SimpleMovingAverage))
                {
                    if (!myIndicators.Remove(key))
                        throw new Exception("Indicator not in List");
                }
                else throw new Exception("Indicator not in List");

            }
        }

        private void indicatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return;
        }



    }
}
