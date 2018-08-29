using EventSourcing.UI.WinForms.ViewModels;
using System.Windows.Forms;

namespace EventSourcing.UI.WinForms.Views
{
    public partial class AddNewPersonForm : Form
    {
        private AddNewPersonForm()
        {
            InitializeComponent();
        }

        public static PersonViewModel CreatePerson()
        {
            using (var form = new AddNewPersonForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return null;

                var firstName = form.txtFirstName.Text;
                var lastName = form.txtLastName.Text;
                return new PersonViewModel { FirstName = firstName, LastName = lastName };
            }
        }
    }
}
