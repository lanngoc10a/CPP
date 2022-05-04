using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceApp1
{
    public partial class Form2 : Form
    {
        masterEntities dx;
        private int roomNumber;
        public Form2(masterEntities context, int roomNumb)
        {

            InitializeComponent();
            dx = context;
            try
            {        
                
                HotelRoom room = dx.HotelRoom.Local.Where(h => h.roomNumb == roomNumb).First();
                roomNumber = roomNumb;
                if(!room.taskNotes.Equals("") || !(room.taskNotes == null))
                textBox1.Text = room.taskNotes.ToString();
                else
                {
                    textBox1.Text = "";
                }

            } catch (Exception ex)
            {
                Console.WriteLine("Error in Form2: " + ex.Message);
            }




        }

        private void SaveTextButton_Click(object sender, EventArgs e)
        {
            string saveText = textBox1.Text;

           HotelRoom room =  dx.HotelRoom.Local.Where(h => h.roomNumb == roomNumber).First();
           dx.HotelRoom.Remove(room);
           dx.SaveChanges();

            room.taskNotes = saveText;
            dx.HotelRoom.Local.Add(room);
            dx.SaveChanges();

            Close();
        }
    }
}
