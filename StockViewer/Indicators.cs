using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockViewer
{

    public delegate void ChangedEventHandler(object sender, EventArgs e);
    public delegate void ChangingEventHandler(object sender, EventArgs e);
    public delegate void StockChangedEventHander(object sender, EventArgs e);

        class Indicators : SortedList<System.Int64, Indicator>
        {
            Chart stockChart;
            private String _symbol;
            protected int numberofSeriesAvailable = 5;
           // static private Queue<String> _seriesNames;
           // private UInt64 _seriesNamesCount = 0;
            
            public int NumberOfIndicators
            {
                get { return this.Count; }
                //set { _numberOfIndicators = value; }
            }

            public String Symbol
            {
                set
                {
                    OnChanging( EventArgs.Empty);
                    _symbol = value;
                    OnStockChanged( EventArgs.Empty);
                }
            }
/*
            static public String GetSeriesName()
            {
                if (_seriesNames.Count < 1)
                {
                    for (int i=0; i < 5;i++)
                        _seriesNames.Enqueue("Indicator" + _seriesNamesCount++.ToString());
                }
                return _seriesNames.Dequeue();
            }
            */
            public Chart StockChart
            {
                get { return stockChart; }
            }

            public new void Add(System.Int64 key, Indicator i)
            {
                OnChanging(EventArgs.Empty);
                base.Add(key, i);
                OnChanged( EventArgs.Empty);
                //return 1;

            }

            public new bool Remove(System.Int64 key)
            {
                bool result;

                OnChanging( EventArgs.Empty);
                result = base.Remove(key);
                OnChanged( EventArgs.Empty);
                return result;
            }

            // An event that clients can use to be notified whenever the
            // elements of the list change.
            public event ChangedEventHandler Changed;
            public event ChangingEventHandler Changing;
            public event StockChangedEventHander StockChanged;

            // Invoke the Changed event; called whenever list changes
            protected virtual void OnChanged(EventArgs e)
            {
                if (Changed != null)
                    Changed(this, e);
            }


            protected virtual void OnChanging(EventArgs e)
            {
                if (Changing != null)
                    Changing(this, e);
            }


            protected virtual void OnStockChanged(EventArgs e)
            {
                if (StockChanged != null)
                    StockChanged(this, e);
            }

            public Indicators(Chart ch)
            {
                stockChart = ch;
             /*   _seriesNames = new Queue<string>();
                if (_seriesNames.Count == 0){
                    for (int i = 0; i< 50; i++){
                        _seriesNames.Enqueue("Indicator" +  _seriesNamesCount++.ToString());
                        
                    }
                }*/
            }


            


            public void readIndicators(UInt32 num)
            {

                String IndicatorDataReader;

                for (int i = 0; i < num; i++)
                {
                    IndicatorDataReader = "Indicator" + i.ToString();
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\STOCKVIEW", RegistryKeyPermissionCheck.ReadWriteSubTree);
                    if (key.ValueCount > 0)
                    {
                        
                        object ind = key.GetValue(IndicatorDataReader);
                            
                            //key.GetValueKind()
                            //(IndicatorDataReader);
                        //key.GetValue(IndicatorDataReader);
                        key.DeleteValue(IndicatorDataReader);
                        System.Int64 indu = (System.Int64) ind;
                        System.Int64 indminussize = ((System.Int64) ind) >> 56;
                        indicatorType indType = (indicatorType) indminussize;
                        
                        switch (indType)
                        {
                            case indicatorType.SimpleMovingAverage:
                                this.Add(indu, new SimpleMovingAverage(indu));
                                break;

                            default: break;
                        }
                    }
                    
                    

                }
                //throw new NotImplementedException();
            }


            public void writeIndicators()
            {
              
                for (int i = 0; i < this.Count; i++)
                {
                    this.Values[i].saveIndicatorDatatoRegistry(i);
                
                }
                
            }

        }

        class EventListener
        {
            private Indicators List;

            public EventListener(Indicators list)
            {
                List = list;
                // Add "ListChanged" to the Changed event on "List".
                List.Changed += new ChangedEventHandler(ListChanged);
                List.Changing += new ChangingEventHandler(ListChanging);
                List.StockChanged += new StockChangedEventHander(StockChanged);
            }

    

            // This will be called whenever the list changes.
            private void ListChanged(object sender, EventArgs e)
            {

                // TODO write the code for adding or removing an Indicator
                //Console.WriteLine("This is called when the event fires.");
                if (List.Count > 0)
                {
                    foreach (Indicator i in List.Values)
                    {
                        i.chartData(List.StockChart);
                        //i.removeChartData(List.StockChart);
                    }
                }
            }

            private void ListChanging(object sender, EventArgs e)
            {
                if (List.Count > 0)
                {
                    foreach (Indicator i in List.Values)
                    {
                        i.removeChartData(List.StockChart);
                    }
                }
            }


            private void StockChanged(object sender, EventArgs e)
            {
                if (List.Count > 0)
                {
                    foreach (Indicator i in List.Values)
                    {
                        i.chartData(List.StockChart);
                        //i.recalcData(List.StockChart);
                    }
                }
            }

            public void Detach()
            {
                // Detach the event and delete the list
                List.Changed -= new ChangedEventHandler(ListChanged);
                List.Changing -= new ChangingEventHandler(ListChanging);
                List.StockChanged -= new StockChangedEventHander(StockChanged);
                List = null;
            }
        }




 
}
