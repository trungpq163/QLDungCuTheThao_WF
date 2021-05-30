namespace QLDungCuTheThao.Forms
{
    partial class TopMatHangBanChayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopMatHangBanChayForm));
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.datePickerStart = new System.Windows.Forms.DateTimePicker();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTopMatHangBanChay = new System.Windows.Forms.DataGridView();
            this.btnReload = new System.Windows.Forms.Button();
            this.Name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfItemsSold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopMatHangBanChay)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBack
            // 
            this.pbBack.BackColor = System.Drawing.Color.Tomato;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(876, -1);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(41, 31);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBack.TabIndex = 12;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Tomato;
            this.pbExit.Image = ((System.Drawing.Image)(resources.GetObject("pbExit.Image")));
            this.pbExit.Location = new System.Drawing.Point(912, -1);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(42, 31);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbExit.TabIndex = 11;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // datePickerStart
            // 
            this.datePickerStart.Location = new System.Drawing.Point(162, 99);
            this.datePickerStart.Name = "datePickerStart";
            this.datePickerStart.Size = new System.Drawing.Size(221, 22);
            this.datePickerStart.TabIndex = 35;
            this.datePickerStart.ValueChanged += new System.EventHandler(this.datePickerStart_ValueChanged);
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.Location = new System.Drawing.Point(516, 99);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.Size = new System.Drawing.Size(221, 22);
            this.datePickerEnd.TabIndex = 36;
            this.datePickerEnd.ValueChanged += new System.EventHandler(this.datePickerEnd_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font(".Helvetica NeueUI", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(54, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 33);
            this.label1.TabIndex = 37;
            this.label1.Text = "Top các mặt hàng bán chạy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font(".Helvetica NeueUI", 8.999999F);
            this.label6.Location = new System.Drawing.Point(57, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Ngày bắt đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font(".Helvetica NeueUI", 8.999999F);
            this.label2.Location = new System.Drawing.Point(408, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "Ngày kết thúc";
            // 
            // dgvTopMatHangBanChay
            // 
            this.dgvTopMatHangBanChay.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopMatHangBanChay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopMatHangBanChay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name2,
            this.NumberOfItemsSold,
            this.Manufacturer,
            this.Price,
            this.ProductCategory,
            this.ProductDescription,
            this.Quantity,
            this.Size});
            this.dgvTopMatHangBanChay.Location = new System.Drawing.Point(60, 134);
            this.dgvTopMatHangBanChay.Name = "dgvTopMatHangBanChay";
            this.dgvTopMatHangBanChay.RowTemplate.Height = 24;
            this.dgvTopMatHangBanChay.Size = new System.Drawing.Size(843, 467);
            this.dgvTopMatHangBanChay.TabIndex = 40;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnReload.FlatAppearance.BorderSize = 0;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font(".Helvetica NeueUI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(743, 92);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(160, 36);
            this.btnReload.TabIndex = 60;
            this.btnReload.Text = "Tải lại";
            this.btnReload.UseVisualStyleBackColor = false;
            // 
            // Name2
            // 
            this.Name2.DataPropertyName = "Name";
            this.Name2.HeaderText = "Tên sản phẩm";
            this.Name2.Name = "Name2";
            // 
            // NumberOfItemsSold
            // 
            this.NumberOfItemsSold.DataPropertyName = "NumberOfItemsSold";
            this.NumberOfItemsSold.HeaderText = "Số lượng SP bán được";
            this.NumberOfItemsSold.Name = "NumberOfItemsSold";
            // 
            // Manufacturer
            // 
            this.Manufacturer.DataPropertyName = "Manufacturer";
            this.Manufacturer.HeaderText = "Nhà SX";
            this.Manufacturer.Name = "Manufacturer";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Giá";
            this.Price.Name = "Price";
            // 
            // ProductCategory
            // 
            this.ProductCategory.DataPropertyName = "ProductCategory";
            this.ProductCategory.HeaderText = "ID Danh mục sản phẩm";
            this.ProductCategory.Name = "ProductCategory";
            // 
            // ProductDescription
            // 
            this.ProductDescription.DataPropertyName = "ProductDescription";
            this.ProductDescription.HeaderText = "Chi tiết sản phẩm";
            this.ProductDescription.Name = "ProductDescription";
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Số lượng";
            this.Quantity.Name = "Quantity";
            // 
            // Size
            // 
            this.Size.DataPropertyName = "Size";
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            // 
            // TopMatHangBanChayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(953, 613);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.dgvTopMatHangBanChay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datePickerEnd);
            this.Controls.Add(this.datePickerStart);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.pbExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TopMatHangBanChayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TopMatHangBanChayForm";
            this.Load += new System.EventHandler(this.TopMatHangBanChayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopMatHangBanChay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.DateTimePicker datePickerStart;
        private System.Windows.Forms.DateTimePicker datePickerEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTopMatHangBanChay;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfItemsSold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
    }
}