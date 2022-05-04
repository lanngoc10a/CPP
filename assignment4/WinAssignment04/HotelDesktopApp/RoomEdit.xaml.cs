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
using System.Windows.Shapes;

namespace HotelDesktopApp
{
    /// <summary>
    /// Interaction logic for RoomEdit.xaml
    /// </summary>
    public partial class RoomEdit : Window
    {
        masterEntities dx;
        HotelRoom room;

        DbSet<HotelRoom> roomList;
        DbSet<Tasks> taskList;

        public RoomEdit(masterEntities context, int roomNumb)
        {
            InitializeComponent();
            dx = context;
            room = dx.HotelRoom.Where(r => r.roomNumb == roomNumb).First();
          
            RoomNumbLabel.Content ="Room number: " + roomNumb;

            roomList = dx.HotelRoom;
            taskList = dx.Tasks;
            CheckBoxValues(CleaningBox, (bool)room.cleaningStatus);
            CheckBoxValues(ServiceBox, (bool)room.service);
            CheckBoxValues(MaintenanceBox, (bool)room.maintenance);
            TaskNotesTextbox.Text = room.taskNotes;
        }

        private void CheckBoxValues(CheckBox checkBox, bool value)
        {
            if (value)
            {
                checkBox.IsChecked =  true;
            }
            else
            {
                checkBox.IsChecked = false;
            }
        }

        private void UpdateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateTasks();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not find a task in tasklist" + ex.Message);
                MakeNewTaskAndUpdateTasks();

                Console.WriteLine("A new task was added to Tasks!");

            }
            finally
            {
                UpdateResList();
                Close();
            }

        }

        private void UpdateResList()
        {
            roomList.Remove(room);
            dx.SaveChanges();

            roomList.Add(room);
            dx.SaveChanges();
        }

        public void MakeNewTaskAndUpdateTasks()
        {
            Tasks task = new Tasks();
            task.roomNumb = room.roomNumb;
            task.cleaningStatus = (bool)room.cleaningStatus;
            task.maintenance = (bool)room.maintenance;
            task.roomService = (bool)room.service;
            task.taskStatus = "New";

            room.taskNotes = TaskNotesTextbox.Text;

            taskList.Add(task);
            dx.SaveChanges();

        }

        public void UpdateTasks()
        {
            Tasks task = taskList.Local.Where(t => t.roomNumb == room.roomNumb).First();

            taskList.Remove(task);
            dx.SaveChanges();

            task.cleaningStatus = (bool)room.cleaningStatus;
            task.roomService = (bool)room.service;
            task.maintenance = (bool)room.maintenance;

            room.taskNotes = TaskNotesTextbox.Text;

            taskList.Add(task);
            dx.SaveChanges();
        }

        private void CleaningBox_Checked(object sender, RoutedEventArgs e)
        {
            room.cleaningStatus = true;
        }

        private void CleaningBox_Unchecked(object sender, RoutedEventArgs e)
        {
            room.cleaningStatus = false;
        }

        private void ServiceBox_Checked(object sender, RoutedEventArgs e)
        {
            room.service = true;
        }

        private void ServiceBox_Unchecked(object sender, RoutedEventArgs e)
        {
            room.service = false;
        }

        private void MaintenanceBox_Checked(object sender, RoutedEventArgs e)
        {
            room.maintenance = true;
        }

        private void MaintenanceBox_Unchecked(object sender, RoutedEventArgs e)
        {
            room.maintenance = false;
        }
    }
}
