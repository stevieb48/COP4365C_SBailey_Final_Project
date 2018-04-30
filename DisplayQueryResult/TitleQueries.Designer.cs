namespace DisplayQueryResult
{
    partial class TitleQueries
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.titleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbbxQueries = new System.Windows.Forms.ComboBox();
            this.txtbxResults = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.titleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBindingSource
            // 
            this.titleBindingSource.DataSource = typeof(BooksExamples.Title);
            // 
            // cmbbxQueries
            // 
            this.cmbbxQueries.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmbbxQueries.FormattingEnabled = true;
            this.cmbbxQueries.Items.AddRange(new object[] {
            "1. All titles with the authors. Sorted by title",
            "2. All titles and the authors. Sorted by title. For each title sort authors A-Z l" +
                "ast name, then first",
            "3. All authors. Group by title. For each title sort authors A-Z last name, then f" +
                "irst"});
            this.cmbbxQueries.Location = new System.Drawing.Point(0, 281);
            this.cmbbxQueries.Name = "cmbbxQueries";
            this.cmbbxQueries.Size = new System.Drawing.Size(625, 24);
            this.cmbbxQueries.TabIndex = 2;
            this.cmbbxQueries.SelectedIndexChanged += new System.EventHandler(this.CmbbxQueries_SelectedIndexChanged);
            // 
            // txtbxResults
            // 
            this.txtbxResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbxResults.Font = new System.Drawing.Font("Lucida Console", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxResults.Location = new System.Drawing.Point(0, 0);
            this.txtbxResults.Multiline = true;
            this.txtbxResults.Name = "txtbxResults";
            this.txtbxResults.ReadOnly = true;
            this.txtbxResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxResults.Size = new System.Drawing.Size(625, 281);
            this.txtbxResults.TabIndex = 3;
            // 
            // TitleQueries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 305);
            this.Controls.Add(this.txtbxResults);
            this.Controls.Add(this.cmbbxQueries);
            this.Name = "TitleQueries";
            this.Text = "Display Query Results";
            ((System.ComponentModel.ISupportInitialize)(this.titleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource titleBindingSource;
        private System.Windows.Forms.ComboBox cmbbxQueries;
        private System.Windows.Forms.TextBox txtbxResults;
    }
}