using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisplayTable
{
    public partial class DisplayAuthorsTable : Form
    {
        // constructor
        public DisplayAuthorsTable()
        {
            InitializeComponent();
        } // end contructor

        // enitity framework DbContext
        private BooksExamples.BooksEntities dbcontext = new BooksExamples.BooksEntities();

        // load data from database into gridview
        private void DisplayAuthorsTable_Load(object sender, EventArgs e)
        {
            // load Authors table ordered by LastName then FirstName
            dbcontext.Authors
                .OrderBy(author => author.LastName)
                .ThenBy(author => author.FirstName)
                .Load();

            // specify DataSource for authorBindingSource
            authorBindingSource.DataSource = dbcontext.Authors.Local;
        } // end method DisplayAuthorsTable_Load

        //
        //
        private void authorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate(); // validate input fields
            authorBindingSource.EndEdit(); // complete current edit, if any

            // try to save changes
            try
            {
                dbcontext.SaveChanges(); // write changes to the database file
            } // end try
            catch (DbEntityValidationException)
            {
                MessageBox.Show("FirstName and LastName must contain values", "Entity Validation Exception");
            }
        }
    }
}
