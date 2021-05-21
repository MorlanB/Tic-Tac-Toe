using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        #region global variables
        bool turn;
        Button[,] buttons;
        #endregion

        #region Constructors
        /// <summary>
        /// Forma de juego de gato.
        /// </summary>
        public TicTacToe()
        {
            InitializeComponent();
        }
        #endregion

        #region Graphic interface methods
        /// <summary>
        /// Se ejecuta al cargar la interfaz gráfica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = new Button[,]
            {
                { a1, b1, c1 },
                { a2, b2, c2 },
                { a3, b3, c3 }
            };

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].FlatAppearance.BorderSize = 0;
                    buttons[i, j].Click += (sender1, e1) =>
                    {
                        string winner;
                        Button boton = ((Button)sender1);
                        boton.Text = turn ? "X" : "O";
                        boton.ForeColor = turn ? Color.FromArgb(255,100,90) : Color.SpringGreen;
                        boton.Font = new Font(boton.Font.Name, 50);

                        if (HasWon())
                        {
                            winner = boton.Text;
                            MessageBox.Show("Player * has won".Replace("*", boton.Text));
                            ClearTable();
                        }
                        turn = !turn;
                    };
                }
        }

        /// <summary>
        /// Resetea la tabla desde botón.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ClearTable();
        }
        #endregion

        #region Business methods
        /// <summary>
        /// Resetea la tabla.
        /// </summary>
        private void ClearTable()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                }
        }

        /// <summary>
        /// Verifica que el usuario ha ganado iterando sobre un tablero de coordenadas de los botones del gato.
        /// </summary>
        /// <returns> bool hasWon : valor que indica si se ha ganado o no. </returns>
        private bool HasWon()
        {
            //Contiene un arreglo de X y un arreglo de Y indicando las posibles combinaciones para ganar.
            int[,] indices = new int[,]
           {
                { 0, 0, 0, 1, 1, 1, 2, 2, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 2, 1, 0 },
                { 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 0, 0, 1, 1, 1, 2, 2, 2, 0, 1, 2, 0, 1, 2 }
           };
            
            bool hasWon = false;
            for (int ind = 0; ind < 24; ind += 3)
            {
                if( (buttons[indices[0,ind], indices[1, ind]].Text.Equals(buttons[indices[0, ind + 1], indices[1, ind + 1]].Text) &&
                    buttons[indices[0, ind], indices[1, ind]].Text.Equals(buttons[indices[0, ind + 2], indices[1, ind + 2]].Text)) &&
                     !String.IsNullOrEmpty(buttons[indices[0,ind], indices[1,ind]].Text) )
                {
                    hasWon = true;
                    break;
                }
            }
            return hasWon;
        }
        #endregion

    }
}
