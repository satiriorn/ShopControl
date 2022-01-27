namespace ShopControl
{
    partial class StreamCameraControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CameraBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.BtnConnect = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnDisconnect = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnFullCamera = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnAddIntoDb = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnRemoveFromDB = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CameraBox1
            // 
            this.CameraBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraBox1.Location = new System.Drawing.Point(14, 3);
            this.CameraBox1.Name = "CameraBox1";
            this.CameraBox1.Size = new System.Drawing.Size(311, 276);
            this.CameraBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CameraBox1.TabIndex = 30;
            this.CameraBox1.TabStop = false;
            this.CameraBox1.MouseHover += new System.EventHandler(this.CameraBox1_MouseHover);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox1.BackColor = System.Drawing.Color.DimGray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(109, 285);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 20);
            this.textBox1.TabIndex = 33;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnConnect.Location = new System.Drawing.Point(14, 281);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            this.BtnConnect.Size = new System.Drawing.Size(75, 26);
            this.BtnConnect.TabIndex = 36;
            this.BtnConnect.Values.Text = "Connect";
            this.BtnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDisconnect.Location = new System.Drawing.Point(242, 281);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            this.BtnDisconnect.Size = new System.Drawing.Size(75, 26);
            this.BtnDisconnect.TabIndex = 37;
            this.BtnDisconnect.Values.Text = "Disconnect";
            this.BtnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.Location = new System.Drawing.Point(305, 1);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            this.BtnClose.Size = new System.Drawing.Size(28, 26);
            this.BtnClose.TabIndex = 38;
            this.BtnClose.Values.Text = "X";
            this.BtnClose.Visible = false;
            this.BtnClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // BtnFullCamera
            // 
            this.BtnFullCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFullCamera.Location = new System.Drawing.Point(280, 1);
            this.BtnFullCamera.Name = "BtnFullCamera";
            this.BtnFullCamera.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            this.BtnFullCamera.Size = new System.Drawing.Size(28, 26);
            this.BtnFullCamera.TabIndex = 39;
            this.BtnFullCamera.Values.Text = "🞑";
            this.BtnFullCamera.Visible = false;
            this.BtnFullCamera.Click += new System.EventHandler(this.btnFullCamera_Click);
            // 
            // BtnAddIntoDb
            // 
            this.BtnAddIntoDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddIntoDb.Location = new System.Drawing.Point(14, 3);
            this.BtnAddIntoDb.Name = "BtnAddIntoDb";
            this.BtnAddIntoDb.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            this.BtnAddIntoDb.Size = new System.Drawing.Size(28, 26);
            this.BtnAddIntoDb.TabIndex = 40;
            this.BtnAddIntoDb.Values.Text = "➕";
            this.BtnAddIntoDb.Visible = false;
            this.BtnAddIntoDb.Click += new System.EventHandler(this.BtnAddIntoDb_Click);
            // 
            // BtnRemoveFromDB
            // 
            this.BtnRemoveFromDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemoveFromDB.Location = new System.Drawing.Point(38, 3);
            this.BtnRemoveFromDB.Name = "BtnRemoveFromDB";
            this.BtnRemoveFromDB.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            this.BtnRemoveFromDB.Size = new System.Drawing.Size(28, 26);
            this.BtnRemoveFromDB.TabIndex = 41;
            this.BtnRemoveFromDB.Values.Text = "☤";
            this.BtnRemoveFromDB.Visible = false;
            this.BtnRemoveFromDB.Click += new System.EventHandler(this.BtnRemoveFromDB_Click);
            // 
            // StreamCameraControl
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.BtnRemoveFromDB);
            this.Controls.Add(this.BtnAddIntoDb);
            this.Controls.Add(this.BtnFullCamera);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnDisconnect);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CameraBox1);
            this.Name = "StreamCameraControl";
            this.Size = new System.Drawing.Size(336, 310);
            this.MouseLeave += new System.EventHandler(this.StreamCameraControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox CameraBox1;
        private System.Windows.Forms.TextBox textBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnConnect;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnDisconnect;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnFullCamera;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnAddIntoDb;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnRemoveFromDB;
    }
}
