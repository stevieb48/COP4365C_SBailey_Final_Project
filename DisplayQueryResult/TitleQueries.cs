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

        //
        private void CmbbxQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set data displayed according to what is selected
            switch (cmbbxQueries.SelectedIndex)
            {
                case 0: // All titles with their authors. Sorted by title
                    // use linq
                    var titlesByAuthorSortTitle =
                        from author in dbcontext.Authors
                        orderby author.FirstName, author.LastName
                        select new
                        {
                            Name = author.FirstName + " " + author.LastName,
                            Titles =
                                from book in author.Titles
                                orderby book.Title1
                                select book.Title1
                        };

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
                    var titlesByAuthorSortTitleSortAuthorAtoZLastNameFirstName =
                        from author in dbcontext.Authors
                        orderby author.FirstName, author.LastName
                        select new
                        {
                            Name = author.FirstName + " " + author.LastName,
                            Titles =
                                from book in author.Titles
                                orderby book.Title1
                                select book.Title1
                        };

                    txtbxResults.AppendText("\r\n\r\nTitles grouped by author:");

                    foreach (var author in titlesByAuthorSortTitleSortAuthorAtoZLastNameFirstName)
                    {
                        txtbxResults.AppendText("\r\n\t" + author.Name + ":");

                        foreach (var title in author.Titles)
                        {
                            txtbxResults.AppendText("\r\n\t\t" + title);
                        }
                    }

                    break;
                case 2: // All authors. Group by title. For each title sort authors A-Z last name, then first
                    // use linq
                    var authorsByTitleSortTitleSortAuthorAtoZLastNameFirstName =
                        from author in dbcontext.Authors
                        orderby author.FirstName, author.LastName
                        select new
                        {
                            Name = author.FirstName + " " + author.LastName,
                            Titles =
                                from book in author.Titles
                                orderby book.Title1
                                select book.Title1
                        };

                    txtbxResults.AppendText("\r\n\r\nTitles grouped by author:");

                    foreach (var author in authorsByTitleSortTitleSortAuthorAtoZLastNameFirstName)
                    {
                        txtbxResults.AppendText("\r\n\t" + author.Name + ":");

                        foreach (var title in author.Titles)
                        {
                            txtbxResults.AppendText("\r\n\t\t" + title);
                        }
                    }

                    break;
            } // end switch
        } // end method cmbbxQueries_SelectedIndexChanged
    } // end class TitleQueries
} // end namespace DisplayQueryResults