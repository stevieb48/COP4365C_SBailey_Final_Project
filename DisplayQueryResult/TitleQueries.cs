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

/*
 * This form Displays the Titles Table in the books database using Entity framwork
 * 
 * author: Stephen Bailey
 * course: COP4365C
 * assignment: Final Project
 * date: 04/25/2018
 * file name: TitleQueries.cs
 * version: 1.0
 */
namespace DisplayQueryResult
{
    public partial class TitleQueries : Form
    {
        // constructor
        public TitleQueries()
        {
            InitializeComponent();
        } // end contructor

        // enitity framework DbContext
        private BooksExamples.BooksEntities dbcontext = new BooksExamples.BooksEntities();

        // load data from database into data grid view
        private void TitleQueries_Load(object sender, EventArgs e)
        {
            // load Titles table into memory
            dbcontext.Titles.Load();

            // set combobox default query that selects all books from the titles table
            cmbbxQueries.SelectedIndex = 0;
        } // end method TitleQueries_Load

        //
        private void CmbbxQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set data displayed according to what is selected
            switch (cmbbxQueries.SelectedIndex)
            {
                case 0: // all titles
                    // use linq
                    titleBindingSource.DataSource = dbcontext.Titles.Local.OrderBy(book => book.Title1);
                    break;
                case 1: // all titles with copyright 2014
                    // use linq
                    titleBindingSource.DataSource = dbcontext.Titles.Local
                        .Where(book => book.Copyright == "2014")
                        .OrderBy(book => book.Title1); ;
                    break;
                case 2: // all titles ending with "How to Program"
                    // use linq
                    titleBindingSource.DataSource = dbcontext.Titles.Local
                        .Where(book => book.Title1.EndsWith("How to Program"))
                        .OrderBy(book => book.Title1); ;
                    break;
            } // end switch

            // move to first entry
            titleBindingSource.MoveFirst();

        } // end method cmbbxQueries_SelectedIndexChanged
    } // end class TitleQueries
} // end namespace DisplayQueryResults