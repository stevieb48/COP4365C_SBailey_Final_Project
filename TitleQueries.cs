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
 * This form ...
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

        //
        private void CmbbxQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Retrieve data list here, ordered by Title:
            var titleAuthorList = from a in dbcontext.Authors
                join t in dbcontext.Titles on a.AuthorID equals t.AuthorId
                orderby t.Title1
                select new {AuthorFirstName = a.FirstName, AuthorLastName = a.LastName, Title = t.Title1};

            var listByLastName = titleAuthorList.OrderBy(x => x.AuthorLastName).ToList();

            // set data displayed according to what is selected
            switch (cmbbxQueries.SelectedIndex)
            {
               
                case 0: // List All titles with their authors. Sorted by title
                    // use linq
                    
                    txtbxResults.AppendText("\r\n\r\nTitles grouped by author:");

                    foreach (var author in titlesByAuthorSortTitle)
                    {
                        txtbxResults.AppendText("\r\n\t" + author.Name + ":");

                        foreach (var title in author.Titles)
                        {
                            txtbxResults.AppendText("\r\n\t\t" + title);
                        }
                    }

                    break;
                case 1: // All titles and the authors. Sorted by title. For each title sort authors A-Z last name, then first
                    // use linq   
                    

                    break;
                case 2: // List All authors. Group by title. Sorted by title. For each title sort authors A-Z last name, then first
                    // use linq                  

                    break;
            } // end switch
        } // end method cmbbxQueries_SelectedIndexChanged
    } // end class TitleQueries
} // end namespace DisplayQueryResults