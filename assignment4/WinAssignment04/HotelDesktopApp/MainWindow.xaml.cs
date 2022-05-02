using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        masterEntities dx = new masterEntities();
        DbSet<ReservationTable> resTable;
        DbSet<HotelRoom> roomTable;
        
        public MainWindow()
        {
            InitializeComponent();
           

            resTable = dx.ReservationTable;
            resTable.Load();
            ResList.DataContext = resTable.Local;


            roomTable = dx.HotelRoom;
            roomTable.Load();
            RoomList.DataContext = roomTable.Local;
        }

        void SaveChanges(masterEntities context)
        {
            context.SaveChanges();
        }
        public void AddRes(masterEntities context, ReservationTable res)
        {
            dx.ReservationTable.Local.Add(res);
        }
        private ReservationTable FindRes(int resID)
        {         
            // if not found, run exception
            return (ReservationTable)dx.ReservationTable.Local.Where(r => r.ResID.Equals(resID)).First();
        }
        private void RemoveRes(masterEntities dx, int resID)
        {
            ReservationTable res = FindRes(resID);
            dx.ReservationTable.Local.Remove(res);
            Console.WriteLine("Deleted resevation: " + resID);
        }

        private void ButtonAddRes_Click(object sender, RoutedEventArgs e)
        {
            new Reservations(dx).ShowDialog();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResList.DataContext = resTable.Local;
        }

        private void CheckIn()
        {
            int resNumb = int.Parse(CheckInResNumb.Text);
            int RoomNumb = int.Parse(CheckInRoomNumb.Text);

            ReservationTable res = (ReservationTable)dx.ReservationTable.Where(r => r.ResNumb == resNumb).First();
            HotelRoom room = (HotelRoom)dx.HotelRoom.Where(hr => hr.roomNumb == RoomNumb).First();

            // Check if(res.HotelRoom isEmpty && room.resTable isEmpty)
            RemoveRes(dx, res.ResID);
            RemoveRoom(dx, room.roomID);

            res.RoomID = room.roomNumb;
            room.resNumb = res.ResNumb;
            room.isUsed = true;

            AddRes(dx, res);
            AddRoom(dx, room);
            CheckInResNumb.Text = "";
            CheckInRoomNumb.Text = "";
            // else{
            // Console.WriteLine("Hotelroom is busy or Reservation already have another room");
            // }
            SaveChanges(dx);
        }

        // Updates the choosen room and Reservation in the local DB
        // puts in the right roomID on the res and the right resID on the room
        private void CheckInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckIn();
            } catch (Exception ex)
            {
               
                Console.WriteLine("Something wrong with Check in! " + ex.Message );
            }
            finally
            {
                CheckInResNumb.Text = "";
                CheckInRoomNumb.Text = "";
            }

        }
        //adds a room to local DB 
        private void AddRoom(masterEntities dx, HotelRoom room)
        {
            dx.HotelRoom.Local.Add(room);
        }
        //removes a roomm from DB 
        private void RemoveRoom(masterEntities dx, int roomID)
        {
            HotelRoom room = FindRoom(roomID);
            dx.HotelRoom.Local.Remove(room);
            Console.WriteLine("Deleted room: " + roomID);
            SaveChanges(dx);
        }
        // finds a room with roomID 
        private HotelRoom FindRoom(int roomID)
        {
            // If not found, run exception
            return dx.HotelRoom.Local.Where(r => r.roomID.Equals(roomID)).First();
        }
        
        private void CheckOut()
        {
            int resNumb = int.Parse(CheckOutResNumb.Text);
            //if( findRes!=null)
            ReservationTable res = dx.ReservationTable.Local.Where(r => r.ResNumb.Equals(resNumb)).First();
            int resID = res.ResID;
            int roomID = (int)res.RoomID;

            RemoveRes(dx, resID);


            HotelRoom room = dx.HotelRoom.Local.Where(hr => hr.resNumb == resNumb).First();
            RemoveRoom(dx, room.roomID);

            // Cleaningstatus = 2, dirty
            // Cleaningstatus = 1, currently cleaning
            // Cleaningstatus = 0, Clean
            room.cleaningStatus = 2;

            room.isUsed = false;
            room.resNumb = null;
            AddRoom(dx, room);
            CheckOutResNumb.Text = "";
            SaveChanges(dx);
        }
        
        // updates the local DB with the choosen res and room
        // updates so that the resID is removed from the room 
        // and the res is removed from the DB
        private void CheckOutButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                CheckOut();
            }catch (Exception ex)
            {
                Console.WriteLine("Something wrong with check out! " + ex.Message);
            }
            finally
            {
                CheckOutResNumb.Text = ""; 
            }
       
        }
    }


    
}
