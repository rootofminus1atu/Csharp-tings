using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Q2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Member> members = new ObservableCollection<Member>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxMemberType.ItemsSource = Enum.GetValues(typeof(MemberType));
            lbxMembers.ItemsSource = members;

            Binding binding = new Binding("Count");
            binding.Source = members;
            binding.StringFormat = "Total amount of members: {0}";
            txtTotalMembers.SetBinding(TextBlock.TextProperty, binding);
        }

        private void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            MemberType? memberType = cbxMemberType.SelectedItem as MemberType?;
            string? name = txtName.Text;
            DateTime? date = dpDate.SelectedDate;

            if (AnyIsNull(memberType, name, date))
            {
                MessageBox.Show("Fill out all fields");
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }

            Member newMember = new Member((MemberType)memberType, name, (DateTime)date);
            MessageBox.Show($"The member: {newMember}");
            members.Add(newMember);

        }

        private static bool AnyIsNull(params object?[] values)
        {
            foreach (var value in values)
            {
                if (value == null || (value is string str && string.IsNullOrEmpty(str)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
