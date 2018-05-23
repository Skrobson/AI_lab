using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
namespace ISE_Z1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			graph.GraphPane.Title.IsVisible = false;
		}
		//iloœæ punktów na wykresie
		int pointAmount = 100;
		//generator liczb pseudolosowych
		Random rand = new Random( 1000 );
		//lista punktów wykresu
		PointPairList ppl = new PointPairList();
		//minimum
		PointPairList mppl = new PointPairList();

		//tworzy funkcjê
		private void buttonCreateFunction_Click( object sender, EventArgs e )
		{
			//wyczyœæ listê punktów wykresu i minimum
			ppl.Clear();
			mppl.Clear();
			double previousValue = 0;
			double multip = 0.1;
			int direction = 1;
			for ( int i = 0; i < pointAmount; i++ )
			{
				direction = ( rand.NextDouble() < 0.5 ) ? 1 : -1;
				previousValue += direction * multip * rand.NextDouble();
				PointPair pp = new PointPair( i, previousValue );
				ppl.Add( pp );
			}
			graph.GraphPane.CurveList.Clear();
			graph.GraphPane.AddCurve( "Wykres", ppl, Color.Red, SymbolType.None );
			graph.GraphPane.AddBar( "Znacznik", mppl, Color.Blue );
			graph.GraphPane.AxisChange();
			graph.Invalidate();
			graph.Refresh();
		}

		//uruchmom algorytm
		private void buttonRun_Click( object sender, EventArgs e )
		{
			if ( !backgroundWorker.IsBusy )
			{
				backgroundWorker.RunWorkerAsync();
			}
			else
			{
				backgroundWorker.CancelAsync();
			}
		}

		//szuka minimum
		private void backgroundWorker_DoWork( object sender, DoWorkEventArgs e )
		{
            mppl.Clear();
            bool opad;
            if (ppl[0].Y > ppl[1].Y) opad = true;
            else opad = false;
            for ( int i = 1; i < ppl.Count - 1; i++ )
			{
				if ( ( (BackgroundWorker)sender ).CancellationPending )
				{
					e.Cancel = true;
					break;
				}
                //opadajaca i znalezione minimum
                if ((opad == true) && (ppl[i].Y < ppl[i + 1].Y))
                {
                    mppl.Add(new PointPair(i, ppl[i].Y));
                    opad = false;
                }
                else if ((opad == false) && (ppl[i].Y > ppl[i + 1].Y)) opad = true;
                RefreshGraph();
            }

		}

		private void RefreshGraph()
		{
			if ( graph.InvokeRequired )
			{
				graph.Invoke( new RefreshGraphDelegate( RefreshGraph ) );
			}
			else
			{
				graph.Invalidate();
			}
		}
		private delegate void RefreshGraphDelegate();
	}
}