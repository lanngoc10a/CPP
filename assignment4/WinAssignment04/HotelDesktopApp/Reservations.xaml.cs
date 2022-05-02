using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelDesktopApp
{
    /// <summary>
    /// Interaction logic for Reservations.xaml
    /// </summary>
    public partial class Reservations : Window
    {

        private masterEntities dx = new masterEntities();
        public Reservations(masterEntities context)
        {
            InitializeComponent();
            dx = context;
        }
        private void ReservationAdd_Click(object sender, EventArgs e)
        {
            if (ValidateResAdd())
            {
                try
                {

                    AddNewRes(dx);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error making reservation! " + ex);
                }
                finally
                {
                    FirstName.Text = "";
                    LastName.Text = "";
                    RoomSize.Text = "";
                    BedNumber.Text = "";
                    dx.SaveChanges();
                }
            }
        }
        public bool ValidateResAdd()
        {
            if (FirstName.Text != "" && LastName.Text != "" && StartDate.Text != "" && EndDate.Text != "" && RoomSize.Text != "" && BedNumber.Text != "")
            {
                return true;
            }
            Console.WriteLine("Please fill in all required information! ");
            return false;
        }
        public void AddRes(masterEntities context, ReservationTable res)
        {
            dx.ReservationTable.Local.Add(res);
        }

        
        private void AddNewRes(masterEntities context)
        {
            // make a unique resNumb

            List<ReservationTable> resList =  context.ReservationTable.Local.ToList();
            int max = 0; 
            // finding max resNumb value
            foreach (ReservationTable r in resList)
            {
                if (r.ResNumb > max)
                    max =(int) r.ResNumb;
            }

            int resNumb = max+1;
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string dateStart = StartDate.Text;
            string dateEnd = EndDate.Text;
            int roomSize = int.Parse(RoomSize.Text);
            int bedNumber = int.Parse(BedNumber.Text);

            ReservationTable res = new ReservationTable();

            res.ResNumb = resNumb;
            res.FirstName = firstName;
            res.LastName = lastName;
            res.DateStart = dateStart;
            res.DateEnd = dateEnd;
            res.RoomSize = roomSize;
            res.BedNumb = bedNumber;
            res.RoomID = null;

            AddRes(context, res);

        }

        private void ReservationDelete_Click(object sender, EventArgs e)
        {
            
               
            if (ValidateResDelete())
            {
                try
                {
                    int resID = int.Parse(DeleteRes.Text);
                    RemoveRes(dx, resID);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting reservation! " + ex);
                }
                finally
                {
                    DeleteRes.Text = "";
                    dx.SaveChanges();
                }
            }
                
         
        }
        private bool ValidateResDelete()
        {
            if (DeleteRes.Text != "")
            {
                return true;
            }
            Console.WriteLine("Please fill in all required information! ");
            return false;
        }
        private void RemoveRes(masterEntities dx, int resID)
        {
            ReservationTable res = FindRes(resID);
            dx.ReservationTable.Local.Remove(res);
            Console.WriteLine("Deleted resevation: " + resID);
        }


        private ReservationTable FindRes(int resID)
        {
            ReservationTable res;
            res = (ReservationTable)dx.ReservationTable.Local.Where(r=> r.ResID.Equals(resID)).First();

            return res;
        }
    }
}
