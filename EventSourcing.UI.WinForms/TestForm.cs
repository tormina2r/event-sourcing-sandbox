using EventSourcing.BusinessLogic;
using EventSourcing.UI.WinForms.Views;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EventSourcing.UI.WinForms
{
    public partial class TestForm : Form
    {
        private readonly DomainModel _DomainModel = new DomainModel();

        public TestForm()
        {
            InitializeComponent();

            _DomainModel.EventAdded += _DomainModel_EventAdded;
            RefreshEvents();
        }

        private void btnAddPersonCommand_Click(object sender, EventArgs e)
        {
            var person = AddNewPersonForm.CreatePerson();
            if (person == null)
                return;

            _DomainModel.AddPerson(person.FirstName, person.LastName);
        }

        private void _DomainModel_EventAdded(object sender, EventArgs e)
        {
            RefreshEvents();
        }

        private void RefreshEvents()
        {
            dgvEvents.DataSource = _DomainModel.GetEventModels().ToList();
        }        
    }
}
