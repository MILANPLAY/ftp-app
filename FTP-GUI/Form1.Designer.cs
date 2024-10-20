namespace FTP_GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Device_List = new Panel();
            Title = new Label();
            Device_Info = new Panel();
            Device_Info_Title = new Label();
            Device_Image = new Panel();
            Device_InfoL = new Label();
            Device_Info.SuspendLayout();
            SuspendLayout();
            // 
            // Device_List
            // 
            Device_List.AutoScroll = true;
            Device_List.BackColor = Color.FromArgb(64, 64, 64);
            Device_List.Location = new Point(1, 76);
            Device_List.Name = "Device_List";
            Device_List.Size = new Size(140, 375);
            Device_List.TabIndex = 0;
            // 
            // Title
            // 
            Title.BackColor = Color.FromArgb(0, 64, 0);
            Title.Font = new Font("Verdana", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Title.ForeColor = SystemColors.Control;
            Title.Location = new Point(-8, 0);
            Title.Name = "Title";
            Title.Size = new Size(812, 77);
            Title.TabIndex = 1;
            Title.Text = " FTP - GUI (V 0.1)";
            Title.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Device_Info
            // 
            Device_Info.AutoScroll = true;
            Device_Info.BackColor = Color.FromArgb(64, 64, 64);
            Device_Info.Controls.Add(Device_Info_Title);
            Device_Info.Controls.Add(Device_Image);
            Device_Info.Controls.Add(Device_InfoL);
            Device_Info.Location = new Point(628, 76);
            Device_Info.Name = "Device_Info";
            Device_Info.Size = new Size(176, 375);
            Device_Info.TabIndex = 1;
            // 
            // Device_Info_Title
            // 
            Device_Info_Title.FlatStyle = FlatStyle.Flat;
            Device_Info_Title.Font = new Font("Verdana", 15.25F);
            Device_Info_Title.ForeColor = Color.WhiteSmoke;
            Device_Info_Title.Location = new Point(3, 0);
            Device_Info_Title.Name = "Device_Info_Title";
            Device_Info_Title.Size = new Size(173, 29);
            Device_Info_Title.TabIndex = 2;
            Device_Info_Title.Text = "Device Info";
            Device_Info_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Device_Image
            // 
            Device_Image.BackgroundImageLayout = ImageLayout.Stretch;
            Device_Image.Location = new Point(26, 32);
            Device_Image.Name = "Device_Image";
            Device_Image.Size = new Size(125, 125);
            Device_Image.TabIndex = 1;
            // 
            // Device_InfoL
            // 
            Device_InfoL.FlatStyle = FlatStyle.Flat;
            Device_InfoL.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Device_InfoL.ForeColor = Color.WhiteSmoke;
            Device_InfoL.Location = new Point(0, 180);
            Device_InfoL.Name = "Device_InfoL";
            Device_InfoL.Size = new Size(173, 195);
            Device_InfoL.TabIndex = 0;
            Device_InfoL.Text = "Name: null\r\nIP: null\r\nPlatForm: null\r\nOS: null";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            Controls.Add(Device_Info);
            Controls.Add(Title);
            Controls.Add(Device_List);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "FTP-GUI";
            Load += Form1_Load;
            Device_Info.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Device_List;
        private Label Title;
        private Panel Device_Info;
        private Label Device_InfoL;
        private Panel Device_Image;
        private Label Device_Info_Title;
    }
}
