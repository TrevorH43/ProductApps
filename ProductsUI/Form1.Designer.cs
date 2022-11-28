namespace ProductsUI
{
    partial class Form1
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
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.productsDataGridView = new System.Windows.Forms.DataGridView();
            this.productIDTextBox = new System.Windows.Forms.TextBox();
            this.productDescTextBox = new System.Windows.Forms.TextBox();
            this.sortAscButton = new System.Windows.Forms.Button();
            this.sortDescButton = new System.Windows.Forms.Button();
            this.minPriceButton = new System.Windows.Forms.Button();
            this.maxPriceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(374, 101);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product Desc:";
            // 
            // productsDataGridView
            // 
            this.productsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsDataGridView.Location = new System.Drawing.Point(46, 155);
            this.productsDataGridView.Name = "productsDataGridView";
            this.productsDataGridView.Size = new System.Drawing.Size(650, 217);
            this.productsDataGridView.TabIndex = 4;
            // 
            // productIDTextBox
            // 
            this.productIDTextBox.Location = new System.Drawing.Point(182, 47);
            this.productIDTextBox.Name = "productIDTextBox";
            this.productIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.productIDTextBox.TabIndex = 5;
            // 
            // productDescTextBox
            // 
            this.productDescTextBox.Location = new System.Drawing.Point(182, 104);
            this.productDescTextBox.Name = "productDescTextBox";
            this.productDescTextBox.Size = new System.Drawing.Size(168, 20);
            this.productDescTextBox.TabIndex = 6;
            // 
            // sortAscButton
            // 
            this.sortAscButton.Location = new System.Drawing.Point(713, 155);
            this.sortAscButton.Name = "sortAscButton";
            this.sortAscButton.Size = new System.Drawing.Size(75, 40);
            this.sortAscButton.TabIndex = 7;
            this.sortAscButton.Text = "Sort Ascending";
            this.sortAscButton.UseVisualStyleBackColor = true;
            this.sortAscButton.Click += new System.EventHandler(this.sortAscButton_Click);
            // 
            // sortDescButton
            // 
            this.sortDescButton.Location = new System.Drawing.Point(713, 201);
            this.sortDescButton.Name = "sortDescButton";
            this.sortDescButton.Size = new System.Drawing.Size(75, 34);
            this.sortDescButton.TabIndex = 8;
            this.sortDescButton.Text = "Sort Descending ";
            this.sortDescButton.UseVisualStyleBackColor = true;
            this.sortDescButton.Click += new System.EventHandler(this.sortDescButton_Click);
            // 
            // minPriceButton
            // 
            this.minPriceButton.Location = new System.Drawing.Point(713, 241);
            this.minPriceButton.Name = "minPriceButton";
            this.minPriceButton.Size = new System.Drawing.Size(75, 33);
            this.minPriceButton.TabIndex = 9;
            this.minPriceButton.Text = "Min Price";
            this.minPriceButton.UseVisualStyleBackColor = true;
            this.minPriceButton.Click += new System.EventHandler(this.minPriceButton_Click);
            // 
            // maxPriceButton
            // 
            this.maxPriceButton.Location = new System.Drawing.Point(713, 291);
            this.maxPriceButton.Name = "maxPriceButton";
            this.maxPriceButton.Size = new System.Drawing.Size(75, 39);
            this.maxPriceButton.TabIndex = 10;
            this.maxPriceButton.Text = "Max Price";
            this.maxPriceButton.UseVisualStyleBackColor = true;
            this.maxPriceButton.Click += new System.EventHandler(this.maxPriceButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.maxPriceButton);
            this.Controls.Add(this.minPriceButton);
            this.Controls.Add(this.sortDescButton);
            this.Controls.Add(this.sortAscButton);
            this.Controls.Add(this.productDescTextBox);
            this.Controls.Add(this.productIDTextBox);
            this.Controls.Add(this.productsDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView productsDataGridView;
        private System.Windows.Forms.TextBox productIDTextBox;
        private System.Windows.Forms.TextBox productDescTextBox;
        private System.Windows.Forms.Button sortAscButton;
        private System.Windows.Forms.Button sortDescButton;
        private System.Windows.Forms.Button minPriceButton;
        private System.Windows.Forms.Button maxPriceButton;
    }
}

