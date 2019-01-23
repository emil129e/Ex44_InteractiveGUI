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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        Controller controller = Controller.GetInstance();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewPerson_Click(object sender, RoutedEventArgs e)
        {
            
            BoolIsEnabled(true);
            controller.AddPerson();
            ClearTextBox();
            CountPersons();
            
        }

        private void Firstname_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.FirstName = Firstname_Textbox.Text;
        }

        private void Lastname_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.LastName = Lastname_Textbox.Text;
        }

        private void Age_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Age_Textbox.Text == "")
            {
                controller.CurrentPerson.Age = 0;
            }
            else
            {
                controller.CurrentPerson.Age = int.Parse(Age_Textbox.Text); 
            }
        }

        private void TelephoneNo_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.TelephoneNo = TelephoneNo_Textbox.Text;
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
            controller.DeletePerson();
            CountPersons();
            if (controller.PersonCount == 0)
            {                
                BoolIsEnabled(false);
            }
            else
            {
                GetCurrentPerson();
            }
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            controller.NextPerson();
            GetCurrentPerson();
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            controller.PrevPerson();
            GetCurrentPerson();
        }
        private void GetCurrentPerson()
        {
            Firstname_Textbox.Text = controller.CurrentPerson.FirstName;
            Lastname_Textbox.Text = controller.CurrentPerson.LastName;
            Age_Textbox.Text = controller.CurrentPerson.Age.ToString();
            TelephoneNo_Textbox.Text = controller.CurrentPerson.TelephoneNo;
        }
        private void ClearTextBox()
        {
            Firstname_Textbox.Text = "";
            Lastname_Textbox.Text = "";
            Age_Textbox.Text = "";
            TelephoneNo_Textbox.Text = "";
        }
        private void BoolIsEnabled(bool b)
        {
            Firstname_Textbox.IsEnabled = b;
            Lastname_Textbox.IsEnabled = b;
            Age_Textbox.IsEnabled = b;
            TelephoneNo_Textbox.IsEnabled = b;

            DeletePerson.IsEnabled = b;
            Up.IsEnabled = b;
            Down.IsEnabled = b;
        }
        private void CountPersons()
        {
            Person_Count.Content = $"Person Count {controller.PersonCount}";
            Index.Content = $"Index {controller.PersonIndex}";
        }
    }
}
