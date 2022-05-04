using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceApp1
{
    public partial class Form1 : Form
    {
        masterEntities dx = new masterEntities();
        DbSet<Tasks> taskList;
        DbSet<HotelRoom> roomList;
        public Form1()
        {
            InitializeComponent();
            roomList = dx.HotelRoom;
            roomList.Load();
            taskList = dx.Tasks;
            taskList.Load();
  
        }
        void ShowTasklist()
        {
            dataGridView1.DataSource = taskList.Local;
        }
        void ShowTasklistCleaning()
        {
            dataGridView1.DataSource = taskList.Local.Where(t => t.cleaningStatus == true).ToList();
        }
        void ShowTasklistService()
        {
            dataGridView1.DataSource = taskList.Local.Where(t => t.roomService == true).ToList();
        }
        void ShowTasklistMaintenance()
        {
            dataGridView1.DataSource = taskList.Local.Where(t => t.maintenance == true).ToList();
        }
        private void checkBoxCleaning_Clicked(object sender, EventArgs e)
        {
           
            checkBoxService.CheckState = CheckState.Unchecked;
            checkBoxMaintenance.CheckState = CheckState.Unchecked;
            ShowTasklistCleaning();
            if(checkBoxCleaning.CheckState == CheckState.Unchecked)
            {
                ShowTasklist();
               
            }
        }
       

        private void checkBoxService_Clicked(object sender, EventArgs e)
        {
            
            checkBoxCleaning.CheckState = CheckState.Unchecked;
            checkBoxMaintenance.CheckState = CheckState.Unchecked;
            ShowTasklistService();

            if (checkBoxService.CheckState == CheckState.Unchecked)
            {
                ShowTasklist();
            }
        }

        private void checkBoxMaintenance_Clicked(object sender, EventArgs e)
        {
           
            checkBoxService.CheckState = CheckState.Unchecked;
            checkBoxCleaning.CheckState = CheckState.Unchecked;
            ShowTasklistMaintenance();
           
            if (checkBoxMaintenance.CheckState == CheckState.Unchecked)
            {
                ShowTasklist();
            }
        }
       void StatusClick(DataGridViewTextBoxCell cell)
        {
            if (cell.Value.Equals("New"))
            {
                cell.Value = "InProgress";
            }
            else if (cell.Value.Equals("InProgress"))
            {
                cell.Value = "Finished";
            }
            else if (cell.Value.Equals("Finished"))
            {
                cell.Value = "New";
            }
            else
            {
                Console.WriteLine("Invalid value in cellClick!!");
            }
            dx.SaveChanges();
        }
        void CheckBoxClick(DataGridViewCheckBoxCell cell)
        {
            if (cell.Value.Equals(false))
            {
                cell.Value = true;
            } else
            {
                cell.Value = false;
            }
            
        }
        private void dataGridView1_CellClick2(object sender, DataGridViewCellEventArgs e) {
            try
            {
                DataGridViewCheckBoxCell cell =
               (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                CheckBoxClick(cell);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("CellClick went wrong!");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewTextBoxCell cell =
               (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (e.ColumnIndex.Equals(5))
                {
                    StatusClick(cell);
                }

               
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("CellClick went wrong!");
            }
            }
        private void clearTaskList()
        {
            
                List<Tasks> clearList = taskList.Local.Where(t => t.cleaningStatus.Equals(false) && (t.maintenance.Equals(false)) && (t.roomService.Equals(false))).ToList();
                foreach (Tasks t in clearList)
                {
                    if (t.taskStatus.Equals("Finished"))
                    {
                        Console.WriteLine("Task : " + t.taskID.ToString() + " has been deleted!");
                        taskList.Remove(t);
                        
                }
                }
            dx.SaveChanges();
        }

        void ShowCorrectTaskList()
        {
            if (checkBoxCleaning.Checked)
            {
                Console.WriteLine("Show cleaning tasks!");
                ShowTasklistCleaning();
            }
            else if (checkBoxService.Checked)
            {
                Console.WriteLine("Show service tasks!");
                ShowTasklistService();
            }
            else if (checkBoxMaintenance.Checked)
            {
                Console.WriteLine("Show maintenance tasks!");
                ShowTasklistMaintenance();
            }
            else
            {
                Console.WriteLine("Show all tasks!");
                ShowTasklist();
            }
        }
        void SetCorrectStatus()
        {
            
            foreach(Tasks t in taskList)
            {
                if(t.cleaningStatus.Equals(true) || (t.maintenance.Equals(true)) || (t.roomService.Equals(true)))
                {
                    t.taskStatus = "New";
                }
            }
        }
        void UpdateHotelRoom()
        {
            List<HotelRoom> tempRoomList = new List<HotelRoom>();

            foreach(Tasks t in taskList)
            {
                HotelRoom room = roomList.Local.Where(r => r.roomNumb == t.roomNumb).First();
                tempRoomList.Add(room);
                roomList.Remove(room);               
            }
            dx.SaveChanges();
            foreach (Tasks t in taskList)
            {
                HotelRoom room = tempRoomList.Where(r => r.roomNumb == t.roomNumb).First();

                room.cleaningStatus = t.cleaningStatus;
                room.service = t.roomService;
                room.maintenance = t.maintenance;
                roomList.Add(room);     
            }
            dx.SaveChanges();
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {                            
                UpdateHotelRoom();
                clearTaskList();
                SetCorrectStatus();
                ShowCorrectTaskList();
                dx.SaveChanges();
                  
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateButton error : " + ex.Message);
            }
        }
        bool HotelRoomExist(int roomNumb)
        {
            try
            {
                dx.HotelRoom.Local.Where(h => h.roomNumb == roomNumb).First();
                return true;

            }catch (Exception ex)
            {
                Console.WriteLine("Invalid Room number! " + ex.Message);
                return false;   
            }
        }
        private void AddTextButton_Click(object sender, EventArgs e)
        {
            if (!roomNumbText.Text.Equals(""))
            {
                int roomNumb = int.Parse(roomNumbText.Text);
                // check if roomnumb.text exist in HotelRoom
                if (HotelRoomExist(roomNumb))
                    new Form2(dx, roomNumb).ShowDialog();
            }
         
        }
    }
}
