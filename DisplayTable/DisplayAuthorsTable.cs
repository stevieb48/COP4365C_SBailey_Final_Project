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

/*
 * This form Displays the Authors Table in the books database using Entity framwork
 * 
 * author: Stephen Bailey
 * course: COP4365C
 * assignment: Final Project
 * date: 04/25/2018
 * file name: DisplayAuthorsTable.cs
 * version: 1.0
 */
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
        private void AuthorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
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
            } // end catch
        } // end method AuthorBindingNavigatorSaveItem_Click
    } // end class DisplayAuthorsTable
} // end namespace DisplayTable