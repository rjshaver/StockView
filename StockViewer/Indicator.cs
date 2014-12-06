using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockViewer
{
    public enum indicatorType {

            AccumulationDistribution=0, AverageTrueRange=1,
            BollingerBands=2, ChaikinOscillator=3, CommodityChannelIndex=4, DetrendedPriceOscillator=5, EaseOfMovement=6, Envelopes=7, Forecasting=8, MassIndex=9,
            SimpleMovingAverage=10, ExponentialMovingAverage=11, TriangularMovingAverage=12, TripleExponentialMovingAverage=13, WeightedMovingAverage=14,
            MoneyFlow=15, MovingAverageConvergenceDivergence=16, NegativeVolumeIndex=17, OnBalanceVolume=18, Performance=19, PositiveIndexVolume=20,
            MedianPrice=21, TypicalPrice=22, WeightedClose=23, PriceVolumeTrend=24, RateOfChange=25, RelativeStrengthIndex=26, StandardDeviation=27, StochasticIndicator=28,
            VolatilityChaikins=29, VolumeOscillator=30, WilliamsR=31
        }


    public struct ChartYValues
    {
        public double priceymaximum;
        public double priceyminimum;
        public double volumeymaximum;
        public double volumeyminimum;
    }


    interface IIndicating
    {
        //abstract public static void getIndicatorDatafromRegistry(int i);
        void saveIndicatorDatatoRegistry(int i);
        //abstract public static void removeIndicatorDatafromRegistry(int i);
        void chartData(Chart ch);
        void removeChartData(Chart ch);
        //void recalcData(Chart ch);


    }

    abstract class Indicator: IIndicating, IDisposable
    {

        public static String[] stringIndicatorType = {
                "AccumulationDistribution", "AverageTrueRange",
            "BollingerBands", "ChaikinOscillator", "CommodityChannelIndex", "DetrendedPriceOscillator", "EaseOfMovement", "Envelopes", "Forecasting", "MassIndex",
            "SimpleMovingAverage", "ExponentialMovingAverage", "TriangularMovingAverage", "TripleExponentialMovingAverage", "WeightedMovingAverage",
            "MoneyFlow", "MovingAverageConvergenceDivergence", "NegativeVolumeIndex", "OnBalanceVolume", "Performance", "PositiveIndexVolume",
            "MedianPrice", "TypicalPrice", "WeightedClose", "PriceVolumeTrend", "RateOfChange", "RelativeStrengthIndex", "StandardDeviation", "StochasticIndicator",
            "VolatilityChaikins", "VolumeOscillator", "WilliamsR"

        };


        protected static UInt64 _seriesCounter = 0;

        private indicatorType _type;
        protected string _SeriesName;
       
        //todo add a Series to add to the chart
        protected Series _dataSeries;
        private System.Int64 _key;
        


        

        public Indicator()
        {
            // TODO: Complete member initialization
            _SeriesName = "Indicator" + _seriesCounter++.ToString();
            _dataSeries = new Series(_SeriesName);
        }

        public Indicator(System.Int64 key)
        {
            _SeriesName = "Indicator" + _seriesCounter++.ToString();
            _dataSeries = new Series(_SeriesName);
            Key = key;

        }

        public indicatorType GetIndType
        {
            get { return _type; }
            set { _type = value; }
        }

        public System.Int64 Key
        {
            get { return _key;  }
            set { _key = value; }
        }


        
        

        #region IIndicating Members

        public void saveIndicatorDatatoRegistry(int i)
        {
            string ind = "Indicator" + i.ToString();
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\STOCKVIEW", RegistryKeyPermissionCheck.ReadWriteSubTree);
           
            rkey.SetValue(ind, this.Key, RegistryValueKind.QWord);

            //TODO throw new NotImplementedException();
        }

        public virtual void chartData(Chart ch)
        {
            //throw new NotImplementedException();
        }

        public virtual void removeChartData(Chart ch)
        {
            //throw new NotImplementedException();
        }

        #endregion

        #region IIndicating Members

        /*
        public virtual void recalcData(Chart ch)
        {
            //throw new NotImplementedException();
        }
*/
        #endregion

        #region IDisposable Members

        public void Dispose()
        {

            if (this._key == 0x0A00000000000008)
            {
                
            }
            _dataSeries.Dispose();
            //throw new NotImplementedException();
        }

        #endregion
    }

   
    
    
    class SimpleMovingAverage:Indicator{
        private int _average;

        public int Average
        {
            get { return _average; }
            set { _average = value; }
        }


        public SimpleMovingAverage ():this(8)   {   }


        public SimpleMovingAverage(int n):base()
        {
            GetIndType = indicatorType.SimpleMovingAverage;
            Average = n;
            System.Int64 newkey;

            newkey = (System.Int64)GetIndType;
            newkey = newkey << 56;
            newkey += (System.Int64)n;
            Key = newkey;
            //_dataSeries.ChartType = SeriesChartType.Line;
            

        }

        public SimpleMovingAverage(System.Int64 key):base(key)
        {
            GetIndType = indicatorType.SimpleMovingAverage;
            Key = key;
            Average = (int)(key  &  0x00ffffffffffffff);
            //_dataSeries.ChartType = SeriesChartType.Line;
        }

        // TODO move and reformat chartdata and recalcdata



        // TODO implement chartdata and removechartdata
        public override void chartData(Chart ch) {
           // _dataSeries = null;
           // _dataSeries = new Series(_SeriesName);
            //_dataSeries.
            if (!ch.Series.Contains(_dataSeries))
                ch.Series.Add(_dataSeries);
            ch.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, Average.ToString(), ch.Series["SeriesPrice"].Name.ToString()+ ":Y3"  , _SeriesName + ":Y");



            ch.Series[_SeriesName].ChartType = SeriesChartType.Line;
            // TODO Copy x values from SeriesPrice
            //_dataSeries.XValueType = ChartValueType.Date;
           // _dataSeries.XValueMember = ch.Series["SeriesPrice"].XValueMember;
            //_dataSeries.ChartArea = ch.ChartAreas["ChartAreaPrice"].Name.ToString();
         //   _dataSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            
            //_dataSeries.ChartArea = ch.ChartAreas[0].Name.ToString();
           
            //_dataSeries.YValuesPerPoint = 1;
            //ch.Series.Add(_dataSeries);
            
            /*
            series9.ChartArea = "ChartAreaPrice";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series9.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series9.IsVisibleInLegend = false;
            series9.Name = "SeriesPrice";
            series9.XValueMember = "DATE";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series9.YValueMembers = "HIGH, LOW, OPEN, CLOSE";
            series9.YValuesPerPoint = 4;
            */
            
        //    throw new NotImplementedException(); 
        }


        /*
        public override void recalcData(Chart ch)
        {
            _dataSeries = null;
            _dataSeries = new Series();
            
            ch.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, Average.ToString(), ch.Series["SeriesPrice"].Name.ToString() + ":Y3", _dataSeries.ToString() + ":Y");

            _dataSeries.ChartArea = ch.ChartAreas[0].Name.ToString();
            _dataSeries.ChartType = SeriesChartType.Line;
            ch.Series.Add(_dataSeries);
            

        }
        */

        public override void removeChartData(Chart ch) {
            if (ch.Series.Contains(_dataSeries))
            {
                ch.Series.Remove(ch.Series[_SeriesName]);
            }
            
                //(_dataSeries);
            //_dataSeries = null;
          //  throw new NotImplementedException(); 
        }
        
        
        
        
        /*
        public static void getIndicatorDatafromRegistry(int i, out int ave)
        {
            ave = new int();
            //throw new NotImplementedException();
            string ind = "Indicator" + i.ToString();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\STOCKVIEW", RegistryKeyPermissionCheck.ReadWriteSubTree);

            //for (int k = 0; k < 4; k++)
            //{
            string indi = ind + "ave";// +k.ToString();
                ave = (int) key.GetValue( indi);
                

            //}
            //string IndicatorString = (string)key.GetValue("Indicator1Type");
            
        }
        */

        /*
        public override void saveIndicatorDatatoRegistry(int i)
        {
            //throw new NotImplementedException();
            
            string ind = "Indicator" + i.ToString();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\STOCKVIEW", RegistryKeyPermissionCheck.ReadWriteSubTree);
            key.SetValue(ind + "Type", indicatorType.SimpleMovingAverage);
            //for (int k = 0; k < 4; k++)
            //{
                string indi = ind + "ave";// + k.ToString();
                key.SetValue(indi, this.average);


           // }
            
            
            //key.SetValue("Indicator1Type",Indicator.stringIndicatorType[(int)indicatorType.SimpleMovingAverage]);
        }
        */

        /*
        public static void removeIndicatorDatafromRegistry(int i)
        {
            //throw new NotImplementedException();
            string ind = "Indicator" + i.ToString();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\STOCKVIEW", RegistryKeyPermissionCheck.ReadWriteSubTree);

            //for (int k = 0; k < 4; k++)
            //{
                string indi = ind + "ave";// + k.ToString();
                key.DeleteValue(indi);  


            //}//
            

            //key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\STOCKVIEW", RegistryKeyPermissionCheck.ReadWriteSubTree);

            //key.DeleteValue("NotificationStatus");
            //key.SetValue("Indicator1Type",Indicator.stringIndicatorType[(int)indicatorType.SimpleMovingAverage]);
        }
*/

    }


}
