using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using SharpGL.SceneGraph.Lights;

namespace ISE_Z2
{
	public partial class Form1 : Form
	{
		//rozmiar siatki
		int size = 100;
		//wysokoœæ punktów siatki
		double[][] heightArray;

		public Form1()
		{
			InitializeComponent();
			heightArray = new double[ size ][];

			for ( int i = 0; i < size; i++ )
			{
				heightArray[ i ] = new double[ size ];
				for ( int j = 0; j < size; j++ )
				{
					heightArray[ i ][ j ] = 0;
				}
			}
		}
		//generator liczb losowych
		Random rand = new Random();

		//odleg³oœæ kamery 
		float tz = -90;
		//rotacja wzglêdem osi x
		float rotX = -80;
		//rotacja wzglêdem osi z
		float rotZ = 0;

		//wspó³rzêdne minimum
		int minX = 50;
		int minY = 50;

        //minimum na plaszczyznie
        double min = 0;
        int mx = 0;
        int my = 0;

		#region opengl
		//rysowanie siatki
		private void openGLControl1_OpenGLDraw( object sender, PaintEventArgs e )
		{

			SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
			gl.Clear( OpenGL.COLOR_BUFFER_BIT | OpenGL.DEPTH_BUFFER_BIT );

			gl.LoadIdentity();
			gl.Translate( 0, 0, tz );
			gl.Rotate( rotX, 1, 0, 0 );
			gl.Rotate( rotZ, 0, 0, 1 );


			gl.Begin( OpenGL.TRIANGLES );
			gl.Color( 1, 0, 0, 1 );
			int multt = 1;
			gl.Vertex( ( minY - ( heightArray.Length / 2 ) ) * multt, ( minX - ( heightArray.Length / 2 ) ) * multt, heightArray[ minY ][ minX ] );
			gl.Vertex( ( minY - ( heightArray.Length / 2 ) ) * multt, ( minX + 1 - ( heightArray.Length / 2 ) ) * multt, heightArray[ minY + 1 ][ minX ] );
			gl.Vertex( ( minY + 1 - ( heightArray.Length / 2 ) ) * multt, ( minX - ( heightArray.Length / 2 ) ) * multt, heightArray[ minY ][ minX + 1 ] );

			gl.End();

			gl.Color( 1, 1, 1, 1 );
			gl.Begin( OpenGL.LINES );
			for ( int i = 0; i < heightArray.Length - 1; i++ )
			{
				for ( int j = 0; j < heightArray[ 0 ].Length - 1; j++ )
				{
					DrawTriangle( gl, i, j );
				}
			}
			gl.End();
		}

		//rysuje trójk¹ty
		private void DrawTriangle( SharpGL.OpenGL gl, int i, int j )
		{
			gl.Vertex( j - ( heightArray.Length / 2 ), i - ( heightArray.Length / 2 ), heightArray[ i ][ j ] );
			gl.Vertex( j - ( heightArray.Length / 2 ), i + 1 - ( heightArray.Length / 2 ), heightArray[ i + 1 ][ j ] );

			gl.Vertex( j - ( heightArray.Length / 2 ), i + 1 - ( heightArray.Length / 2 ), heightArray[ i + 1 ][ j ] );
			gl.Vertex( j + 1 - ( heightArray.Length / 2 ), i - ( heightArray.Length / 2 ), heightArray[ i ][ j + 1 ] );

			gl.Vertex( j + 1 - ( heightArray.Length / 2 ), i - ( heightArray.Length / 2 ), heightArray[ i ][ j + 1 ] );
			gl.Vertex( j - ( heightArray.Length / 2 ), i - ( heightArray.Length / 2 ), heightArray[ i ][ j ] );
		}
		#endregion

		//tworzy siatkê
		private void buttonCreate_Click( object sender, EventArgs e )
		{
			int x;
			int y;
			int direction = 1;
			double value = 0;
			int impact = 0;
			for ( int i = 0; i < 20000; i++ )
			{
				y = rand.Next( heightArray.Length );
				x = rand.Next( heightArray[ y ].Length );
				direction = ( rand.NextDouble() < 0.5 ) ? 1 : -1;
				value = rand.NextDouble();
				impact = rand.Next( 100 );
				ChangeHeight( x, y, direction, value, impact );
			}
            label1.Text = "Min: " + min;
            label2.Text = "W punkcie P(" + mx + "," + my + ").";
		}

		#region przesuwanie obroty itp.
		private void ChangeHeight( int x, int y, int direction, double value, int impact )
		{
			heightArray[ x ][ y ] += direction * value;
            if (heightArray[x][y] < min)
            {
                min = heightArray[x][y];
                mx = x;
                my = y;
            }
        }

		private void button1_Click( object sender, EventArgs e )
		{
			rotX += 5;
		}

		private void button2_Click( object sender, EventArgs e )
		{
			rotX -= 5;
		}

		private void button5_Click( object sender, EventArgs e )
		{
			heightArray[ 50 ][ 50 ] = 100;
		}

		private void buttonApp_Click( object sender, EventArgs e )
		{
			tz += 5;
		}

		private void buttonOut_Click( object sender, EventArgs e )
		{
			tz -= 5;
		}

		private void buttonRight_Click( object sender, EventArgs e )
		{
			rotZ += 5;
		}

		private void buttonLeft_Click( object sender, EventArgs e )
		{
			rotZ -= 5;
		}
		#endregion

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

		private void backgroundWorker_DoWork( object sender, DoWorkEventArgs e )
		{

		}


	}
}